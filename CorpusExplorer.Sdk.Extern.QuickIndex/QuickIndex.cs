#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.QuickIndex.Indices;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Layer;

#endregion

namespace CorpusExplorer.Sdk.Extern.QuickIndex
{
  public class QuickIndex
  {
    private readonly Dictionary<string, int> _dic;
    private readonly Dictionary<Guid, long> _fix;
    private readonly Dictionary<int, long> _meta;
    private readonly Dictionary<int, string> _resDic;
    private readonly Dictionary<long, Guid> _resPos;
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
      if (!File.Exists($"{pathToCec6}_{layerDisplayname}.idxm"))
        Create(pathToCec6, layerDisplayname);

      PathToCec6 = pathToCec6;
      LayerDisplayname = layerDisplayname;
      Read(pathToCec6, out _dic, out _fix, out _meta, layerDisplayname);

      _resPos = new Dictionary<long, Guid>();
      foreach (var x in _fix)
        _resPos.Add(x.Value, x.Key);

      _resDic = new Dictionary<int, string>();
      foreach (var x in _dic)
        _resDic.Add(x.Value, x.Key);
    }

    public string PathToCec6 { get; private set; }
    public string LayerDisplayname { get; private set; }

    /// <summary>
    /// Löscht einen bestehende QuickIndex
    /// </summary>
    /// <param name="pathToCec6">Pfad zur CEC6-Datei. Muss bereits exsistieren. Die CEC6-Datei beleibt erhalten.</param>
    /// <param name="layerDisplayname">Layer für den der QuickIndex gelöscht werden soll.</param>
    public static void Delete(string pathToCec6, string layerDisplayname)
    {
      if (File.Exists($"{pathToCec6}_{layerDisplayname}.idxm"))
        File.Delete($"{pathToCec6}_{layerDisplayname}.idxm");
      if (File.Exists($"{pathToCec6}_{layerDisplayname}.idx"))
        File.Delete($"{pathToCec6}_{layerDisplayname}.idx");
      if (File.Exists($"{pathToCec6}_{layerDisplayname}.fif"))
        File.Delete($"{pathToCec6}_{layerDisplayname}.fif");
      if (File.Exists($"{pathToCec6}_{layerDisplayname}.fi"))
        File.Delete($"{pathToCec6}_{layerDisplayname}.fi");
      if (File.Exists($"{pathToCec6}_{layerDisplayname}.dic"))
        File.Delete($"{pathToCec6}_{layerDisplayname}.dic");
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
      return GetIndexDocument(position).Select(s => s.Select(w => _resDic[w]));
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
                 : sentenceIndices.Select(sI => doc[sI].Select(x => _resDic[x]));
    }

