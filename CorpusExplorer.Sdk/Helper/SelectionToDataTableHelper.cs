using System.Data;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public static class SelectionToDataTableHelper
  {
    public static DataTable GetDocumentGuidAndDisplaynamesAsDataTable(this Selection selection)
    {
      var dt = new DataTable();
      dt.Columns.Add("GUID", typeof(string));
      dt.Columns.Add("display-name", typeof(string));

      dt.BeginLoadData();
      foreach (var pair in selection.DocumentGuidsAndDisplaynames)
        dt.Rows.Add(pair.Key.ToString("N"), pair.Value);

      dt.EndLoadData();
      return dt;
    }
  }
}