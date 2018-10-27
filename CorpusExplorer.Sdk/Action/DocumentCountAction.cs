using System.Data;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class DocumentCountAction : IAction
  {
    public string Action => "how-many-documents";
    public string Description => "how-many-documents - sum of all documents";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var dt = new DataTable();
      dt.Columns.Add("param", typeof(string));
      dt.Columns.Add("value", typeof(double));

      dt.BeginLoadData();
      dt.Rows.Add("documents", (double) selection.CountDocuments);
      dt.EndLoadData();

      writer.WriteTable(selection.Displayname, dt);
    }
  }
}