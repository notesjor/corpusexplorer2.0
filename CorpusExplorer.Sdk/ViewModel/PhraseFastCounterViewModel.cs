using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class PhraseFastCounterViewModel : AbstractViewModel, IProvideDataTable
  {
    public string LayerDisplayname { get; set; } = "Wort";
    public IEnumerable<string[]> LayerQueries { get; set; }
    public Dictionary<string, double> Frequency { get; private set; }
    public bool AutoSplitLayerQuieresWithSpace { get; set; } = true;

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("Phrase", typeof(string));
      dt.Columns.Add("Frequenz", typeof(int));

      dt.BeginLoadData();
      foreach (var x in Frequency)
        dt.Rows.Add(x.Key, x.Value);

      dt.EndLoadData();
      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<PhraseFastCounterBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.LayerQueries = AutoSplitLayerQuieresWithSpace ? LayerQueries.Select(x => x.Select(y => y.Split(' ')).SelectMany(y => y).ToArray()).ToArray() : LayerQueries;
      block.Calculate();

      Frequency = block.Frequency;
    }

    protected override bool Validate()
    {
      return LayerQueries != null && LayerQueries.Any();
    }
  }
}
