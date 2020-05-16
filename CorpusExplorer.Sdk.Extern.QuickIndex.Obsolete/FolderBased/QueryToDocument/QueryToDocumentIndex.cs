using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.QuickIndex.Helper;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace CorpusExplorer.Sdk.Extern.QuickIndex.FolderBased.QueryToDocument
{
  [Serializable]
  public class QueryToDocumentIndex
  {
    private const string CEEXT = ".ceidx";
    private string _path;
    internal Dictionary<string, Guid[]> DocumentDictionary;

    private QueryToDocumentIndex()
    {
    }

    public static QueryToDocumentIndex Open(string path)
    {
      return new QueryToDocumentIndex { _path = path };
    }

    internal static Dictionary<string, Guid[]> Create(AbstractCorpusAdapter corpus, string layerDisplayname)
    {
      var layer = corpus.GetLayers(layerDisplayname).Single();
      var doct = new Dictionary<string, List<Guid>>();
      var lsen = new object();

      Parallel.ForEach(layer.DocumentGuids, dsel =>
      {
        var doc = layer[dsel];
        if (doc == null)
          return;

        var temp = new HashSet<string>();
        foreach (var s in doc)
          foreach (var w in s)
          {
            var token = layer[w];
            if (token.Contains(" "))
              continue;
            temp.Add(FileNameHelper.EnsureFileName(token));
          }

        lock (lsen)
        {
          foreach (var x in temp)
          {
            if (doct.ContainsKey(x))
              doct[x].Add(dsel);
            else
              doct.Add(x, new List<Guid> { dsel });
          }
        }
      });

      return doct.ToDictionary(x => x.Key, x => x.Value.ToArray());
    }

    public static void Create(AbstractCorpusAdapter corpus, string layerDisplayname, string outputDirectory)
      => StoreIndex(outputDirectory, Create(corpus, layerDisplayname));

    internal static void StoreIndex(string outputDirectory, Dictionary<string, Guid[]> store)
    {
      if (!Directory.Exists(outputDirectory))
        Directory.CreateDirectory(outputDirectory);

      foreach (var entry in store)
        Serializer.Serialize(entry.Value, Path.Combine(outputDirectory, entry.Key + CEEXT), false);
    }

    public Guid[] Search(string query)
    {
      try
      {
        var path = Path.Combine(_path, FileNameHelper.EnsureFileName(query) + CEEXT);
        return File.Exists(path) ? Serializer.Deserialize<Guid[]>(path) : null;
      }
      catch
      {
        return new Guid[0];
      }
    }
  }
}
