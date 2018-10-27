using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class TypeCountAction : IAction
  {
    public string Action => "how-many-types";
    public string Description => "how-many-types [LAYER] - sum of all [LAYER]-values (types)";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args == null || args.Length == 0)
        return;

      var dt = new DataTable();
      dt.Columns.Add("param", typeof(string));
      dt.Columns.Add("value", typeof(double));

      dt.BeginLoadData();
      dt.Rows.Add("types",
                  (double) new HashSet<string>(selection.GetLayers(args[0]).SelectMany(layer => layer.Values)).Count);
      dt.EndLoadData();

      writer.WriteTable(selection.Displayname, dt);
    }
  }
}