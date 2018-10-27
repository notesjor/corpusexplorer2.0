using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action
{
  public class CooccurrenceSelectedAction : IAction
  {
    public string Action => "cooccurrence-select";

    public string Description =>
      "cooccurrence-select [LAYER] [WORDS] - significant cooccurrences for all [LAYER] values.";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args == null || args.Length < 2)
        return;

      var vm = new CooccurrenceSelectiveViewModel
      {
        Selection = selection,
        LayerDisplayname = args[0]
      };

      var res = new Dictionary<string, Dictionary<string, double[]>>();
      for (var i = 1; i < args.Length; i++)
      {
        vm.LayerQueries = new[] {args[i]};
        vm.Execute();

        res.Add(args[i], vm.FrequencySignificanceDictionary);
      }

      var tbl = new DataTable();
      tbl.Columns.Add("Zeichenkette", typeof(string));
      tbl.Columns.Add("Kookkurrenz", typeof(string));
      tbl.Columns.Add("Frequenz", typeof(double));
      tbl.Columns.Add("Signifikanz", typeof(double));

      tbl.BeginLoadData();
      foreach (var e in res)
      foreach (var v in e.Value)
        tbl.Rows.Add(e.Key, v.Key, v.Value[0], v.Value[1]);

      tbl.EndLoadData();

      writer.WriteTable(selection.Displayname, tbl);
    }
  }
}