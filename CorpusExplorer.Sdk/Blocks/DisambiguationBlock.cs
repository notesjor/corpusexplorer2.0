#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Disambiguation;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   Class DisambiguationBlock.
  /// </summary>
  [Serializable]
  public class DisambiguationBlock : AbstractBlock
  {
    private Dictionary<string, Dictionary<string, double>> _dic;

    /// <summary>
    ///   Initializes a new instance of the <see cref="DisambiguationBlock" /> class.
    /// </summary>
    public DisambiguationBlock()
    {
      LayerDisplayname = "Wort";
      LayerQuery = string.Empty;
      MinimumSignificance = 0.8d;
      SimilarityIndex = new EuclideanDistance();
    }

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    public string LayerDisplayname { get; set; }

    /// <summary>
    ///   Gets or sets the layer query.
    /// </summary>
    public string LayerQuery { get; set; }

    /// <summary>
    ///   Gets or sets the minimum significance.
    /// </summary>
    public double MinimumSignificance { get; set; }

    /// <summary>
    ///   Wurzel-Cluster
    /// </summary>
    /// <value>The root cluster.</value>
    public DisambiguationCluster RootCluster { get; private set; }

    /// <summary>
    ///   Gets or sets the similarity index.
    /// </summary>
    public AbstractDistance SimilarityIndex { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      if (string.IsNullOrEmpty(LayerDisplayname) ||
          string.IsNullOrEmpty(LayerQuery))
        return;

      if (_dic == null)
      {
        var block = Selection.CreateBlock<CooccurrenceBlock>();
        block.LayerDisplayname = LayerDisplayname;
        block.Calculate();
        _dic = block.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();
      }

      if (!_dic.ContainsKey(LayerQuery))
      {
        RootCluster = null;
        return;
      }

      var words = _dic[LayerQuery];
      var clusters = new List<DisambiguationCluster>();
      foreach (var word in words.Where(word => _dic.ContainsKey(word.Key)))
        try
        {
          var other = _dic[word.Key];
          clusters.AddRange(
            other.Select(w => new DisambiguationCluster(word.Value, word.Key, w.Value, w.Key, words[w.Key])));
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }

      while (clusters.Count > 1)
      {
        int a = 0, b = 0;
        var min = double.MaxValue;

        for (var i = 0; i < clusters.Count; i++)
        for (var j = i + 1; j < clusters.Count; j++)
        {
          var diff = clusters[i].Distance(clusters[j]);
          if (diff >= min)
            continue;
          a = i;
          b = j;
          min = diff;
        }

        clusters[a].Join(clusters[b]);
        clusters.RemoveAt(b);
      }

      RootCluster = clusters.FirstOrDefault();
    }
  }
}