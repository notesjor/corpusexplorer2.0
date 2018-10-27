using System.Data;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class LayerNamesAction : IAction
  {
    public string Action => "layer-names";
    public string Description => "layer-names - all available names for [LAYER]";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var dt = new DataTable();
      dt.Columns.Add("layernames", typeof(string));

      dt.BeginLoadData();
      foreach (var x in selection.LayerDisplaynames)
        dt.Rows.Add(x);
      dt.EndLoadData();

      writer.WriteTable(selection.Displayname, dt);
    }
  }
}