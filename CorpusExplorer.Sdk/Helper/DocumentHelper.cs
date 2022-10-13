#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

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

    /// <summary>
    ///   Reduziert ein Dokument so, das es nur noch der gewählte Satz übrigbleibt.
    /// </summary>
    /// <param name="document">Dokument</param>
    /// <param name="sentenceId">SatzId</param>
    /// <returns>Wort für Wort</returns>
    public static IEnumerable<string> ReduceToSentence(this IEnumerable<IEnumerable<string>> document, int sentenceId)
    {
      return document.Skip(sentenceId).Take(1).SelectMany(x => x);
    }

    /// <summary>
    /// Wandelt ein Snippet in einen String um und fügt der Ausgabe ein Highlight hinzu.
    /// </summary>
    /// <param name="document">Dokument oder Snippet</param>
    /// <param name="sentenceSeparator">Wie sollen Sätze separiert werden? - Wenn null, dann nutze Systemstandard</param>
    /// <param name="tokenSeparator">Wie sollen Token separiert werden?</param>
    /// <param name="highlight">Wort die gehighlighted werden.</param>
    /// <param name="highlightStart">Highlight Start-Tag</param>
    /// <param name="highlightEnd">Highlight End-Tag</param>
    /// <returns></returns>
    public static string ReduceDocumentToText(this IEnumerable<IEnumerable<string>> document, IEnumerable<string> highlight,
                                              string highlightStart = "<strong>", string highlightEnd = "</strong>",
                                              string sentenceSeparator = null, string tokenSeparator = " ")
    {
      if (sentenceSeparator == null)
        sentenceSeparator = Environment.NewLine;

      var h = new HashSet<string>(highlight);
      return string.Join(sentenceSeparator, document.Select(s => string.Join(tokenSeparator, s.Select(w => h.Contains(w) ? $"{highlightStart}{w}{highlightEnd}" : w))));
    }

    /// <summary>
    /// Wandelt einen Satz (Snippet) in einen String um und fügt der Ausgabe ein Highlight hinzu.
    /// </summary>
    /// <param name="sentence">Satz</param>
    /// <param name="tokenSeparator">Wie sollen Token separiert werden?</param>
    /// <returns></returns>
    public static string ReduceSentenceToText(this IEnumerable<string> sentence, IEnumerable<string> highlight, string highlightStart = "<strong>", string highlightEnd = "</strong>", string tokenSeparator = " ")
    {
      var h = new HashSet<string>(highlight);
      return string.Join(tokenSeparator, sentence.Select(w => h.Contains(w) ? $"{highlightStart}{w}{highlightEnd}" : w));
    }

    /// <summary>
    /// Wandelt ein Snippet in einen String um.
    /// </summary>
    /// <param name="document">Dokument oder Snippet</param>
    /// <param name="sentenceSeparator">Wie sollen Sätze separiert werden? - Wenn null, nutze Systemstandard</param>
    /// <param name="tokenSeparator">Wie sollen Token separiert werden?</param>
    /// <returns></returns>
    public static string ReduceDocumentToText(this IEnumerable<IEnumerable<string>> document,
                                              string sentenceSeparator = null, string tokenSeparator = " ")
    {
      if (sentenceSeparator == null)
        sentenceSeparator = Environment.NewLine;

      return string.Join(sentenceSeparator, document.Select(s => string.Join(tokenSeparator, s)));
    }

    /// <summary>
    /// Wandelt einen Satz (Snippet) in einen String um.
    /// </summary>
    /// <param name="sentence">Satz</param>
    /// <param name="tokenSeparator">Wie sollen Token separiert werden?</param>
    /// <returns></returns>
    public static string ReduceSentenceToText(this IEnumerable<string> sentence, string tokenSeparator = " ")
    {
      return string.Join(tokenSeparator, sentence);
    }

    /// <summary>
    /// Wandelt einen Satz (Snippet) in einen String um.
    /// </summary>
    /// <param name="sentence">Satz</param>
    /// <param name="tokenSeparator">Wie sollen Token separiert werden?</param>
    /// <returns></returns>
    public static string ReduceSentenceToText(this IEnumerable<int> sentence, AbstractLayerAdapter layer, string tokenSeparator = " ")
    {
      return string.Join(tokenSeparator, sentence.Select(x => layer[x]));
    }

    /// <summary>
    ///   Reduziert ein Dokument so, das es eine Auflistung von Sätzen darstellt.
    /// </summary>
    /// <param name="document">The document.</param>
    /// <returns>IEnumerable&lt;System.String&gt;.</returns>
    public static IEnumerable<string> ReduceToSentences(this IEnumerable<IEnumerable<string>> document,
                                                        string tokenSeparator = " ")
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

      if (from < 0)
        from = 0;
      if (to == -1)
        to = text.Length;
      if (to == 0)
        return "";

      var list = new List<string>();
      for (var i = from; i < to; i++)
        try
        {
          if (text[i].Length == 1)
            list.Add(text[i]);
          else
            list.Add(" " + text[i]);
        }
        catch
        {
          break;
        }

      return string.Concat(list).Trim();
    }

    public static string Improve(this string text)
      => text.Replace(" . ", ". ")
             .Replace(" : ", ": ")
             .Replace(" ; ", "; ")
             .Replace(" , ", ", ")
             .Replace(" ! ", "! ")
             .Replace(" ? ", "? ")
             .Replace(" ) ", ") ")
             .Replace(" ] ", "] ")
             .Replace(" [ ", " [")
             .Replace(" ( ", " (");

    public static IEnumerable<int> Reduce(this IEnumerable<IEnumerable<int>> document)
      => document.SelectMany(s => s);
  }
}