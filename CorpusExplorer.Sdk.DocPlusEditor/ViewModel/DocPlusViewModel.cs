#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Xml.Dpxc.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Meta;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.ViewModel
{
  public class DocPlusViewModel
  {
    public DocPlusViewModel() => Corpus = new DocPlusCorpus();

    private DocPlusCorpus Corpus { get; set; }

    private DataTable DataTable
    {
      get
      {
        var res = new DataTable();

        var columns = MetadataSchema.Where(x => x.Key != "Text").ToDictionary(x => x.Key, x => x.Value);
        foreach (var c in columns)
          res.Columns.Add(c.Key, c.Value);

        res.BeginLoadData();
        foreach (var doc in Corpus.Documents)
        {
          var cells = new List<object>();
          foreach (var c in columns)
            if (doc.ContainsKey(c.Key))
              cells.Add(doc[c.Key]);
            else
              try
              {
                cells.Add(c.Value == typeof(DateTime) ? DateTime.MinValue : Activator.CreateInstance(c.Value));
              }
              catch
              {
                cells.Add(string.Empty);
              }

          res.Rows.Add(cells.ToArray());
        }

        res.EndLoadData();
        return res;
      }
    }

    public Dictionary<string, object> DocumentCurrent => Corpus.Documents[Index];

    public int DocumentsCount => Corpus.Documents.Count;

    public int Index { get; set; }

    public Dictionary<string, Type> MetadataSchema => Corpus.MetadataSchema;

    public void AddProperty(KeyValuePair<string, Type> newMeta)
    {
      Corpus.MetadataSchema.Add(newMeta.Key, newMeta.Value);
      Corpus.ApplyMetadataSchema();
    }

    public void ApplyAutoFixes(List<AbstractAutoFix> fixes)
    {
      if (fixes == null || fixes.Count == 0)
        return;

      foreach (var fix in fixes)
        switch (fix)
        {
          case AbstractCastMetaAutoFix f:
            {
              var docs = Corpus.Documents;
              f.Apply(ref docs);
              Corpus.Documents = docs;
              break;
            }
          case AbstractMetaAutoFix f:
            {
              var docs = Corpus.Documents;
              f.Apply(ref docs);
              Corpus.Documents = docs;
              break;
            }
          case AbstractTextAutoFix f when f.ApplyOnCompleteCorpus:
            {
              var docs = Corpus.Documents;
              f.Apply(ref docs);
              Corpus.Documents = docs;
              break;
            }
          case AbstractTextAutoFix f:
            {
              var doc = new List<Dictionary<string, object>> { DocumentCurrent };
              f.Apply(ref doc);
              Corpus.Documents[Index] = doc[0];
              break;
            }
          default:
            {
              var docs = Corpus.Documents;
              fix.Apply(ref docs);
              Corpus.Documents = docs;
              Corpus.ReloadSchema();
              break;
            }
        }
    }

    private static DocPlusCorpus Clean(DocPlusCorpus corpus)
    {
      corpus.Documents =
        corpus.Documents.Where(d => d.ContainsKey("Text") && !string.IsNullOrEmpty(d["Text"] as string)).ToList();
      return corpus;
    }

    public void DocumentAdd()
    {
      Corpus.AddDocument();
      Index = Corpus.Documents.Count - 1;
    }

    public void DocumentAdd(Dictionary<string, object> doc)
    {
      var info = Corpus.MetadataSchema;
      var types = new Dictionary<string, Type>();

      Corpus.Documents.Add(doc);

      foreach (var x in doc.Where(x => !info.ContainsKey(x.Key)))
        if (types.ContainsKey(x.Key))
        {
          if (types[x.Key] == typeof(object) && x.Value != null)
            types[x.Key] = x.Value.GetType();
        }
        else
        {
          types.Add(x.Key, x.Value == null ? typeof(object) : x.Value.GetType());
        }

      foreach (var x in types.Where(x => !Corpus.MetadataSchema.ContainsKey(x.Key)))
        Corpus.MetadataSchema.Add(x.Key, x.Value);
    }

    public void DocumentAddRange(IEnumerable<Dictionary<string, object>> docs)
    {
      foreach (var doc in docs)
        DocumentAdd(doc);
    }

    public void DocumentNext()
    {
      Index++;
      if (Index >= Corpus.Documents.Count)
        Index = 0;
    }

    public void DocumentPreview()
    {
      Index--;
      if (Index < 0)
        Index = Corpus.Documents.Count - 1;
    }

    public ConcurrentQueue<Dictionary<string, object>> DocumentsAll() =>
      new ConcurrentQueue<Dictionary<string, object>>(Corpus.Documents);

    public void Export(string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        var tableWriter = new TsvTableWriter { OutputStream = fs };
        tableWriter.WriteTable(DataTable);
        tableWriter.Destroy();
      }
    }

    public void Import(string path)
    {
      var scraper = new TsvScraper();
      scraper.Input.Enqueue(path);
      scraper.Execute();

      if (scraper.Output == null)
        return;

      var openRefineData = scraper.Output.ToArray();
      var schema = MetadataSchema;

      foreach (var orDoc in openRefineData)
      {
        if (!orDoc.ContainsKey("GUID") || !(orDoc["GUID"] is Guid))
          continue;

        var cGuid = orDoc["GUID"].ToString();

        var match = -1; // Index für passendes Dokument im Korpus
        for (var i = 0; i < Corpus.Documents.Count; i++) // Finde passendes Dokument im Korpus
        {
          var tmp = Corpus.Documents[i];
          if (!tmp.ContainsKey("GUID") || tmp["GUID"].ToString() != cGuid)
            continue;
          match = i;
          break;
        }

        if (match == -1)
          continue;

        var doc = new Dictionary<string, object>();
        doc.Add("Text", Corpus.Documents[match]["Text"]);
        doc.Add("GUID", Corpus.Documents[match]["GUID"]);

        foreach (var pair in orDoc.Where(pair => pair.Key != "GUID" && pair.Key != "Text"))
        {
          object value;
          if (schema.ContainsKey(pair.Key)) // Caste Datentypen wenn notwendig
          {
            if (schema[pair.Key] == typeof(int))
              value = IntCastMetaAutoFix.Cast(pair.Value);
            else if (schema[pair.Key] == typeof(double))
              value = DoubleCastMetaAutoFix.Cast(pair.Value);
            else if (schema[pair.Key] == typeof(DateTime))
              value = DateTimeCastMetaAutoFix.Cast(pair.Value);
            else if (schema[pair.Key] == typeof(bool))
              value = BooleanCastMetaAutoFix.Cast(pair.Value);
            else
              value = pair.Value;
          }
          else
          {
            value = pair.Value;
          }

          if (doc.ContainsKey(pair.Key)) // Schreibe Daten
            doc[pair.Key] = value;
          else
            doc.Add(pair.Key, pair.Value);
        }

        Corpus.Documents[match] = doc;
      }
      Corpus.ReloadSchema();
    }

    public static DocPlusViewModel Load(string path)
    {
      // Achtung: Änderungen müssen auch in CorpusExplorer.Sdk.Extern.Xml.Dpxc.DpxcScraper übernommen werden.
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (var bs = new BufferedStream(fs))
        {
          var bf = new NetDataContractSerializer();
          var res = new DocPlusViewModel { Corpus = bf.Deserialize(bs) as DocPlusCorpus };
          res.Corpus = Clean(res.Corpus);
          return res;
        }
      }
      catch
      {
        return new DocPlusViewModel();
      }
    }

    public static DocPlusViewModel LoadRawData(string path)
    {
      try
      {
        var docs = Serializer.Deserialize<IEnumerable<Dictionary<string, object>>>(path);
        if (docs == null)
          return new DocPlusViewModel();

        var res = new DocPlusViewModel();
        res.DocumentAddRange(docs);

        return res;
      }
      catch
      {
        return new DocPlusViewModel();
      }
    }

    public void Save(string path)
    {
      Corpus = Clean(Corpus);
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        using (var bs = new BufferedStream(fs))
        {
          var dcs = new NetDataContractSerializer();
          dcs.Serialize(bs, Corpus);
        }
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }

    public void SaveDocument(Dictionary<string, object> document)
    {
      if (document != null)
        Corpus.Documents[Index] = document;
    }

    public int SearchJump(string query)
    {
      query = query.ToLower();
      var searching = true;
      var sindex = Index;

      do
      {
        DocumentNext();
        if (Index == sindex)
          return -1;
        try
        {
          if (((string)Corpus.Documents[Index]["Text"]).ToLower().Contains(query))
            searching = false;
        }
        catch
        {
          // ignore
        }
      } while (searching);

      return sindex;
    }
  }
}