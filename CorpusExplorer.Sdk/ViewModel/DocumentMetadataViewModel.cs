using System;
using System.Data;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DocumentMetadataViewModel : AbstractViewModel
  {
    private string[] _columns;
    public DataTable DataTable { get; set; }

    public void AddMetaEntry(string metaName, Type metaType) { Selection.SetNewDocumentMetadata(metaName, metaType); }

    protected override void ExecuteAnalyse()
    {
      DataTable = new DataTable();

      var prototype = Selection.GetDocumentMetadataPrototypeOnlyProperties();
      _columns = prototype.Where(x => x != "GUID").ToArray();

      foreach (var c in _columns)
        DataTable.Columns.Add(c);
      DataTable.Columns.Add("GUID");

      DataTable.BeginLoadData();
      foreach (var guid in Selection.DocumentGuids)
      {
        var meta = Selection.GetDocumentMetadata(guid);
        if (meta == null)
          continue;

        if (!meta.ContainsKey("GUID"))
          meta.Add("GUID", guid);

        var cells = _columns.Select(column => meta.ContainsKey(column) ? meta[column] : null).ToList();
        cells.Add(meta["GUID"]);

        DataTable.Rows.Add(cells.ToArray());
      }
      DataTable.EndLoadData();

      DataTable.Columns["GUID"].ReadOnly = true;
    }

    public void Replace(string query, string replacement)
    {
      foreach (DataRow row in DataTable.Rows)
      foreach (var column in _columns.Where(column => row[column].ToString() == query))
        row[column] = replacement;
    }

    public void Save()
    {
      if (DataTable == null)
        return;

      foreach (DataRow row in DataTable.Rows)
        Selection.SetDocumentMetadata(
          Guid.Parse(row["GUID"].ToString()),
          _columns.ToDictionary(c => c, c => row[c]));
    }

    protected override bool Validate() { return true; }

    public void Export(string path)
    {
      FileIO.Write(path, DataTable.ToCsv(), Configuration.Encoding);
    }

    public void Import(string path)
    {
      var lines = FileIO.ReadLines(path, Configuration.Encoding);
      var columns = lines[0].Split(new[] {"\t"}, StringSplitOptions.RemoveEmptyEntries);
      
    }
  }
}