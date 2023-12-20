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
  public static class QuickQuery
  {
    /// <summary>
    ///   Sucht nach Dokumenten, die min. einer Abfrage entspricht.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfragen</param>
    /// <returns>Key = CorpusGuid / Value = Auflistung aller DocumentGuids</returns>
    public static Dictionary<Guid, HashSet<Guid>> OrSearchOnDocumentLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var results = new Dictionary<Guid, HashSet<Guid>>();
      var @lock = new object();

      Parallel.ForEach(queries, Configuration.ParallelOptions, query =>
      {
        var result = SearchOnDocumentLevel(selection, query);
        lock (@lock)
          foreach (var csel in result)
          {
            if (!results.ContainsKey(csel.Key))
              results.Add(csel.Key, new HashSet<Guid>());
            foreach (var doc in csel.Value)
              results[csel.Key].Add(doc);
          }
      });

      return results;
    }

    /// <summary>
    ///   Sucht nach Dokumenten, die allen Abfragen entspricht.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfragen</param>
    /// <returns>Key = CorpusGuid / Value = Auflistung aller DocumentGuids</returns>
    public static Dictionary<Guid, HashSet<Guid>> AndSearchOnDocumentLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var res = SearchOnDocumentLevel(selection, queries.First());
      if (res == null || res.Count == 0)
        return null;
      var @lock = new object();

      Parallel.ForEach(queries.Skip(1), Configuration.ParallelOptions, query =>
      {
        var tmp = SearchOnDocumentLevel(selection, query);
        lock (@lock)
        {
          var csels = res.Keys.ToArray();
          foreach (var csel in csels)
          {
            if (!tmp.ContainsKey(csel))
            {
              res.Remove(csel);
              continue;
            }
            var dsels = res[csel].ToArray();
            foreach (var dsel in dsels)
              if (!tmp[csel].Contains(dsel))
                res[csel].Remove(dsel);
          }
        }
      });
      return res;
    }

    /// <summary>
    ///   Sucht nach Dokumenten, die der Abfrage entsprechen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="query">Abfrage</param>
    /// <returns>Key = CorpusGuid / Value = Auflistung aller DocumentGuids</returns>
    public static Dictionary<Guid, HashSet<Guid>> SearchOnDocumentLevel(
      Selection selection,
      AbstractFilterQuery query)
    {
      var res = new Dictionary<Guid, HashSet<Guid>>();
      var @lock = new object();

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
                                            if (query.Validate(corpus, dsel))
                                              bag.Add(dsel);
                                          });

                         lock (@lock)
                         {
                           if (bag.Count > 0)
                             res.Add(csel.Key, new HashSet<Guid>(bag));
                         }
                       });
      return res;
    }

    /// <summary>
    ///   Zählt alle Dokumente mit Fundstellen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfrage</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static int CountOnDocumentLevel(Selection selection, IEnumerable<AbstractFilterQuery> queries)
      => queries.Sum(q => CountOnSentenceLevel(selection, q));

    /// <summary>
    ///   Zählt alle Dokumente mit Fundstellen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="query">Abfrage</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static int CountOnDocumentLevel(Selection selection, AbstractFilterQuery query)
    {
      try
      {
        return SearchOnDocumentLevel(selection, query).Sum(x => x.Value.Count);
      }
      catch
      {
        return 0;
      }
    }

    /// <summary>
    ///   Sucht alle Sätze die allen Abfragen entsprechen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfragen</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value = SatzId</returns>
    public static Dictionary<Guid, Dictionary<Guid, HashSet<int>>> AndSearchOnSentenceLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var res = SearchOnSentenceLevel(selection, queries.First());
      if (res == null || res.Count == 0)
        return null;
      var @lock = new object();

      Parallel.ForEach(queries.Skip(1), Configuration.ParallelOptions, query =>
      {
        var tmp = SearchOnSentenceLevel(selection, query);
        lock (@lock)
        {
          var csels = res.Keys.ToArray();
          foreach (var csel in csels)
          {
            if (!tmp.ContainsKey(csel))
            {
              res.Remove(csel);
              continue;
            }
            var dsels = res[csel].Keys.ToArray();
            foreach (var dsel in dsels)
            {
              if (!tmp[csel].ContainsKey(dsel))
              {
                res[csel].Remove(dsel);
                continue;
              }
              var ssels = res[csel][dsel].ToArray();
              foreach (var ssel in ssels)
                if (!tmp[csel][dsel].Contains(ssel))
                  res[csel][dsel].Remove(ssel);
            }
          }
        }
      });

      return res;
    }

    /// <summary>
    ///   Sucht alle Sätze die min. einer Abfrage entsprechen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfragen</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value = SatzId</returns>
    public static Dictionary<Guid, Dictionary<Guid, HashSet<int>>> OrSearchOnSentenceLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var res = new Dictionary<Guid, Dictionary<Guid, HashSet<int>>>();
      var @lock = new object();

      Parallel.ForEach(queries, Configuration.ParallelOptions, query =>
      {
        var result = SearchOnSentenceLevel(selection, query);
        lock (@lock)
          foreach (var csel in result)
          {
            if (!res.ContainsKey(csel.Key))
              res.Add(csel.Key, new Dictionary<Guid, HashSet<int>>());
            foreach (var dsel in csel.Value)
            {
              if (!res[csel.Key].ContainsKey(dsel.Key))
                res[csel.Key].Add(dsel.Key, new HashSet<int>());
              foreach (var sidx in dsel.Value)
                res[csel.Key][dsel.Key].Add(sidx);
            }
          }
      });

      return res;
    }

    /// <summary>
    ///   Sucht alle Sätze die den Kriterien entsprechen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="query">Abfrage</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value = SatzId</returns>
    public static Dictionary<Guid, Dictionary<Guid, HashSet<int>>> SearchOnSentenceLevel(
      Selection selection,
      AbstractFilterQuery query)
    {
      var res = new Dictionary<Guid, Dictionary<Guid, HashSet<int>>>();
      var @lock = new object();

      Parallel.ForEach(
                       selection,
                       Configuration.ParallelOptions,
                       csel =>
                       {
                         var corpus = selection.GetCorpus(csel.Key);
                         if (corpus == null)
                           return;

                         Parallel.ForEach(
                                          csel.Value,
                                          Configuration.ParallelOptions,
                                          dsel =>
                                          {
                                            var result = query.GetSentenceIndices(corpus, dsel);
                                            if (result == null || result.Count == 0)
                                              return;

                                            lock (@lock)
                                            {
                                              if (!res.ContainsKey(csel.Key))
                                                res.Add(csel.Key, new Dictionary<Guid, HashSet<int>>());
                                              if (!res[csel.Key].ContainsKey(dsel))
                                                res[csel.Key].Add(dsel, new HashSet<int>());
                                              foreach (var sidx in result)
                                                res[csel.Key][dsel].Add(sidx);
                                            }
                                          });
                       });
      return res;
    }

    /// <summary>
    ///   Zählt alle Sätze mit Fundstellen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfragen</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static int CountOnSentenceLevel(Selection selection, IEnumerable<AbstractFilterQuery> queries)
      => queries.Sum(q => CountOnSentenceLevel(selection, q));

    /// <summary>
    ///   Zählt alle Sätze mit Fundstellen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="query">Abfrage</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static int CountOnSentenceLevel(Selection selection, AbstractFilterQuery query)
    {
      try
      {
        return SearchOnSentenceLevel(selection, query).SelectMany(x => x.Value).Sum(y => y.Value.Count);
      }
      catch
      {
        return 0;
      }
    }



    /// <summary>
    ///   Sucht in allen Sätzen nach allen Fundstellen, die allen Abfragen entsprechen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfragen</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>> AndSearchOnWordLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var res = SearchOnWordLevel(selection, queries.First());
      if (res == null || res.Count == 0)
        return res;

      var @lock = new object();

      Parallel.ForEach(queries.Skip(1), Configuration.ParallelOptions, query =>
      {
        var tmp = SearchOnWordLevel(selection, query);
        lock (@lock)
        {
          var csels = res.Keys.ToArray();
          foreach (var csel in csels)
          {
            if (!tmp.ContainsKey(csel))
            {
              res.Remove(csel);
              continue;
            }
            var dsels = res[csel].Keys.ToArray();
            foreach (var dsel in dsels)
            {
              if (!tmp[csel].ContainsKey(dsel))
              {
                res[csel].Remove(dsel);
                continue;
              }
              var ssels = res[csel][dsel].Keys.ToArray();
              foreach (var ssel in ssels)
              {
                if (!tmp[csel][dsel].ContainsKey(ssel))
                {
                  res[csel][dsel].Remove(ssel);
                  continue;
                }
                var wsels = res[csel][dsel][ssel].ToArray();
                foreach (var wsel in wsels)
                  if (!tmp[csel][dsel][ssel].Contains(wsel))
                    res[csel][dsel][ssel].Remove(wsel);
              }
            }
          }
        }
      });

      return res;
    }

    /// <summary>
    ///   Sucht in allen Sätzen nach allen Fundstellen, die allen Abfragen entsprechen.
    ///   Dabei werden die Ergebnisse nicht in einem HashSet gespeichert, sondern in einer Liste.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfragen</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static Dictionary<Guid, Dictionary<Guid, Dictionary<int, List<int>>>> AndSearchOnWordLevelList(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var res = SearchOnWordLevelList(selection, queries.First());
      if (res == null || res.Count == 0)
        return res;

      var @lock = new object();

      Parallel.ForEach(queries.Skip(1), Configuration.ParallelOptions, query =>
      {
        var tmp = SearchOnWordLevelList(selection, query);
        lock (@lock)
        {
          var csels = res.Keys.ToArray();
          foreach (var csel in csels)
          {
            if (!tmp.ContainsKey(csel))
            {
              res.Remove(csel);
              continue;
            }
            var dsels = res[csel].Keys.ToArray();
            foreach (var dsel in dsels)
            {
              if (!tmp[csel].ContainsKey(dsel))
              {
                res[csel].Remove(dsel);
                continue;
              }
              var ssels = res[csel][dsel].Keys.ToArray();
              foreach (var ssel in ssels)
              {
                if (!tmp[csel][dsel].ContainsKey(ssel))
                {
                  res[csel][dsel].Remove(ssel);
                  continue;
                }
                var wsels = res[csel][dsel][ssel].ToArray();
                foreach (var wsel in wsels)
                  if (!tmp[csel][dsel][ssel].Contains(wsel))
                    res[csel][dsel][ssel].Remove(wsel);
              }
            }
          }
        }
      });

      return res;
    }

    /// <summary>
    ///   Sucht in allen Sätzen nach allen Fundstellen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfragen</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>> OrSearchOnWordLevel(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var res = new Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>>();
      var @lock = new object();

      Parallel.ForEach(queries, Configuration.ParallelOptions, query =>
      {
        var result = SearchOnWordLevel(selection, query);
        lock (@lock)
          foreach (var csel in result)
          {
            if (!res.ContainsKey(csel.Key))
              res.Add(csel.Key, new Dictionary<Guid, Dictionary<int, HashSet<int>>>());
            foreach (var dsel in csel.Value)
            {
              if (!res[csel.Key].ContainsKey(dsel.Key))
                res[csel.Key].Add(dsel.Key, new Dictionary<int, HashSet<int>>());
              foreach (var ssel in dsel.Value)
              {
                if (!res[csel.Key][dsel.Key].ContainsKey(ssel.Key))
                  res[csel.Key][dsel.Key].Add(ssel.Key, new HashSet<int>());
                foreach (var widx in ssel.Value)
                  res[csel.Key][dsel.Key][ssel.Key].Add(widx);
              }
            }
          }
      });

      return res;
    }

    /// <summary>
    ///   Sucht in allen Sätzen nach allen Fundstellen.
    ///   Dabei werden die Ergebnisse nicht in einem HashSet gespeichert, sondern in einer Liste.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfragen</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static Dictionary<Guid, Dictionary<Guid, Dictionary<int, List<int>>>> OrSearchOnWordLevelList(
      Selection selection,
      IEnumerable<AbstractFilterQuery> queries)
    {
      var res = new Dictionary<Guid, Dictionary<Guid, Dictionary<int, List<int>>>>();
      var @lock = new object();

      Parallel.ForEach(queries, Configuration.ParallelOptions, query =>
      {
        var result = SearchOnWordLevel(selection, query);
        lock (@lock)
          foreach (var csel in result)
          {
            if (!res.ContainsKey(csel.Key))
              res.Add(csel.Key, new Dictionary<Guid, Dictionary<int, List<int>>>());
            foreach (var dsel in csel.Value)
            {
              if (!res[csel.Key].ContainsKey(dsel.Key))
                res[csel.Key].Add(dsel.Key, new Dictionary<int, List<int>>());
              foreach (var ssel in dsel.Value)
              {
                if (!res[csel.Key][dsel.Key].ContainsKey(ssel.Key))
                  res[csel.Key][dsel.Key].Add(ssel.Key, new List<int>());
                foreach (var widx in ssel.Value)
                  res[csel.Key][dsel.Key][ssel.Key].Add(widx);
              }
            }
          }
      });

      return res;
    }

    /// <summary>
    ///   Sucht in allen Sätzen nach Fundstellen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="query">Abfrage</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>> SearchOnWordLevel(
      Selection selection,
      AbstractFilterQuery query)
    {
      var res = new Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>>();
      var @lock = new object();

      Parallel.ForEach(
                       selection,
                       Configuration.ParallelOptions,
                       csel =>
                       {
                         var corpus = selection.GetCorpus(csel.Key);
                         if (corpus == null)
                           return;

                         Parallel.ForEach(
                                          csel.Value,
                                          Configuration.ParallelOptions,
                                          dsel =>
                                          {
                                            var result = query.GetSentenceAndWordIndices(corpus, dsel);

                                            if (result == null || result.Count == 0)
                                              return;

                                            lock (@lock)
                                            {
                                              if (!res.ContainsKey(csel.Key))
                                                res.Add(csel.Key, new Dictionary<Guid, Dictionary<int, HashSet<int>>>());
                                              if (!res[csel.Key].ContainsKey(dsel))
                                                res[csel.Key].Add(dsel, new Dictionary<int, HashSet<int>>());
                                              foreach (var sidx in result)
                                              {
                                                if (!res[csel.Key][dsel].ContainsKey(sidx.Key))
                                                  res[csel.Key][dsel].Add(sidx.Key, new HashSet<int>());
                                                foreach (var widx in sidx.Value)
                                                  res[csel.Key][dsel][sidx.Key].Add(widx);
                                              }
                                            }
                                          });

                       });
      return res;
    }

    /// <summary>
    ///   Sucht in allen Sätzen nach Fundstellen.
    ///   Dabei werden die Ergebnisse nicht in einem HashSet gespeichert, sondern in einer Liste.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="query">Abfrage</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static Dictionary<Guid, Dictionary<Guid, Dictionary<int, List<int>>>> SearchOnWordLevelList(
      Selection selection,
      AbstractFilterQuery query)
    {
      var res = new Dictionary<Guid, Dictionary<Guid, Dictionary<int, List<int>>>>();
      var @lock = new object();

      Parallel.ForEach(
                       selection,
                       Configuration.ParallelOptions,
                       csel =>
                       {
                         var corpus = selection.GetCorpus(csel.Key);
                         if (corpus == null)
                           return;

                         Parallel.ForEach(
                                          csel.Value,
                                          Configuration.ParallelOptions,
                                          dsel =>
                                          {
                                            var result = query.GetSentenceAndWordIndices(corpus, dsel);

                                            if (result == null || result.Count == 0)
                                              return;

                                            lock (@lock)
                                            {
                                              if (!res.ContainsKey(csel.Key))
                                                res.Add(csel.Key, new Dictionary<Guid, Dictionary<int, List<int>>>());
                                              if (!res[csel.Key].ContainsKey(dsel))
                                                res[csel.Key].Add(dsel, new Dictionary<int, List<int>>());
                                              foreach (var sidx in result)
                                              {
                                                if (!res[csel.Key][dsel].ContainsKey(sidx.Key))
                                                  res[csel.Key][dsel].Add(sidx.Key, new List<int>());
                                                foreach (var widx in sidx.Value)
                                                  res[csel.Key][dsel][sidx.Key].Add(widx);
                                              }
                                            }
                                          });

                       });
      return res;
    }

    /// <summary>
    ///   Zählt in allen Sätzen nach Fundstellen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="queries">Abfragen</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static int CountOnWordLevel(Selection selection, IEnumerable<AbstractFilterQuery> queries)
      => queries.Sum(q => CountOnWordLevel(selection, q));

    /// <summary>
    ///   Zählt in allen Sätzen nach Fundstellen.
    /// </summary>
    /// <param name="selection">Schnappschuss auf dem die Suche ausgeführt wird</param>
    /// <param name="query">Abfrage</param>
    /// <returns>Key = CorpusGuid / Value.Key = DocumentGuid / Value.Value.Key = SatzId / Value.Value.Value = WortId</returns>
    public static int CountOnWordLevel(Selection selection, AbstractFilterQuery query)
    {
      try
      {
        return (from x in SearchOnWordLevel(selection, query)
                from y in x.Value
                from z in y.Value
                select z.Value.Count)
         .Sum();
      }
      catch
      {
        return 0;
      }
    }
  }
}