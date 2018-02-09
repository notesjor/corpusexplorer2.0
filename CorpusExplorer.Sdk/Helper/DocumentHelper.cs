#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  public static class DocumentHelper
  {
    /// <summary>
    ///   Konvertiert einen Multi-Layer-Dokument in ein Layer-Dokument bei dem die Layerwerte aneinander ausgerichtet sind.
    /// </summary>
    /// <param name="multiDocument">Multi-Layer-Dokument</param>
    /// <returns>Synchronisierte Layer (KeyValuePair => Key = Layername / Value = Layerwert)</returns>
    public static IEnumerable<IEnumerable<IEnumerable<KeyValuePair<string, string>>>>
      ConvertMultilayerToSyncLayer(
        this Dictionary<string, IEnumerable<IEnumerable<string>>> multiDocument)
    {
      var dic = new List<List<Dictionary<string, string>>>();

      foreach (var layer in multiDocument)
      {
        var i = 0;
        foreach (var sent in layer.Value)
        {
          while (dic.Count <= i)
            dic.Add(new List<Dictionary<string, string>>());

          var j = 0;
          foreach (var word in sent)
          {
            while (dic[i].Count <= j)
              dic[i].Add(new Dictionary<string, string>());

            dic[i][j].Add(layer.Key, word);

            j++;
          }

          i++;
        }
      }

      return dic;
    }

    /// <summary>
    ///   Berechnet die Dokumentgröße
    /// </summary>
    /// <param name="document">Dokument</param>
    /// <returns>Token</returns>
    public static int DocumentSize(this int[][] document)
    {
      try
      {
        return document.AsParallel().SelectMany(s => s).Count();
      }
      catch
      {
        return 0;
      }
    }

    /// <summary>
    ///   Konvertiert einen Multi-Layer-Dokument in ein Layer-Dokument bei dem die Layerwerte aneinander ausgerichtet sind.
    ///   [Obsolete] Bitte verwenden Sie zukünftig: ConvertMultilayerToSyncLayer
    /// </summary>
    /// <param name="multiDocument">Multi-Layer-Dokument </param>
    /// <returns>Synchronisierte Layer (KeyValuePair => Key = Layername / Value = Layerwert)</returns>
    [Obsolete]
    public static IEnumerable<IEnumerable<IEnumerable<KeyValuePair<string, string>>>>
      ReduceDocumentMultilayerToSynchronReadabelDocument(
        this Dictionary<string, IEnumerable<IEnumerable<string>>> multiDocument)
    {
      return ConvertMultilayerToSyncLayer(multiDocument);
    }

    /// <summary>
    ///   Reduziert ein Dokument so, das es nur noch eine Auflistung von Token/Worten ist.
    /// </summary>
    /// <param name="document">Dokument</param>
    /// <returns>Wort für Wort</returns>
    public static IEnumerable<string> ReduceDocumentToStreamDocument(this IEnumerable<IEnumerable<string>> document)
    {
      return document.SelectMany(sent => sent);
    }

    public static string ReduceDocumentToText(this IEnumerable<IEnumerable<string>> document, string sentenceSeparator = "\r\n", string tokenSeparator = " ")
    {
      return string.Join(sentenceSeparator, document.Select(s => string.Join(tokenSeparator, s)));
    }

    public static string ReduceSentenceToText(this IEnumerable<string> sentence, string tokenSeparator = " ") { return string.Join(tokenSeparator, sentence); }

    /// <summary>
    ///   Reduziert ein Dokument so, das es eine Auflistung von Sätzen darstellt.
    /// </summary>
    /// <param name="document">The document.</param>
    /// <returns>IEnumerable&lt;System.String&gt;.</returns>
    public static IEnumerable<string> ReduceToSentences(this IEnumerable<IEnumerable<string>> document, string tokenSeparator = " ")
    {
      return document.Select(s => string.Join(tokenSeparator, s));
    }

    public static string SplitDocument(this IEnumerable<IEnumerable<string>> document, int from, int to = -1)
    {
      return SplitDocument(ReduceDocumentToStreamDocument(document), from, to);
    }

    public static string SplitDocument(this IEnumerable<string> streamDocument, int from, int to = -1)
    {
      var text = streamDocument.ToArray();

      if (to == -1)
        to = text.Length;
      var list = new List<string>();

      for (var i = from; i < to; i++)
        if (text[i].Length == 1)
          list.Add(text[i]);
        else
          list.Add(" " + text[i]);
      
      return string.Concat(list).Trim();
    }
  }
}