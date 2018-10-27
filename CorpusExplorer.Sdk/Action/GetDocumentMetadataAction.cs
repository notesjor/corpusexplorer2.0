using System;
using System.Data;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class GetDocumentMetadataAction : IAction
  {
    public string Action => "get-document-metadata";
    public string Description => "get-document-metadata [GUID] - get all metadata for specific [GUID] document.";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args == null || args.Length != 1)
        return;

      var guid = Guid.Parse(args[0]);
      if (!selection.ContainsDocument(guid))
        return;

      var columns = selection.GetDocumentMetadata(guid);

      var dt = new DataTable();
      dt.Columns.Add("category", typeof(string));
      dt.Columns.Add("value", typeof(string));

      dt.BeginLoadData();
      dt.Rows.Add("GUID", args[0]);
      foreach (var pair in columns)
        dt.Rows.Add(pair.Key, pair.Value.ToString());

      dt.EndLoadData();

      writer.WriteTable(selection.Displayname, dt);
    }
  }
}