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
  public class Phrases2ViewModel : AbstractViewModel, IProvideDataTable
  {
    public Phrases2ViewModel()
    {
      Layer1Displayname = "Phrase";
      Layer2Displayname = "POS";
      MinimumSize = 1;
    }

    public Dictionary<string, Dictionary<string, double>> Frequency { get; set; }

    public IEnumerable<string> Layer => Selection.LayerUniqueDisplaynames;

    public string Layer1Displayname { get; set; }
    public string Layer2Displayname { get; set; }
    public int MinimumSize { get; set; }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(new DataColumn(Resources.Group, typeof(string)));
      dt.Columns.Add(new DataColumn(Resources.Pattern, typeof(string)));
      dt.Columns.Add(new DataColumn(Resources.Frequency, typeof(int)));

      dt.BeginLoadData();
      foreach (var x in Frequency)
      foreach (var y in x.Value)
        dt.Rows.Add(x.Key, y.Key, y.Value);
      dt.EndLoadData();

      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<FrequencyMasterSlave2LayerBlock>();
      block.Layer1Displayname = Layer1Displayname;
      block.Layer2Displayname = Layer2Displayname;
      block.MinimumSize = MinimumSize;
      block.Calculate();

      Frequency = block.Frequency;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(Layer1Displayname) && !string.IsNullOrEmpty(Layer2Displayname);
    }
  }
}