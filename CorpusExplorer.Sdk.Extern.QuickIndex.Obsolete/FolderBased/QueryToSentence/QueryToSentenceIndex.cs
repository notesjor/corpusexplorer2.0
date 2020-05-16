using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.QuickIndex.Helper;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace CorpusExplorer.Sdk.Extern.QuickIndex.FolderBased.QueryToSentence
{
  [Serializable]
  public class QueryToSentenceIndex
  {
    private const string CEEXT = ".ceidx";
    private string _path;
    internal Dictionary<string, Dictionary<Guid, int[]>> SentenceDictionary;

    private QueryToSentenceIndex()
    {
    }

    public static QueryToSentenceIndex Open(string path)
    {
      return new QueryToSentenceIndex { _path = path };
    }

    internal static Dictionary<string, Dictionary<Guid, int[]>> Create(AbstractCorpusAdapter corpus, string layerDisplayname)
    {
      var layer = corpus.GetLayers(layerDisplayname).Single();
      var sent = new Dictionary<string, Dictionary<Guid, int[]>>();
      var lsen = new object();

      Parallel.ForEach(layer.DocumentGuids, dsel =>
      {
        var doc = layer[dsel];
        if (doc == null)
          return;

        var temp1 = new Dictionary<string, HashSet<int>>();
        for (var i = 0; i < doc.Length; i++)
        {
          foreach (var idx in doc[i])
          {
            var w = FileNameHelper.EnsureFileName(layer[idx]);
            if(w.Contains(" "))
              continue;

            if (temp1.ContainsKey(w))
              temp1[w].Add(i);
            else
              temp1.Add(w, new HashSet<int> { i });
          }
        }

        var temp2 = temp1.ToDictionary(x => x.Key, x => x.Value.ToArray());

        lock (lsen)
        {
          foreach (var x in temp2)
          {
            if (sent.ContainsKey(x.Key))
              sent[x.Key].Add(dsel, x.Value);
            else
              sent.Add(x.Key, new Dictionary<Guid, int[]> { { dsel, x.Value } });
          }
        }
      });

      return sent;
    }

    public static void Create(AbstractCorpusAdapter corpus, string layerDisplayname, string outputDirectory) 
      => StoreIndex(outputDirectory, Create(corpus, layerDisplayname));

    internal static void StoreIndex(string outputDirectory, Dictionary<string, Dictionary<Guid, int[]>> data)
    {
      if (!Directory.Exists(outputDirectory))
        Directory.CreateDirectory(outputDirectory);

      foreach (var entry in data)
        Serializer.Serialize(entry.Value, Path.Combine(outputDirectory, entry.Key + CEEXT), false);
    }

    public Dictionary<Guid, int[]> Search(string query)
    {
      try
      {
        var path = Path.Combine(_path, FileNameHelper.EnsureFileName(query) + CEEXT);
        return File.Exists(path) ? Serializer.Deserialize<Dictionary<Guid, int[]>>(path) : null;
      }
      catch
      {
        return new Dictionary<Guid, int[]>();
      }
    }
  }
}
