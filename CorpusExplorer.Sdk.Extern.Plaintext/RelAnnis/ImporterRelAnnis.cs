using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis
{
  public class ImporterRelAnnis : AbstractImporterBase
  {
    private HashSet<string> _ending = new HashSet<string> { ".", "!", "?", ":", ";" };

    protected override void ExecuteCall(string path)
    {
      var dir = Path.GetDirectoryName(path);

      var docIds = GetMetadata(path);
      var position = GetWordLayer(path, docIds, out var templates);
      GetAnnotations(path, docIds, position, templates);
    }

    private void GetAnnotations(string path, Dictionary<int, Guid> docIds, Dictionary<int, Tuple<Guid, int, int>> position, Dictionary<int, int[]> templates)
    {
      using (var fs = new FileStream(Path.Combine(path, "node_annotation.tab"), FileMode.Open, FileAccess.Read))
      using (var read = new StreamReader(fs, Configuration.Encoding))
        while (!read.EndOfStream)
        {

        }
    }

    private Dictionary<int, Tuple<Guid, int, int>> GetWordLayer(string path, Dictionary<int, Guid> docIds,
                                                                out Dictionary<int, int[]> templates)
    {
      templates = new Dictionary<int, int[]>();
      var res = new Dictionary<int, Tuple<Guid, int, int>>();

      var dId_last = -1;
      var sentence = new List<string>();
      var doc = new List<string[]>();

      using (var fs = new FileStream(Path.Combine(path, "node.tab"), FileMode.Open, FileAccess.Read))
      using (var read = new StreamReader(fs, Configuration.Encoding))
        while (!read.EndOfStream)
        {
          var items = read.ReadLine().Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
          if (items.Length < 5)
            continue;
          if (items[3] != "token")
            continue;

          var tId = int.Parse(items[0]);
          //var dId = items[1];
          var token = items.Last();

          var dId_current = int.Parse(items[1]); // ist bereits nullbasiert

          if (dId_current != dId_last)
          {
            if (sentence.Count > 0)
              doc.Add(sentence.ToArray());

            if (dId_last != -1)
            {
              AddDocument("Wort", docIds[dId_last], doc.ToArray());
              templates.Add(dId_last, doc.Select(x => x.Length).ToArray());
            }

            dId_last = dId_current;

            sentence.Clear();
            doc.Clear();
          }

          res.Add(tId, new Tuple<Guid, int, int>(docIds[dId_last], doc.Count, sentence.Count));
          sentence.Add(token);

          if (!_ending.Contains(token)) 
            continue;

          if (sentence.Count > 0)
            doc.Add(sentence.ToArray());

          sentence.Clear();
        }

      return res;
    }

    private Dictionary<int, Guid> GetMetadata(string path)
    {
      var dId_last = -1;
      var meta = new Dictionary<string, object>();
      var res = new Dictionary<int, Guid>();

      using (var fs = new FileStream(Path.Combine(path, "corpus_annotation.tab"), FileMode.Open, FileAccess.Read))
      using (var read = new StreamReader(fs, Configuration.Encoding))
        while (!read.EndOfStream)
        {
          var items = read.ReadLine().Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
          if (items.Length != 4)
            continue;

          var dId_current = int.Parse(items[0]) - 1; // muss als nullbasiert werden

          if (dId_current != dId_last)
          {
            var guid = Guid.NewGuid();
            res.Add(dId_current, guid);

            if (dId_last != -1)
              AddDocumentMetadata(res[dId_last], meta);

            dId_last = dId_current;
            meta = new Dictionary<string, object> { { "GUID", guid } };
          }

          var key = items[3];
          if (meta.ContainsKey(key))
            meta[key] = items[4];
          else
            meta.Add(key, items[4]);
        }

      AddDocumentMetadata(res[dId_last], meta);
      return res;
    }
  }
}
