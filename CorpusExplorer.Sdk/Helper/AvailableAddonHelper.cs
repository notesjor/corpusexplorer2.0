using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Helper
{
  public static class AvailableAddonHelper
  {
    /// <summary>
    /// Gibt eine Auflistung mit verfügbaren Typennamen zurück (Addons).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dic">Addon-Quelle</param>
    /// <param name="ignoreInName">Ignoriere folgenden Namensbestandteile (z. B. Scraper)</param>
    /// <returns>Auflistung als string</returns>
    public static IEnumerable<string> GetReflectedTypeNameList<T>(this IEnumerable<KeyValuePair<string, T>> dic, string ignoreInName)
      => dic == null
           ? (IEnumerable<string>) new List<string>()
           : string.IsNullOrWhiteSpace(ignoreInName)
             ? new HashSet<string>(dic.Select(x => x.Value.GetType().Name))
             : new HashSet<string>(dic.Select(x => x.Value.GetType().Name.Replace(ignoreInName, string.Empty)));

    /// <summary>
    /// Gibt eine Auflistung mit verfügbaren Typennamen zurück (Addons).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable">Addon-Quelle</param>
    /// <param name="ignoreInName">Ignoriere folgenden Namensbestandteile (z. B. Scraper)</param>
    /// <returns>Auflistung als string</returns>
    public static IEnumerable<string> GetReflectedTypeNameList<T>(this IEnumerable<T> enumerable, string ignoreInName)
      => enumerable == null
           ? (IEnumerable<string>) new List<string>()
           : string.IsNullOrWhiteSpace(ignoreInName)
             ? new HashSet<string>(enumerable.Select(x => x.GetType().Name))
             : new HashSet<string>(enumerable.Select(x => x.GetType().Name.Replace(ignoreInName, string.Empty)));


    public static T GetReflectedType<T>(this IEnumerable<KeyValuePair<string, T>> dic, string typeName, string ignoreInName) where T : class
    {
      if (dic == null)
        return null;

      typeName = typeName.Replace(ignoreInName, string.Empty);

      return (from pair in dic where typeName == pair.Value.GetType().Name.Replace(ignoreInName, string.Empty) select pair.Value).FirstOrDefault();
    }


    public static T GetReflectedType<T>(this IEnumerable<T> enumerable, string typeName, string ignoreInName) where T : class
    {
      if (enumerable == null)
        return null;

      typeName = typeName.Replace(ignoreInName, string.Empty);

      return enumerable.FirstOrDefault(unknown => typeName == unknown.GetType().Name.Replace(ignoreInName, string.Empty));
    }
  }
}