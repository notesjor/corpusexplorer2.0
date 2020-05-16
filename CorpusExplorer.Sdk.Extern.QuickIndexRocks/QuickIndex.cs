#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Db.RocksDb;
using CorpusExplorer.Sdk.Extern.QuickIndexRocks.Indices;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Layer;

#endregion

namespace CorpusExplorer.Sdk.Extern.QuickIndexRocks
{
  public class QuickIndex : IDisposable
  {
    private EasyRocksDb _dic;
    private EasyRocksDb _dicRes;
    private Dictionary<long, Guid> _fixRes;
    private EasyRocksDb _meta;
    private readonly string[] _emptyMark = { "[...]" };

    /// <summary>
    /// Erstellt ein neues QuickIndex-Objekt.
    /// Wurde zurvor für das Korpus und den gewählten Layer kein QuickIndex erstellt, dann wird der QuickIndex automatisch erzeugt.
    /// Exsistiert der QuickIndex bereits, wird er geladen.
    /// </summary>
    /// <param name="pathToCec6">Pfad zur CEC6-Datei. Muss bereits exsistieren. Die CEC6-Datei beleibt erhalten.</param>
    /// <param name="layerDisplayname">Layer für den der QuickIndex gelöscht werden soll.</param>
    public QuickIndex(string pathToCec6, string layerDisplayname = "Wort")
    {
      if (!Directory.Exists($"{pathToCec6}_{layerDisplayname}.idxmrRDB"))
        Create(pathToCec6, layerDisplayname);

      PathToCec6 = pathToCec6;
      LayerDisplayname = layerDisplayname;

      try
      {
        Read(pathToCec6, layerDisplayname);
      }
      catch
      {
        Create(pathToCec6, layerDisplayname);
        Read(pathToCec6, layerDisplayname);
      }
    }

    private void Read(string pathToCec6, string layerDisplayname)
    {
      var dic = DictionaryIndex.Read(pathToCec6, layerDisplayname);
      _dic = dic[0];
      _dicRes = dic[1];

      _fixRes = Cec6FileIndex.Read(pathToCec6, layerDisplayname).ToDictionary(x => x.Value, x => x.Key);
      _meta = InverseIndex.Read(pathToCec6, layerDisplayname);
    }

    public string PathToCec6 { get; }
    public string LayerDisplayname { get; }

    /// <summary>
    /// Löscht einen bestehende QuickIndex
    /// </summary>
    /// <param name="pathToCec6">Pfad zur CEC6-Datei. Muss bereits exsistieren. Die CEC6-Datei beleibt erhalten.</param>
    /// <param name="layerDisplayname">Layer für den der QuickIndex gelöscht werden soll.</param>
    public static void Delete(string pathToCec6, string layerDisplayname)
    {
      if (Directory.Exists($"{pathToCec6}_{layerDisplayname}.idxmrRDB"))
        Directory.Delete($"{pathToCec6}_{layerDisplayname}.idxmrRDB", true);
      if (File.Exists($"{pathToCec6}_{layerDisplayname}.idx"))
        File.Delete($"{pathToCec6}_{layerDisplayname}.idx");
      if (File.Exists($"{pathToCec6}_{layerDisplayname}.fif"))
        File.Delete($"{pathToCec6}_{layerDisplayname}.fif");
      if (File.Exists($"{pathToCec6}_{layerDisplayname}.fi"))
        File.Delete($"{pathToCec6}_{layerDisplayname}.fi");
      if (Directory.Exists($"{pathToCec6}_{layerDisplayname}.dicRDB"))
        Directory.Delete($"{pathToCec6}_{layerDisplayname}.dicRDB", true);
      if (Directory.Exists($"{pathToCec6}_{layerDisplayname}.dicrRDB"))
        Directory.Delete($"{pathToCec6}_{layerDisplayname}.dicrRDB", true);
    }

    /// <summary>
    /// Erstellt einen neuen QuickIndex
    /// </summary>
    /// <param name="pathToCec6">Pfad zur CEC6-Datei. Muss bereits exsistieren.</param>
    /// <param name="layerDisplayname">Layer für den der QuickIndex erstellt werden soll.</param>
    private static void Create(string pathToCec6, string layerDisplayname = "Wort")
    {
      var corpus = CorpusAdapterWriteDirect.Create(pathToCec6);

      if (!(corpus?.GetLayers(layerDisplayname)?.SingleOrDefault() is LayerAdapterWriteDirect layer))
        return;

      DictionaryIndex.Create(layer, pathToCec6);
      InverseIndex.Create(layer, Cec6FileIndex.Create(corpus, pathToCec6, layerDisplayname), pathToCec6);
    }

