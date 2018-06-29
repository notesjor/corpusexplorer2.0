using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DocumentMetadataViewModel : AbstractViewModel
  {
    private string[] _columns;
    public DataTable DataTable { get; set; }

    public void AddMetaEntry(string metaName, Type metaType)
    {
      Selection.SetNewDocumentMetadata(metaName, metaType);
    }

    public void Export(string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        var tableWriter = new TsvTableWriter {OutputStream = fs};
        tableWriter.WriteTable(DataTable);
      }
    }

    public void Import(string path)
    {
      var scraper = new TsvScraper();
      scraper.Input.Enqueue(path);
      scraper.Execute();

      if (scraper.Output == null)
        return;

      var test = new HashSet<Guid>(Selection.DocumentGuids);
      foreach (var x in scraper.Output)
        try
        {
          if (!x.ContainsKey("GUID") || !(x["GUID"] is Guid))
            continue;

          var guid = (Guid) x["GUID"];
          if (guid == Guid.Empty || !test.Contains(guid))
            continue;

          var meta = x;
          meta.Remove("GUID");
          Selection.SetDocumentMetadata(guid, meta);
        }
        catch
        {
          // ignore
        }
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

    protected override bool Validate()
    {
      return true;
    }
  }
}