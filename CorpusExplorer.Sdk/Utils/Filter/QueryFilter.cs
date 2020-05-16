#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter
{
  public static class QueryFilter
  {
    /// <summary>
    ///   Sucht nach Dokumenten, die den Kriterien entsprechen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Kriterien</param>
    /// <returns>Key = CorpusGuid / Value = Auflistung aller DocumentGuids</returns>
    public static Dictionary<Guid, HashSet<Guid>> SearchOnDocumentLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var dic = new Dictionary<Guid, HashSet<Guid>>();
      var dicLock = new object();

      Parallel.ForEach(
                       selection,
                       Configuration.ParallelOptions,
                       csel =>
                       {
                         var corpus = selection.GetCorpus(csel.Key);
                         if (corpus == null)
                           return;

                         var bag = new ConcurrentBag<Guid>();

                         Parallel.ForEach(
                                          csel.Value,
                                          Configuration.ParallelOptions,
                                          dsel =>
                                          {
                                            var check = true;

                                            // Damit ein Dokument akzeptiert wird müssen alle Queries positive Ergebnisse zurückliefern
                                            foreach (var query in queries)
                                            {
                                              check = query.Validate(corpus, dsel);
                                              if (!check)
                                                break;
                                            }

                                            if (check)
                                              bag.Add(dsel);
                                          });

                         lock (dicLock)
                         {
                           if (bag.Count > 0)
                             dic.Add(csel.Key, new HashSet<Guid>(bag));
                         }
                       });
      return dic;
    }

    /// <summary>
    ///   Sucht alle Sätze die den Kriterien entsprechen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Kriterien</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value = SatzId</returns>
    public static Dictionary<Guid, Dictionary<Guid, HashSet<int>>> SearchOnSentenceLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var dic1 = new ConcurrentDictionary<Guid, Dictionary<Guid, HashSet<int>>>();

      Parallel.ForEach(
                       selection,
                       Configuration.ParallelOptions,
                       csel =>
                       {
                         var corpus = selection.GetCorpus(csel.Key);
                         if (corpus == null)
                           return;

                         var dic2 = new ConcurrentDictionary<Guid, HashSet<int>>();

                         Parallel.ForEach(
                                          csel.Value,
                                          Configuration.ParallelOptions,
                                          dsel =>
                                          {
                                            var check = true;
                                            var dic3 = new HashSet<int>();

                                            // Damit ein Dokument akzeptiert wird müssen alle Queries positive Ergebnisse zurückliefern
                                            foreach (
                                              var qidx in
                                              queries.Select(query => query.GetSentenceIndices(corpus, dsel)))
                                            {
                                              // Bei leerer Ergebnismenge breche den gesamten Vorgang ab
                                              check = qidx != null;
                                              if (!check)
                                                break;

                                              foreach (var x in qidx)
                                                dic3.Add(x);
                                            }

                                            if (check && dic3.Count > 0)
                                              dic2.TryAdd(dsel, dic3);
                                          });

                         dic1.TryAdd(csel.Key, dic2.ToDictionary(x => x.Key, x => x.Value));
                       });
      return dic1.ToDictionary(x => x.Key, x => x.Value);
    }

    /// <summary>
    ///   Sucht in allen Sätzem nach Fundstellen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Kriterien</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>> SearchOnWordLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var dic1 = new ConcurrentDictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>>();

      Parallel.ForEach(
                       selection,
                       Configuration.ParallelOptions,
                       csel =>
                       {
                         var corpus = selection.GetCorpus(csel.Key);
                         if (corpus == null)
                           return;

                         var dic2 = new ConcurrentDictionary<Guid, Dictionary<int, HashSet<int>>>();

                         Parallel.ForEach(
                                          csel.Value,
                                          Configuration.ParallelOptions,
                                          dsel =>
                                          {
                                            var check = true;
                                            Dictionary<int, HashSet<int>> dic3 = null;

                                            // Damit ein Dokument akzeptiert wird müssen alle Queries positive Ergebnisse zurückliefern
                                            foreach (
                                              var qidx in
                                              queries.Select(query => query.GetSentenceAndWordIndices(corpus, dsel)))
                                            {
                                              // Bei leerer Ergebnismenge breche den gesamten Vorgang ab
                                              check = !(qidx == null || qidx.Count == 0);
                                              if (!check)
                                                break;

                                              if (dic3 == null)
                                              {
                                                // Wenn dic3 noch nicht belegt ist dann verwende qidx
                                                dic3 = qidx;
                                              }
                                              else
                                              {
                                                // qidx wird als dic3 verwendet und erneut gefiltert

                                                var list = dic3.Select(x => x.Key).ToArray();
                                                foreach (var x in list)
                                                  if (qidx.ContainsKey(x))
                                                  {
                                                    var widx = dic3[x].ToArray();
                                                    foreach (var w in widx.Where(w => !qidx[x].Contains(w)))
                                                      dic3[x].Remove(w);
                                                  }
                                                  else
                                                  {
                                                    // Wenn der Satz nicht vorhanden ist, dann lösche ihn komplett.
                                                    dic3.Remove(x);
                                                  }
                                              }
                                            }

                                            if (check && dic3 != null && dic3.Count > 0)
                                              dic2.TryAdd(dsel, dic3);
                                          });

                         dic1.TryAdd(csel.Key, dic2.ToDictionary(x => x.Key, x => x.Value));
                       });
      return dic1.ToDictionary(x => x.Key, x => x.Value);
    }
  }
}