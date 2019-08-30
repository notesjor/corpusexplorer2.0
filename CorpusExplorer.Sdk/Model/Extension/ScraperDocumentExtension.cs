using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Model.Extension
{
  public static class ScraperDocumentExtension
  {
    /// <summary>
    ///   gibt eine enumerierbare Auflistung aller Eigenschaften (KEYs) zur�ck
    /// </summary>
    /// <param name="scraperDocument">Scrap-Document</param>
    /// <param name="ignore">Auflistung von Eigenschaften die ignoriert werden sollen</param>
    /// <returns>Auflistungen von KEYs</returns>
    public static IEnumerable<string> Enumerate(
      this Dictionary<string, object> scraperDocument,
      IEnumerable<string> ignore = null)
    {
      var hash = ignore == null ? new HashSet<string>() : new HashSet<string>(ignore);
      return from x in scraperDocument where !hash.Contains(x.Key) select x.Key;
    }

    /// <summary>
    ///   Gibt den Wert der unter dem Key gespiechert ist zur�ck
    /// </summary>
    /// <typeparam name="T">Datentyp</typeparam>
    /// <param name="key">Key</param>
    /// <param name="scraperDocument">Scrap-Document</param>
    /// <param name="defaultValue">Wenn kein Wert gespiechert, speichere diesen Wert und geben den Wert ebenfalls zur�ck.</param>
    /// <returns>Wert</returns>
    public static T Get<T>(this Dictionary<string, object> scraperDocument, string key, T defaultValue)
    {
      if (scraperDocument.ContainsKey(key))
        try
        {
          var obj = scraperDocument[key];
          if (typeof(T) == typeof(DateTime) &&
              obj is string)
            return (T) (object) DateTimeHelper.Parse((string) obj, true);
          return (T) obj;
        }
        catch
        {
          return defaultValue;
        }

      Set(scraperDocument, key, defaultValue);

      return defaultValue;
    }

    /// <summary>
    ///   Gibt den Wert der unter dem Key gespiechert ist zur�ck
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="scraperDocument">Scrap-Document</param>
    /// <param name="defaultValue">Wenn kein Wert gespiechert, speichere diesen Wert und geben den Wert ebenfalls zur�ck.</param>
    /// <returns>Wert</returns>
    public static object Get(this Dictionary<string, object> scraperDocument, string key, object defaultValue = null)
    {
      if (scraperDocument.ContainsKey(key))
        try
        {
          return scraperDocument[key];
        }
        catch
        {
          return defaultValue;
        }

      Set(scraperDocument, key, defaultValue);

      return defaultValue;
    }

    public static Dictionary<string, object> GetMetaDictionary(this Dictionary<string, object> scraperDocument)
    {
      return scraperDocument.Where(entry => entry.Key != "Text" && !entry.Key.StartsWith("!")).ToDictionary(entry => entry.Key, entry => entry.Value);
    }

    /// <summary>
    ///   Gibt den Typ der Daten die unter dem key gespiechert sind zur�ck
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="scraperDocument">Scrap-Document</param>
    /// <returns>Typ</returns>
    public static Type GetType(this Dictionary<string, object> scraperDocument, string key)
    {
      if (!scraperDocument.ContainsKey(key))
        return typeof(object);
      var value = scraperDocument[key];
      return value?.GetType() ?? typeof(object);
    }

    /// <summary>
    ///   Entferne den Key
    /// </summary>
    /// <param name="scraperDocument">Scrap-Document</param>
    /// <param name="key">Key</param>
    public static void Remove(this Dictionary<string, object> scraperDocument, string key)
    {
      if (scraperDocument.ContainsKey(key))
        scraperDocument.Remove(key);
    }

    /// <summary>
    ///   Speichere den Wert unter diesem Key die Daten
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="scraperDocument">Scrap-Document</param>
    /// <param name="data">Daten</param>
    public static void Set(this Dictionary<string, object> scraperDocument, string key, object data)
    {
      if (scraperDocument == null)
        scraperDocument = new Dictionary<string, object>();

      if (scraperDocument.ContainsKey(key))
        scraperDocument[key] = data;
      else
        scraperDocument.Add(key, data);
    }
  }
}