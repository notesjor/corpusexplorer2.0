using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CooccurrenceCrossViewModel : AbstractViewModel, IProvideDataTable
  {
    public string LayerDisplayname { get; set; } = "Wort";

    public IEnumerable<string> LayerValues { get; set; }

    public List<Tuple<string, string, double, double>> CrossCooccurences;

    public bool EnableExternalCooccurrencesFilter { get; set; } = true;

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CooccurrenceCrossBlock>();
      block.EnableExternalCooccurrencesFilter = EnableExternalCooccurrencesFilter;
      block.LayerDisplayname = LayerDisplayname;
      block.LayerValues = LayerValues;
      block.Calculate();

      CrossCooccurences = block.CrossCooccurences;
    }

    protected override bool Validate()
      => !string.IsNullOrEmpty(LayerDisplayname) && LayerValues != null;

    public DataTable GetDataTable()
    {
      var dt = new DataTable();

      dt.Columns.Add(Resources.Cooccurrence + " (A)", typeof(string));
      dt.Columns.Add(Resources.Cooccurrence + " (B)", typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));
      dt.Columns.Add(Resources.Significance, typeof(double));

      dt.BeginLoadData();

      foreach (var cross in CrossCooccurences)
        dt.Rows.Add(cross.Item1, cross.Item2, cross.Item3, cross.Item4);

      dt.EndLoadData();

      return dt;
    }
  }
}
