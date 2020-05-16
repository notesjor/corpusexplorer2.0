using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.CorpusExplorer;

namespace CorpusExplorer.Sdk.Extern.QuickIndex.FileBased.QueryToSentence
{
  public class FuriousIndex
  {
    private string _pathToCec6;
    private Dictionary<Guid, long> _index;
    private CeDictionary _dic;

    public FuriousIndex(string pathToCec6)
    {
      if (!File.Exists(pathToCec6 + ".fi"))
        Create(pathToCec6);

      _pathToCec6 = pathToCec6;
      _index = GetIndex(pathToCec6);
      _dic = new CeDictionary(GetDictionary(pathToCec6));
    }

    public Dictionary<Guid, HashSet<int>> Search(string query)
    {
      return QueryToSentenceIndexReader.Search(_pathToCec6, _dic[query]);
    }

    /// <summary>
    /// Erstellt einen neuen FuriousIndex
    /// </summary>
    /// <param name="pathToCec6">Pfad zur CEC6-Datei</param>
    /// <param name="layerDisplayname">Layername</param>
    public static void Create(string pathToCec6, string layerDisplayname = "Wort")
      => QueryToSentenceIndexWriter.Create(pathToCec6, layerDisplayname, true, true);

    /// <summary>
    /// Gibt einen Auszug (Satzbereich) aus einem Dokument zurück.
    /// </summary>
    /// <param name="pathToCec6">Pfad zur CEC6-Datei</param>
    /// <param name="guid">Document GUID</param>
    /// <returns></returns>
    public static IEnumerable<IEnumerable<string>> GetDocumentSnippet(string pathToCec6, Guid guid, IEnumerable<int> sentenceIndices)
    {
      var doc = GetIndexDocument(pathToCec6, guid);
      return doc == null ? null : ResolveIndexDocument(pathToCec6, sentenceIndices.Select(i => doc[i]));
    }

    /// <summary>
    /// Gibt einen Auszug (Satzbereich) aus einem Dokument zurück.
    /// </summary>
    /// <param name="guid">Document GUID</param>
    /// <returns></returns>
    public IEnumerable<IEnumerable<string>> GetDocumentSnippet(Guid guid, IEnumerable<int> sentenceIndices)
    {
      var doc = GetIndexDocument(guid);
      return doc == null ? null : ResolveIndexDocument(sentenceIndices.Select(i => doc[i]));
    }

    /// <summary>
    /// Gibt einen Auszug (Satzbereich) aus einem Dokument zurück.
    /// </summary>
    /// <param name="guid">Document GUID</param>
    /// <returns></returns>
    public string GetDocumentSimpleSnippet(Guid guid, IEnumerable<int> sentenceIndices)
    {
      var doc = GetIndexDocument(guid);
      return doc == null ? null : ResolveIndexDocument(sentenceIndices.Select(i => doc[i])).ReduceDocumentToText();
    }

    /// <summary>
    /// Gibt ein Dokument aus dem Korpus zurück.
    /// </summary>
    /// <param name="pathToCec6">CEC6-Korpus</param>
    /// <param name="guid">Guid des Dokuments</param>
    /// <returns></returns>
    public static IEnumerable<IEnumerable<string>> GetDocument(string pathToCec6, Guid guid)
      => ResolveIndexDocument(pathToCec6, GetIndexDocument(pathToCec6, guid));
    
    /// <summary>
    /// Gibt ein Dokument aus dem Korpus zurück.
    /// </summary>
    /// <param name="pathToCec6">CEC6-Korpus</param>
    /// <param name="guid">Guid des Dokuments</param>
    /// <returns></returns>
    public IEnumerable<IEnumerable<string>> GetDocument(Guid guid)
      => ResolveIndexDocument(GetIndexDocument(guid));

    private static IEnumerable<IEnumerable<string>> ResolveIndexDocument(string pathToCec6, IEnumerable<int[]> doc)
      => ResolveIndexDocument(GetDictionary(pathToCec6), doc);

    private static IEnumerable<IEnumerable<string>> ResolveIndexDocument(Dictionary<int, string> dictionary, IEnumerable<int[]> doc)
      => doc?.Select(x => x.Select(y => dictionary[y]));

    private IEnumerable<IEnumerable<string>> ResolveIndexDocument(IEnumerable<int[]> doc)
      => doc?.Select(x => x.Select(y => _dic[y]));