    /// <summary>
    /// Gibt das Dokument zurück (wird aus der CEC6 ausgelesen).
    /// Verwenden Sie GetIndexDocument(position) um CorpusExplorer Dokument zu erhalten.
    /// </summary>
    /// <param name="position">QuickIndex ID</param>
    /// <returns>Dokument</returns>
    public IEnumerable<IEnumerable<string>> GetDocument(long position)
    {
      return GetIndexDocument(position).Select(s => s.Select(w => _dicRes.Get(position.ToString())));
    }

    /// <summary>
    /// Gibt ein Snippet zurück.
    /// </summary>
    /// <param name="position">QuickIndex ID</param>
    /// <param name="sentenceIndices">Satz ID</param>
    /// <param name="markEmpty">Wenn true, werden fehlende Sätze mit [...] markiert.</param>
    /// <returns>Snippet - 0 = Satz / 1 = Token</returns>
    public IEnumerable<IEnumerable<string>> GetDocumentSnippet(long position, IEnumerable<int> sentenceIndices, bool markEmpty = false)
    {
      var doc = GetIndexDocument(position);
      return doc == null
               ? null
               : markEmpty
                 ? MarkEmpty(sentenceIndices, doc)
                 : sentenceIndices.Select(sI => doc[sI].Select(x => _dicRes.Get(x.ToString())));
    }

    private IEnumerable<IEnumerable<string>> MarkEmpty(IEnumerable<int> sentenceIndices, int[][] doc)
    {
      var arr = sentenceIndices.ToArray();
      var sen = arr.Select(sI => doc[sI].Select(x => _dicRes.Get(x.ToString()))).ToList();
      for (var i = arr.Length; i > 0; i--)
      {
        if (arr[i] + 1 == arr[i])
          continue;

        sen.Insert(i, _emptyMark);
      }
      return sen;
    }

    /// <summary>
    /// Gibt ein einfaches Snippet zurück.
    /// </summary>
    /// <param name="position">QuickIndex ID</param>
    /// <param name="sentenceIndices">Satz ID</param>
    /// <param name="markEmpty">Wenn true, werden fehlende Sätze mit [...] markiert.</param>
    /// <returns>Snippet - Pro Satz ein Element</returns>
    public IEnumerable<string> GetDocumentSnippetSimple(long position, IEnumerable<int> sentenceIndices, bool markEmpty = false)
    {
      return GetDocumentSnippet(position, sentenceIndices, markEmpty).ReduceToSentences();
    }

