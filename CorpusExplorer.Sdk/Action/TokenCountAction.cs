using System.Data;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class TokenCountAction : IAction
  {
    public string Action => "how-many-tokens";
    public string Description => "how-many-tokens - sum of all tokens";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var dt = new DataTable();
      dt.Columns.Add("param", typeof(string));
      dt.Columns.Add("value", typeof(double));

      dt.BeginLoadData();
      dt.Rows.Add("tokens", (double) selection.CountToken);
      dt.EndLoadData();

      writer.WriteTable(selection.Displayname, dt);
    }
  }
}