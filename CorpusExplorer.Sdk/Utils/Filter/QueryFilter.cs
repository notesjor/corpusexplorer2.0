using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter
{
  [Obsolete("Use CorpusExplorer.Sdk.Utils.Filter.QuickQuery")]
  public static class QueryFilter
  {
    /// <summary>
    ///   Sucht nach Dokumenten, die den Kriterien entsprechen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Kriterien</param>
    /// <returns>Key = CorpusGuid / Value = Auflistung aller DocumentGuids</returns>
    [Obsolete("Use CorpusExplorer.Sdk.Utils.Filter.QuickQuery")]
    public static Dictionary<Guid, HashSet<Guid>> SearchOnDocumentLevel(
      Selection selection, IEnumerable<AbstractFilterQuery> queries)
      => QuickQuery.SearchOnDocumentLevel(selection, queries);

    /// <summary>
    ///   Sucht alle Sätze die den Kriterien entsprechen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Kriterien</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value = SatzId</returns>
    [Obsolete("Use CorpusExplorer.Sdk.Utils.Filter.QuickQuery")]
    public static Dictionary<Guid, Dictionary<Guid, HashSet<int>>> SearchOnSentenceLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
      => QuickQuery.SearchOnSentenceLevel(selection, queries);

    /// <summary>
    ///   Sucht in allen Sätzen nach Fundstellen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Kriterien</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    [Obsolete("Use CorpusExplorer.Sdk.Utils.Filter.QuickQuery")]
    public static Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>> SearchOnWordLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
      => QuickQuery.SearchOnWordLevel(selection, queries);
  }
}