    /// <summary>
    /// Gibt ein FuriousIndex-Dictionary für ein CEC6-Korpus zurück.
    /// (Setzt voraus, dass zuvor mittels QuickIndex.FileBased.QueryToSentence.QueryToSentenceIndexWriter (storeDictionary) ein FuriousIndex-Dictionary erstellt wurde).
    /// </summary>
    /// <param name="pathToCec6">CEC6-Korpus</param>
    /// <returns></returns>
    public static Dictionary<int, string> GetDictionary(string pathToCec6)
    {
      // Hinweis: Dies entspricht der Funktion DictionarySerializerHelper.Deserialize - mit dem Unterschied, dass Key & Value vertauscht werden.

      var dictionary = new Dictionary<int, string>();
      var bufferInt = new byte[sizeof(int)];
      using (var stream = new FileStream(pathToCec6 + ".dic", FileMode.Open, FileAccess.Read))
        while (true)
        {
          // Lese Token-byte[]-Länge
          stream.Read(bufferInt, 0, bufferInt.Length);
          var length = BitConverter.ToInt32(bufferInt, 0);
          // Abbruch, wenn length == int.min (SPLIT-Marker) erreicht wurde.
          if (length == int.MinValue)
            break;

          // Lese Token
          var buffer = new byte[length];
          stream.Read(buffer, 0, buffer.Length);
          var token = Configuration.Encoding.GetString(buffer);

          // Lese Index
          stream.Read(bufferInt, 0, bufferInt.Length);
          var index = BitConverter.ToInt32(bufferInt, 0);

          dictionary.Add(index, token); // VERTAUSCHT
        }
      return dictionary;
    }

    /// <summary>
    /// Gibt ein Dokument aus einem CEC6-Korpus zurück.
    /// (Setzt voraus, dass zuvor mittels QuickIndex.FileBased.QueryToSentence.QueryToSentenceIndexWriter (storeCec6FuriousIndex) ein FuriousIndex erstellt wurde).
    /// </summary>
    /// <param name="pathToCec6">CEC-Korpus</param>
    /// <param name="guid">Guid des Dokuments.</param>
    /// <returns>Dokument</returns>
    public static int[][] GetIndexDocument(string pathToCec6, Guid guid)
    {
      var dic = GetIndex(pathToCec6);
      return !dic.ContainsKey(guid) ? null : GetIndexDocument(pathToCec6, dic[guid]);
    }

    /// <summary>
    /// Gibt ein Dokument aus einem CEC6-Korpus zurück.
    /// (Setzt voraus, dass zuvor mittels QuickIndex.FileBased.QueryToSentence.QueryToSentenceIndexWriter (storeCec6FuriousIndex) ein FuriousIndex erstellt wurde).
    /// </summary>
    /// <param name="guid">Guid des Dokuments.</param>
    /// <returns>Dokument</returns>
    public int[][] GetIndexDocument(Guid guid)
    {
      return !_index.ContainsKey(guid) ? null : GetIndexDocument(_index[guid]);
    }

    /// <summary>
    /// Gibt ein Dokument aus einem CEC6-Korpus zurück
    /// </summary>
    /// <param name="pathToCec6">CEC-Korpus</param>
    /// <param name="position">Poistion innerhalb der Datei</param>
    /// <returns>Dokument</returns>
    public static int[][] GetIndexDocument(string pathToCec6, long position)
    {
      using (var fs = new FileStream(pathToCec6, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        fs.Seek(position, SeekOrigin.Begin);
        return DocumentSerializerHelper.Deserialize(fs);
      }
    }

    /// <summary>
    /// Gibt ein Dokument aus einem CEC6-Korpus zurück
    /// </summary>
    /// <param name="position">Poistion innerhalb der Datei</param>
    /// <returns>Dokument</returns>
    public int[][] GetIndexDocument(long position)
    {
      using (var fs = new FileStream(_pathToCec6, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        fs.Seek(position, SeekOrigin.Begin);
        return DocumentSerializerHelper.Deserialize(fs);
      }
    }

    /// <summary>
    /// Gibt den Index für das CEC6-Korpus zurück (muss zuvor mittels QuickIndex.FileBased.QueryToSentence.QueryToSentenceIndexWriter erstellt worden sein).
    /// </summary>
    /// <param name="pathToCec6">Pfad zum CEC6-Korpus</param>
    /// <returns>Dictionary</returns>
    public static Dictionary<Guid, long> GetIndex(string pathToCec6)
    {
      var dict = new Dictionary<Guid, long>();
      using (var fs = new FileStream(pathToCec6 + ".fi", FileMode.Open, FileAccess.Read))
        Deserialize(fs, ref dict);

      return dict;
    }

    private static void Deserialize(Stream stream, ref Dictionary<Guid, long> dictionary)
    {
      var bufferLong = new byte[sizeof(long)];
      var bufferGuid = new byte[16];
      while (stream.Read(bufferGuid, 0, bufferGuid.Length) > 0)
      {
        var guid = new Guid(bufferGuid);
        stream.Read(bufferLong, 0, bufferLong.Length);
        var pos = BitConverter.ToInt64(bufferLong, 0);
        dictionary.Add(guid, pos);
      }
    }
  }
}
