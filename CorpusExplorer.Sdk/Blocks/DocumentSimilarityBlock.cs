#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   Class DocumentSimilarityBlock.
  /// </summary>
  [Serializable]
  public class DocumentSimilarityBlock : AbstractBlock
  {
    private Dictionary<Guid, Dictionary<string, double>> _documents;

    /// <summary>
    ///   Initializes a new instance of the <see cref="DocumentSimilarityBlock" /> class.
    /// </summary>
    public DocumentSimilarityBlock()
    {
      LayerDisplayname = "Wort";
      MinimumInversDocumentFrequency = 0.003d;
      MinimumDocumentSimilarity = 0.7d;
      Similarity = new CosineMeasure();
    }

    public IEnumerable<Guid> DocumentGuids => Selection.DocumentGuids;

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    public string LayerDisplayname { get; set; }

    public double MinimumDocumentSimilarity { get; set; }

    /// <summary>
    ///   Gets or sets the minimum invers document frequency.
    /// </summary>
    public double MinimumInversDocumentFrequency { get; set; }

    /// <summary>
    ///   Gets or sets the similarity algorithm.
    /// </summary>
    /// <value>The similarity.</value>
    public AbstractSimilarity Similarity { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var block = Selection.CreateBlock<InverseDocumentVectorBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.MinimumInversDocumentFrequency = MinimumInversDocumentFrequency;
      block.Calculate();

      _documents = block.InverseDocumentVector;
    }

    public Dictionary<Guid, double> RequestDocumentSimilarity(Guid documentGuid)
    {
      if (!_documents.ContainsKey(documentGuid))
        return null;

      var reference = _documents[documentGuid];
      var res = new Dictionary<Guid, double>();

      foreach (var doc in _documents.Where(doc => doc.Key != documentGuid))
      {
        var sim = Similarity.CalculateSimilarity(reference, doc.Value);
        if (double.IsInfinity(sim) ||
            double.IsNaN(sim)      ||
            sim < MinimumDocumentSimilarity)
          continue;
        res.Add(doc.Key, sim);
      }

      return res;
    }

    public Dictionary<string, double> RequestMetaclusterSimilarity(string metaName, string metaValue)
    {
      var clusters = RequestMetaclusterSimilarity_GetCluster(metaName);
      if (!clusters.ContainsKey(metaValue))
        return null;

      var reference = RequestMetaclusterSimilarity_ConvertClusterToVector(clusters[metaValue]);
      clusters.Remove(metaValue);

      var res = new Dictionary<string, double>();
      foreach (var cluster in clusters)
      {
        var sim = Similarity.CalculateSimilarity(
                                                 reference,
                                                 RequestMetaclusterSimilarity_ConvertClusterToVector(cluster.Value));
        if (double.IsInfinity(sim) ||
            double.IsNaN(sim)      ||
            sim < MinimumDocumentSimilarity)
          continue;
        res.Add(cluster.Key, sim);
      }

      return res;
    }

    private Dictionary<string, double> RequestMetaclusterSimilarity_ConvertClusterToVector(List<Guid> guids)
    {
      var res = new Dictionary<string, double>();
      var div = new Dictionary<string, double>();

      foreach (
        var entry in
        guids.Where(guid => _documents.ContainsKey(guid))
             .Select(guid => _documents[guid])
             .SelectMany(entries => entries))
        if (res.ContainsKey(entry.Key))
        {
          res[entry.Key] += entry.Value;
          div[entry.Key]++;
        }
        else
        {
          res.Add(entry.Key, entry.Value);
          div.Add(entry.Key, 1.0d);
        }

      foreach (var entry in div)
        res[entry.Key] /= entry.Value;

      return res;
    }

    private Dictionary<string, List<Guid>> RequestMetaclusterSimilarity_GetCluster(string metaName)
    {
      var meta = Selection.DocumentMetadata;
      var cluster = new Dictionary<string, List<Guid>>();

      foreach (var doc in meta)
      foreach (var key in from entry in doc.Value where metaName == entry.Key select entry.Value?.ToString() ?? "")
        if (cluster.ContainsKey(key))
          cluster[key].Add(doc.Key);
        else
          cluster.Add(key, new List<Guid> {doc.Key});
      return cluster;
    }
  }
}