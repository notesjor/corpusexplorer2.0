using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class NgramChainViewModel : AbstractViewModel, IUseSpecificLayer, IProvideDataTable
  {
    /// <summary>
    ///   The _n gram pattern max.
    /// </summary>
    private int _nGramPatternSize;

    /// <summary>
    ///   The _n gram size.
    /// </summary>
    private int _nGramSize;

    /// <summary>
    ///   Initializes a new instance of the <see cref="NgramViewModel" /> class.
    /// </summary>
    public NgramChainViewModel()
    {
      NGramSize = 5;
      NGramPatternSize = 1;
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
    public int NGramPatternSize
    {
      get => _nGramPatternSize;
      set => _nGramPatternSize = value >= _nGramSize ? _nGramSize - 1 : value;
    }

    /// <summary>
    ///   Gets or sets the n gram size.
    /// </summary>
    public int NGramSize
    {
      get => _nGramSize;
      set
      {
        _nGramSize = value;
        NGramPatternSize = value - 1;
      }
    }

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
        res.Rows.Add(string.Join(" ", pair.Key), pair.Value);
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

    public IEnumerable<KeyValuePair<string, int>> TakeNGramFrequency(int max)
    {
      return NGramFrequency.OrderByDescending(x => x.Value).Take(max);
    }

    protected override bool Validate()
    {
      return NGramSize > -1 && !string.IsNullOrEmpty(NGramPattern)
             && !string.IsNullOrEmpty(LayerDisplayname);
    }
  }
}