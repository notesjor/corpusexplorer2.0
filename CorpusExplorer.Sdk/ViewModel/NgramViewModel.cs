#region

using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  /// <summary>
  ///   The ngram view model.
  /// </summary>
  public class NgramViewModel : AbstractViewModel, IUseSpecificLayer, IProvideDataTable
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="NgramViewModel" /> class.
    /// </summary>
    public NgramViewModel()
    {
      NGramSize = 5;
      NGramPatternSize = 0;
      NGramPattern = "###";
      LayerDisplayname = "Wort";
      NGramMaxResults = 1000;
    }

    /// <summary>
    ///   Gets or sets the n gram frequency.
    /// </summary>
    public Dictionary<string, int> NGramFrequency { get; set; }

    public int NGramMaxResults { get; set; }

    /// <summary>
    ///   Gets or sets the n gram pattern.
    /// </summary>
    public string NGramPattern { get; set; }

    /// <summary>
    ///   Gets or sets the n gram pattern max.
    /// </summary>
    public int NGramPatternSize { get; set; }

    public int NGramSize { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zur�ck
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add(Resources.NGram, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(int));

      res.BeginLoadData();
      foreach (var pair in NGramFrequency)
        res.Rows.Add(pair.Key, pair.Value);
      res.EndLoadData();

      return res;
    }

    public DataTable GetDataTable(int minimalFrequency)
    {
      var res = new DataTable();
      res.Columns.Add(Resources.NGram, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(int));

      res.BeginLoadData();
      foreach (var pair in NGramFrequency)
        if (pair.Value > minimalFrequency)
          res.Rows.Add(pair.Key, pair.Value);
      res.EndLoadData();

      return res;
    }

    public IEnumerable<string> LayerDisplaynames => Selection.LayerUniqueDisplaynames;

    public string LayerDisplayname { get; set; }

    protected override void ExecuteAnalyse()
    {
      if (NGramPatternSize > 0)
      {
        var block = Selection.CreateBlock<Ngram1LayerPatternBlock>();
        block.NGramSize = NGramSize;
        block.NGramPattern = NGramPattern;
        block.NGramPatternSize = NGramPatternSize;
        block.LayerDisplayname = LayerDisplayname;
        block.Calculate();

        NGramFrequency = block.NGramFrequency;
      }
      else
      {
        var block = Selection.CreateBlock<Ngram1LayerBlock>();
        block.NGramSize = NGramSize;
        block.LayerDisplayname = LayerDisplayname;
        block.Calculate();

        NGramFrequency = block.NGramFrequency;
      }
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(NGramPattern) && !string.IsNullOrEmpty(LayerDisplayname)
                                                 && NGramPatternSize < NGramSize && NGramSize > 0;
    }
  }
}