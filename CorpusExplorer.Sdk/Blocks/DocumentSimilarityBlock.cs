#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   Class DocumentSimilarityBlock.
  /// </summary>
  [Serializable]
  public class DocumentSimilarityBlock : AbstractBlock
  {
    private Dictionary<string, Dictionary<string, double>> _results;
    private object _resultsLock = new object();

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    public string LayerDisplayname { get; set; } = "Wort";

    public string MetadataKey { get; set; } = "GUID";

    public double MinimumDocumentSimilarity { get; set; } = 0.7d;

    /// <summary>
    ///   Gets or sets the minimum invers document frequency.
    /// </summary>
    public double MinimumInversDocumentFrequency { get; set; } = 0.003d;

    /// <summary>
    ///   Gets or sets the similarity algorithm.
    /// </summary>
    /// <value>The similarity.</value>
    public AbstractSimilarity Similarity { get; set; } = new CosineMeasure();

    public IEnumerable<KeyValuePair<string, Dictionary<string, double>>> SimilarityResults
    {
      get
      {
        lock (_resultsLock)
          return _results;
      }
    }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var block = Selection.CreateBlock<TermDocumentMatrixBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.MetadataKey = MetadataKey;
      block.MinimumInversDocumentFrequency = MinimumInversDocumentFrequency;
      block.Calculate();

      lock (_resultsLock)
        _results = new Dictionary<string, Dictionary<string, double>>();

      var matrix = block.TermDocumentMatrix.ToArray();

      Parallel.For(0, matrix.Length, Configuration.ParallelOptions, i =>
      {
        var k1 = matrix[i].Key;
        var reference = matrix[i].Value;

        Parallel.For(i + 1, matrix.Length, Configuration.ParallelOptions, j =>
        {
          var k2 = matrix[j].Key;
          var current = matrix[j].Value;
          var sim = Similarity.CalculateSimilarity(reference, current);

          if (double.IsInfinity(sim) ||
              double.IsNaN(sim)      ||
              sim < MinimumDocumentSimilarity)
            return;

          lock (_resultsLock)
            if (_results.ContainsKey(k1))
              _results[k1].Add(k2, sim);
            else
              _results.Add(k1, new Dictionary<string, double> { { k2, sim } });
        });
      });
    }
  }
}