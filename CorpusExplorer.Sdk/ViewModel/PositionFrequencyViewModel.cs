using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class PositionFrequencyViewModel : AbstractViewModel, IProvideDataTable
  {
    public string[] LayerQueries { get; set; }
    public string LayerDisplayname { get; set; } = "Wort";

    public Dictionary<string, Tuple<int, int, int[], int[], int, int, int>> Positions { get; set; }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(LayerDisplayname, typeof(string));
      dt.Columns.Add("Erste Position", typeof(int));
      dt.Columns.Add("Summe Links", typeof(int));
      var first = Positions.First();
      for (var i = 0; i < first.Value.Item3.Length; i++)
        dt.Columns.Add((i - first.Value.Item3.Length).ToString(), typeof(int));
      for (var i = 0; i < first.Value.Item4.Length; i++)
        dt.Columns.Add((i + 1).ToString(), typeof(int));
      dt.Columns.Add("Summe Rechts", typeof(int));
      dt.Columns.Add("Letzte Position", typeof(int));
      dt.Columns.Add("Summe Rechts - Links", typeof(int));
      dt.Columns.Add("Summe", typeof(int));

      dt.BeginLoadData();

      foreach (var position in Positions)
      {
        var row = new List<object> {position.Key, position.Value.Item1, position.Value.Item2};
        row.AddRange(position.Value.Item3.Select(x => (object) x));
        row.AddRange(position.Value.Item4.Select(x => (object) x));
        row.AddRange(new object[]
        {
          position.Value.Item5, position.Value.Item6, position.Value.Item5 - position.Value.Item2, position.Value.Item7
        });
        dt.Rows.Add(row.ToArray());
      }

      dt.EndLoadData();
      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<PositionFrequencyBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.LayerQueries = LayerQueries;
      block.Calculate();

      Positions = block.Positions;
    }

    protected override bool Validate()
    {
      return LayerQueries != null && !string.IsNullOrEmpty(LayerDisplayname);
    }
  }
}