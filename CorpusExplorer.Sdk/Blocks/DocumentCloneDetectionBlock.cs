using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Diff;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentCloneDetectionBlock : AbstractBlock
  {
    public HashSet<Guid> DetectedClones { get; private set; }

    public double DocumentMutationFactor { get; set; } = 0.1;

    public IEnumerable<Guid> IndividualDocuments
    {
      get { return Selection.DocumentGuids.Where(guid => !DetectedClones.Contains(guid)); }
    }

    public double InduvidualDocumentFactor { get; set; } = 0.25;

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    public string LayerDisplayname { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgef�hrt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var dsels = Selection.DocumentGuids.ToArray();

      DetectedClones = new HashSet<Guid>();
      var cloneLock = new object();

      Parallel.For(
        0,
        dsels.Length,
        i =>
        {
          lock (cloneLock)
          {
            if (DetectedClones.Contains(dsels[i]))
              return;
          }

          var corpusA = Selection.GetCorpusOfDocument(dsels[i]);
          var layerA = corpusA?.GetLayerOfDocument(dsels[i], LayerDisplayname);
          var docA = layerA?[dsels[i]];
          if (docA == null)
            return;

          Parallel.For(
            i + 1,
            dsels.Length,
            j =>
            {
              lock (cloneLock)
              {
                if (DetectedClones.Contains(dsels[j]))
                  return;
              }

              var corpusB = Selection.GetCorpusOfDocument(dsels[j]);
              var layerB = corpusB?.GetLayerOfDocument(dsels[j], LayerDisplayname);
              var docB = layerB?[dsels[j]];
              if (docB == null)
                return;

              var small = docA.ReduceToSingleDimension().ToArray();
              var big = docB.ReduceToSingleDimension().ToArray();

              if (small.Length > big.Length)
              {
                var temp = small;
                small = big;
                big = temp;
              }

              if (big.Length - small.Length > big.Length * InduvidualDocumentFactor)
                return;

              var diff = Diff.DiffInt(small, big);
              var sum = diff.Aggregate(0.0d, (current, d) => current + d.EditDistance);
              var lim = big.Length - small.Length + small.Length * DocumentMutationFactor;

              if (sum > lim)
                return;

              lock (cloneLock)
              {
                DetectedClones.Add(dsels[j]);
              }
            });
        });
    }
  }
}