    private IEnumerable<IEnumerable<string>> MarkEmpty(IEnumerable<int> sentenceIndices, int[][] doc)
    {
      var arr = sentenceIndices.ToArray();
      var sen = arr.Select(sI => doc[sI].Select(x => _resDic[x])).ToList();
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
      if (!_resPos.ContainsKey(position))
        return null;

      using (var fs = new FileStream(PathToCec6 + $"_{LayerDisplayname}.fif", FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        fs.Seek(position, SeekOrigin.Begin);
        return DocumentSerializerHelper.Deserialize(fs);
      }
    }

    private static void Read(string pathToCec6, out Dictionary<string, int> layerDictionary,
                             out Dictionary<Guid, long> cec6Positions,
                             out Dictionary<int, long> metaIndex,
                             string layerDisplayname = "Wort")
    {
      layerDictionary = DictionaryIndex.Read(pathToCec6, layerDisplayname);
      cec6Positions = Cec6FileIndex.Read(pathToCec6, layerDisplayname);
      metaIndex = InverseIndex.Read(pathToCec6, layerDisplayname);
    }

    /// <summary>
    /// Erlaubt die UMwandlung mehrerer QuickIndex IDs in entsprechende CorpusExplorer GUIDs
    /// </summary>
    /// <param name="positions">QuickIndex IDs</param>
    /// <returns>orpusExplorer GUIDs</returns>
    public IEnumerable<Guid> Resolve(IEnumerable<long> positions)
      => positions.Select(x => _resPos[x]);

    /// <summary>
    /// Erlaubt die Umwandlung von QuickIndex IDs in CorpusExplorer GUIDs
    /// </summary>
    /// <param name="position">QuickIndex ID</param>
    /// <returns>CorpusExplorer GUID</returns>
    public Guid Resolve(long position)
      => _resPos[position];

    /// <summary>
    /// Sucht nach einem query/Token.
    /// </summary>
    /// <param name="query">Abfragen - Query - Token</param>
    /// <returns>Key = QuickIndex IDs / Value = Sätze mit Übereinstimmung</returns>
    public Dictionary<long, HashSet<int>> Search(string query)
    {
      try
      {
        return InverseIndex.GetPositions(PathToCec6, LayerDisplayname, _meta[_dic[query]]);
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
      => Search(query).ToDictionary(x => _resPos[x.Key], x => x.Value);

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
      => SearchAny(queries).ToDictionary(x => _resPos[x.Key], x => x.Value);

    /// <summary>
    /// Sucht nach allen queries - alle queries müssen in einem Dokument vorkommen.
    /// </summary>
    /// <param name="queries">Abfragen - Pro Token ein string-Array-Element</param>
    /// <returns>Key = QuickIndex IDs / Value = Sätze mit Übereinstimmung</returns>
    public Dictionary<long, HashSet<int>> SearchAllInOneDocument(string[] queries)
    {
      var res = Search(queries.First());
      for (var i = 1; i < queries.Length; i++)
      {
        var search = Search(queries[i]);
        var delete = new List<long>();
        foreach (var x in res)
        {
          if (search.ContainsKey(x.Key))
            foreach (var y in search[x.Key])
              res[x.Key].Add(y);
          else
            delete.Add(x.Key);
        }

        foreach (var x in delete)
          res.Remove(x);
      }

      return res;
    }

    /// <summary>
    /// Sucht nach allen queries - alle queries müssen in einem Dokument vorkommen - inkl. Auflösung der QuickIndex-IDs in CorpusExplorer GUIDs.
    /// </summary>
    /// <param name="queries">Abfragen - Pro Token ein string-Array-Element</param>
    /// <returns>Key = CorpusExplorer GUIDs / Value = Sätze mit Übereinstimmung (min. ein query)</returns>
    public Dictionary<Guid, HashSet<int>> SearchAllInOneDocumentResolved(string[] queries)
      => SearchAllInOneDocument(queries).ToDictionary(x => _resPos[x.Key], x => x.Value);

    /// <summary>
    /// Sucht nach allen queries - alle queries müssen in einem Satz vorkommen.
    /// </summary>
    /// <param name="queries">Abfragen - Pro Token ein string-Array-Element</param>
    /// <returns>Key = QuickIndex IDs / Value = Sätze mit Übereinstimmung</returns>
    public Dictionary<long, HashSet<int>> SearchAllInOneSentence(string[] queries)
    {
      var res = Search(queries.First());
      for (var i = 1; i < queries.Length; i++)
      {
        var search = Search(queries[i]);
        var delete = new List<long>();
        foreach (var x in res)
        {
          if (search.ContainsKey(x.Key))
          {
            var n = new HashSet<int>(res[x.Key].Where(y => search[x.Key].Contains(y)));
            if (n.Count == 0)
              delete.Add(x.Key);
            else
              res[x.Key] = n;
          }
          else
            delete.Add(x.Key);
        }

        foreach (var x in delete)
          res.Remove(x);
      }

      return res;
    }

    /// <summary>
    /// Sucht nach allen queries - alle queries müssen in einem Satz vorkommen - inkl. Auflösung der QuickIndex-IDs in CorpusExplorer GUIDs.
    /// </summary>
    /// <param name="queries">Abfragen - Pro Token ein string-Array-Element</param>
    /// <returns>Key = CorpusExplorer GUIDs / Value = Sätze mit Übereinstimmung</returns>
    public Dictionary<Guid, HashSet<int>> SearchAllInOneSentenceResolved(string[] queries)
      => SearchAllInOneSentence(queries).ToDictionary(x => _resPos[x.Key], x => x.Value);
  }
}