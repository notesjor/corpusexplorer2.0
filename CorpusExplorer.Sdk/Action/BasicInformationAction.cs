using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class BasicInformationAction : IAction
  {
    public string Action => "basic-information";
    public string Description => "basic-information - basic information tokens/sentences/documents";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var token = (double)selection.CountToken;
      var documents = (double)selection.CountDocuments;
      var sentences = (double)selection.CountSentences;

      var dt = new DataTable();
      dt.Columns.Add("param", typeof(string));
      dt.Columns.Add("value", typeof(double));

      dt.BeginLoadData();
      dt.Rows.Add("tokens", token);
      dt.Rows.Add("token-factor", 1000000.0 / token);
      dt.Rows.Add("sentences", sentences);
      dt.Rows.Add("documents", documents);

      try
      {
        var types = selection.GetLayerValues("Wort").Count();
        dt.Rows.Add("types", types);
        dt.Rows.Add("TTR (type/token-ratio)", types / token);
        dt.Rows.Add("TSR (type/sentence-ratio)", types / sentences);
        dt.Rows.Add("TDR (type/document-ratio)", types / documents);
      }
      catch
      {
        // ignore
      }

      dt.Rows.Add("ToSR (token/sentence-ratio)", token / sentences);
      dt.Rows.Add("ToDR (token/document-ratio)", token / documents);
      dt.Rows.Add("SDR (sentence/document-ratio)", sentences / documents);

      dt.EndLoadData();

      writer.WriteTable(selection.Displayname, dt);
    }
  }
}