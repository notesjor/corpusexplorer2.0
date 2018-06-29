using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using Hyldahl.Hashing.SpamSum;

namespace CorpusExplorer.Sdk.Extern.FuzzyCloneDetection.Blocks
{
  public class DocumentCloneFuzzyDetectionBlock : AbstractBlock
  {
    public HashSet<Guid> DetectedClones { get; private set; }

    public HashSet<Guid> IndividualDocuments { get; private set; }

    public int Threshold { get; set; } = 95;

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      if (Threshold > 100)
        Threshold = 100;
      if (Threshold < 0)
        Threshold = 0;

      var block = Selection.CreateBlock<DocumentFulltextBlock>();
      block.Calculate();

      var hashs = block.Documents.AsParallel().ToDictionary(x => x.Key, x => FuzzyHashing.CalculateQuick(x.Value))
        .ToArray();
      DetectedClones = new HashSet<Guid>();
      IndividualDocuments = new HashSet<Guid>();

      for (var i = 0; i < hashs.Length; i++)
      {
        if (DetectedClones.Contains(hashs[i].Key))
          continue;

        IndividualDocuments.Add(hashs[i].Key);
        var comp = hashs[i].Value;

        for (var j = i + 1; j < hashs.Length; j++)
          if (FuzzyHashing.Compare(comp, hashs[j].Value) > Threshold)
            DetectedClones.Add(hashs[j].Key);
      }
    }
  }
}