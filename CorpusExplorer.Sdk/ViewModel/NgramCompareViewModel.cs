using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Ecosystem.Model;
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
      LayerDisplayname = "Wort";
    }

    public int NGramPatternSize { get; set; } = 0;

    /// <summary>
    ///   Gets or sets the n gram size.
    /// </summary>
    public int NGramSize { get; set; } = 5;

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
      var blockA = Selection.CreateBlock<Ngram1LayerPatternBlock>();
      blockA.NGramSize = NGramSize;
      blockA.NGramPatternSize = NGramPatternSize;
      blockA.LayerDisplayname = LayerDisplayname;
      blockA.Calculate();

      var blockB = SelectionToCompare.CreateBlock<Ngram1LayerPatternBlock>();
      blockB.NGramSize = NGramSize;
      blockB.NGramPatternSize = NGramPatternSize;
      blockB.LayerDisplayname = LayerDisplayname;
      blockB.Calculate();

      _dataTable = new DataTable();
      _dataTable.Columns.Add(Resources.NGram, typeof(string));
      _dataTable.Columns.Add(Resources.Frequeny1, typeof(double));
      _dataTable.Columns.Add(Resources.Frequeny2, typeof(double));
      _dataTable.Columns.Add(Resources.FrequenyD12, typeof(double));
      _dataTable.Columns.Add(Resources.Frequeny1 + Resources.relativ, typeof(double));
      _dataTable.Columns.Add(Resources.Frequeny2 + Resources.relativ, typeof(double));
      _dataTable.Columns.Add(Resources.FrequenyD12 + Resources.relativ, typeof(double));

      GenerateDataTable(blockA.NGramFrequency,
                        blockB.NGramFrequency);
    }

    protected override bool Validate()
    {
      return NGramSize > -1;
    }

    private struct Entry
    {
      public string NGram { get; set; }
      public double F1 { get; set; }
      public double F1Rel { get; set; }
      public double F2 { get; set; }
      public double F2Rel { get; set; }
      public double F12 { get; set; }
      public double F12Rel { get; set; }

      public Entry(string ngram, double f1, double f1Rel, double f2, double f2Rel)
      {
        NGram = ngram;
        F1 = f1;
        F2 = f2;
        F1Rel = f1Rel;
        F2Rel = f2Rel;
        F12 = Math.Abs(f1 - f2);
        F12Rel = Math.Abs(f1Rel - f2Rel);
      }
    }

    private void GenerateDataTable(Dictionary<string, double> a, Dictionary<string, double> b)
    {
      var aN = a.GetNormalizedDictionary(1000000);
      var bN = b.GetNormalizedDictionary(1000000);

      var data = new List<Entry>();

      foreach (var x in a)
      {
        if (b.ContainsKey(x.Key))
        {
          data.Add(new Entry(x.Key, x.Value, aN[x.Key], b[x.Key], bN[x.Key]));
          b.Remove(x.Key);
        }
        else
        {
          data.Add(new Entry(x.Key, x.Value, aN[x.Key], 0d, 0d));
        }
      }

      data.AddRange(b.Select(x => new Entry(x.Key, 0d, 0d, x.Value, bN[x.Key])));

      _dataTable.BeginLoadData();
      foreach (var x in data)
        _dataTable.Rows.Add(x.NGram, x.F1, x.F2, x.F12, x.F1Rel, x.F2Rel, x.F12Rel);
      _dataTable.EndLoadData();
    }
  }
}