using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class LayerValuesAction : IAction
  {
    public string Action => "get-types";
    public string Description => "get-types [LAYER] - list all [LAYER]-values (types)";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args == null || args.Length == 0)
        return;

      var dt = new DataTable();
      dt.Columns.Add("type", typeof(string));

      var values = new HashSet<string>(selection.GetLayers(args[0]).SelectMany(layer => layer.Values));
      dt.BeginLoadData();
      foreach (var value in values)
        dt.Rows.Add(value);
      dt.EndLoadData();

      writer.WriteTable(selection.Displayname, dt);
    }
  }
}