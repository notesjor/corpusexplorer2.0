using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class NgramCompareViewModel : AbstractCompareViewModel, IUseSpecificLayer, IProvideDataTable
  {
    private DataTable _dataTable;

    /// <summary>
    ///   Initializes a new instance of the <see cref="NgramViewModel" /> class.
    /// </summary>
    public NgramCompareViewModel()
    {
      NGramSize = 5;
      LayerDisplayname = "Wort";
      NGramMaxResults = 1000;
    }

    public int NGramMaxResults { get; set; }

    public int NGramPatternSize { get; set; }

    /// <summary>
    ///   Gets or sets the n gram size.
    /// </summary>
    public int NGramSize { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zur�ck
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      return _dataTable;
    }

    public IEnumerable<string> LayerDisplaynames => Selection.LayerUniqueDisplaynames;

    public string LayerDisplayname { get; set; }

    protected override void ExecuteAnalyse()
    {
      var blockA = Selection.CreateBlock<Ngram1LayerBlock>();
      blockA.NGramSize = NGramSize;
      blockA.LayerDisplayname = LayerDisplayname;
      blockA.Calculate();

      var blockB = SelectionToCompare.CreateBlock<Ngram1LayerBlock>();
      blockB.NGramSize = NGramSize;
      blockB.LayerDisplayname = LayerDisplayname;
      blockB.Calculate();

      _dataTable = new DataTable();
      _dataTable.Columns.Add(Resources.NGram, typeof(string));
      _dataTable.Columns.Add(Resources.Frequeny1, typeof(double));
      _dataTable.Columns.Add(Resources.Frequeny2, typeof(double));
      _dataTable.Columns.Add(Resources.FrequenyD12, typeof(double));

      GenerateDataTable(
        blockA.NGramFrequency.GetNormalizedDictionary(),
        blockB.NGramFrequency.GetNormalizedDictionary());
    }

    private void GenerateDataTable(Dictionary<string, double> a, Dictionary<string, double> b)
    {
      _dataTable.BeginLoadData();
      foreach (var x in a)
        if (b.ContainsKey(x.Key))
        {
          _dataTable.Rows.Add(x.Key, x.Value, b[x.Key], Math.Abs(x.Value - b[x.Key]));
          b.Remove(x.Key);
        }
        else
        {
          _dataTable.Rows.Add(x.Key, x.Value, 0.0d, x.Value);
        }

      foreach (var x in b)
        _dataTable.Rows.Add(x.Key, 0.0d, x.Value, x.Value);
      _dataTable.EndLoadData();
    }

    private Dictionary<string, double> GetNGramTable(Selection selection)
    {
      if (NGramPatternSize > 0)
      {
        var block = selection.CreateBlock<Ngram1LayerPatternBlock>();
        block.NGramSize = NGramSize;
        block.NGramPatternSize = NGramPatternSize;
        block.LayerDisplayname = LayerDisplayname;
        block.Calculate();
        return block.NGramFrequency.ToDictionary(x => x.Key, x => (double) x.Value);
      }
      else
      {
        var block = selection.CreateBlock<Ngram1LayerBlock>();
        block.NGramSize = NGramSize;
        block.LayerDisplayname = LayerDisplayname;
        block.Calculate();
        return block.NGramFrequency.ToDictionary(x => x.Key, x => (double) x.Value);
      }
    }

    protected override bool Validate() { return NGramSize > -1; }
  }
}