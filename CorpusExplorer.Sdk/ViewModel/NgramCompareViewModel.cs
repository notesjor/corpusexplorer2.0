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
      _dataTable.Columns.Add(Resources.Frequeny1 + " (relativ)", typeof(double));
      _dataTable.Columns.Add(Resources.Frequeny2, typeof(double));
      _dataTable.Columns.Add(Resources.Frequeny2 + " (relativ)", typeof(double));
      _dataTable.Columns.Add(Resources.FrequenyD12, typeof(double));
      _dataTable.Columns.Add(Resources.Significance, typeof(double));

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
      public double Signi { get; set; }

      public Entry(string ngram, double f1, double f1Rel, double f2, double f2Rel, double f12, double signi)
      {
        NGram = ngram;
        F1 = f1;
        F1Rel = f1Rel;
        F2 = f2;
        F2Rel = f2Rel;
        F12 = f12;
        Signi = signi;
      }
    }

    private void GenerateDataTable(Dictionary<string, double> a, Dictionary<string, double> b)
    {
      var aN = a.GetNormalizedDictionary(1000000);
      var bN = b.GetNormalizedDictionary(1000000);

      var data = new List<Entry>();
      var sum = 0d; // Summe aller Frequenzen aus den gemergten Dictionarys

      foreach (var x in a)
      {
        if (b.ContainsKey(x.Key))
        {
          data.Add(new Entry(x.Key, x.Value, aN[x.Key], b[x.Key], bN[x.Key], Math.Abs(x.Value - b[x.Key]), 0d));
          sum += b[x.Key];
          b.Remove(x.Key);
        }
        else
        {
          data.Add(new Entry(x.Key, x.Value, aN[x.Key], 0d, 0d, x.Value, -1d));
        }

        sum += x.Value;
      }

      foreach (var x in b)
      {
        data.Add(new Entry(x.Key, 0d, 0d, x.Value, bN[x.Key], x.Value, -1d));
        sum += x.Value;
      }

      // Signifikanz
      Parallel.For(0, data.Count, Configuration.ParallelOptions, (i) =>
      {
        var x = data[i];
        if (x.Signi < 0)
          return;

        var m = Math.Abs(x.F1 - x.F2);
        var am = x.F1 - m;
        var bm = x.F2 - m;
        x.Signi = Configuration.GetSignificance(am, sum).Calculate(bm, m);
        data[i] = x;
      });

      _dataTable.BeginLoadData();
      foreach (var x in data)
        _dataTable.Rows.Add(x.NGram, x.F1, x.F1Rel, x.F2, x.F2Rel, x.F12, x.Signi);
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
        return block.NGramFrequency.ToDictionary(x => x.Key, x => (double)x.Value);
      }
      else
      {
        var block = selection.CreateBlock<Ngram1LayerBlock>();
        block.NGramSize = NGramSize;
        block.LayerDisplayname = LayerDisplayname;
        block.Calculate();
        return block.NGramFrequency.ToDictionary(x => x.Key, x => (double)x.Value);
      }
    }
  }
}