    /// <summary>
    /// Gibt das Dokument zurück (wird aus der CEC6 ausgelesen).
    /// Verwenden Sie GetDocument(position) um ein direkt lesbares Dokument zu erhalten.
    /// </summary>
    /// <param name="position">QuickIndex ID</param>
    /// <returns>CorpusExplorer Dokument</returns>
    private int[][] GetIndexDocument(long position)
    {
      if (!_fixRes.ContainsKey(position))
        return null;

      using (var fs = new FileStream(PathToCec6 + $"_{LayerDisplayname}.fif", FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        fs.Seek(position, SeekOrigin.Begin);
        return DocumentSerializerHelper.Deserialize(fs);
      }
    }

    /// <summary>
    /// Erlaubt die UMwandlung mehrerer QuickIndex IDs in entsprechende CorpusExplorer GUIDs
    /// </summary>
    /// <param name="positions">QuickIndex IDs</param>
    /// <returns>orpusExplorer GUIDs</returns>
    public IEnumerable<Guid> Resolve(IEnumerable<long> positions)
      => positions.Select(Resolve);

    /// <summary>
    /// Erlaubt die Umwandlung von QuickIndex IDs in CorpusExplorer GUIDs
    /// </summary>
    /// <param name="position">QuickIndex ID</param>
    /// <returns>CorpusExplorer GUID</returns>
    public Guid Resolve(long position)
      => _fixRes[position];

    /// <summary>
    /// Sucht nach einem query/Token.
    /// </summary>
    /// <param name="query">Abfragen - Query - Token</param>
    /// <returns>Key = QuickIndex IDs / Value = Sätze mit Übereinstimmung</returns>
    public Dictionary<long, HashSet<int>> Search(string query)
    {
      try
      {
        return InverseIndex.GetPositions(PathToCec6, LayerDisplayname, long.Parse(_meta.Get(_dic.Get(query))));
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// Sucht nach einem query/Token - inkl. Auflösung der QuickIndex-IDs in CorpusExplorer GUIDs.
    /// </summary>
    /// <param name="query">Abfragen - Query - Token</param>
    /// <returns>Key = CorpusExplorer GUIDs / Value = Sätze mit Übereinstimmung (min. ein query)</returns>
    public Dictionary<Guid, HashSet<int>> SearchResolved(string query)
      => Search(query).ToDictionary(x => _fixRes[x.Key], x => x.Value);

    /// <summary>
    /// Sucht nach allen queries - min. ein Query muss im Dokument vorkommen.
    /// </summary>
    /// <param name="queries">Abfragen - Pro Token ein string-Array-Element</param>
    /// <returns>Key = QuickIndex IDs / Value = Sätze mit Übereinstimmung</returns>
    public Dictionary<long, HashSet<int>> SearchAny(string[] queries)
    {
      var res = Search(queries.First());
      for (var i = 1; i < queries.Length; i++)
      {
        var search = Search(queries[i]);
        foreach (var x in search)
        {
          if (res.ContainsKey(x.Key))
            foreach (var y in x.Value)
              res[x.Key].Add(y);
          else
            res.Add(x.Key, x.Value);
        }
      }

      return res;
    }

    /// <summary>
    /// Sucht nach allen queries - min. ein Query muss im Dokument vorkommen - inkl. Auflösung der QuickIndex-IDs in CorpusExplorer GUIDs.
    /// </summary>
    /// <param name="queries">Abfragen - Pro Token ein string-Array-Element</param>
    /// <returns>Key = CorpusExplorer GUIDs / Value = Sätze mit Übereinstimmung (min. ein query)</returns>
    public Dictionary<Guid, HashSet<int>> SearchAnyResolved(string[] queries)
      => SearchAny(queries).ToDictionary(x => _fixRes[x.Key], x => x.Value);

    /// <summary>
    /// Sucht nach allen queries - alle queries müssen in einem Dokument vorkommen.
    /// </summary>
    /// <param name="queries">Abfragen - Pro Token ein string-Array-Element</param>
    /// <returns>Key = QuickIndex IDs / Value = Sätze mit min. einem Token von der Liste</returns>
    public Dictionary<long, HashSet<int>> SearchAllInOneDocument(string[] queries)
    {
      var res = Search(queries.First());
      if (res == null)
        return null;

      for (var i = 1; i < queries.Length; i++)
      {
        var tmp = new Dictionary<long, HashSet<int>>();
        var search = Search(queries[i]);
        if (search == null)
          return null;

        foreach (var x in res)
        {
          if (!search.ContainsKey(x.Key))
            continue;

          var v = res[x.Key].ToList();
          v.AddRange(search[x.Key]);
          tmp.Add(x.Key, new HashSet<int>(v));
        }

        res = tmp;
      }

      return res;
    }

    /// <summary>
    /// Sucht nach allen queries - alle queries müssen in einem Dokument vorkommen - inkl. Auflösung der QuickIndex-IDs in CorpusExplorer GUIDs.
    /// </summary>
    /// <param name="queries">Abfragen - Pro Token ein string-Array-Element</param>
    /// <returns>Key = CorpusExplorer GUIDs / Value = Sätze mit Übereinstimmung (min. ein query)</returns>
    public Dictionary<Guid, HashSet<int>> SearchAllInOneDocumentResolved(string[] queries)
      => SearchAllInOneDocument(queries).ToDictionary(x => _fixRes[x.Key], x => x.Value);

    /// <summary>
    /// Sucht nach allen queries - alle queries müssen in einem Satz vorkommen.
    /// </summary>
    /// <param name="queries">Abfragen - Pro Token ein string-Array-Element</param>
    /// <returns>Key = QuickIndex IDs / Value = Sätze mit Übereinstimmung</returns>
    public Dictionary<long, HashSet<int>> SearchAllInOneSentence(string[] queries)
    {
      var res = Search(queries.First());
      if (res == null)
        return null;

      for (var i = 1; i < queries.Length; i++)
      {
        var tmp = new Dictionary<long, HashSet<int>>();
        var search = Search(queries[i]);
        if (search == null)
          return null;

        foreach (var x in res)
        {
          if (!search.ContainsKey(x.Key))
            continue;

          var n = new HashSet<int>(from v in x.Value where search[x.Key].Contains(v) select v);
          if (n.Count > 0)
            tmp.Add(x.Key, n);
        }

        res = tmp;
      }

      return res;
    }

    /// <summary>
    /// Sucht nach allen queries - alle queries müssen in einem Satz vorkommen - inkl. Auflösung der QuickIndex-IDs in CorpusExplorer GUIDs.
    /// </summary>
    /// <param name="queries">Abfragen - Pro Token ein string-Array-Element</param>
    /// <returns>Key = CorpusExplorer GUIDs / Value = Sätze mit Übereinstimmung</returns>
    public Dictionary<Guid, HashSet<int>> SearchAllInOneSentenceResolved(string[] queries)
      => SearchAllInOneSentence(queries).ToDictionary(x => _fixRes[x.Key], x => x.Value);

    public void Dispose()
    {
      _dic?.Dispose();
      _dicRes?.Dispose();
      _meta?.Dispose();
      _fixRes.Clear();
      GC.Collect();
    }
  }
}