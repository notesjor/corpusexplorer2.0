using System.Data;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class SentenceCountAction : IAction
  {
    public string Action => "how-many-sentences";
    public string Description => "how-many-sentences - sum of all sentences";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var dt = new DataTable();
      dt.Columns.Add("param", typeof(string));
      dt.Columns.Add("value", typeof(double));

      dt.BeginLoadData();
      dt.Rows.Add("sentences", (double) selection.CountSentences);
      dt.EndLoadData();

      writer.WriteTable(selection.Displayname, dt);
    }
  }
}