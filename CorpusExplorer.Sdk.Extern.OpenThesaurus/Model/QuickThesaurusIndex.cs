using System;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Extern.OpenThesaurus.Model
{
  public class QuickThesaurusIndex : IDisposable
  {
    private readonly Dictionary<string, HashSet<string>> _entries = new Dictionary<string, HashSet<string>>();
    private readonly Dictionary<string, HashSet<string>> _reverseEntries = new Dictionary<string, HashSet<string>>();

    /// <summary>
    ///   Invertierter Index
    /// </summary>
    public IEnumerable<KeyValuePair<string, HashSet<string>>> ReverseEntries
      => _reverseEntries;

    /// <summary>
    ///   Auflistung aller ThesaurusEntries (Synonym-Gruppen)
    /// </summary>
    /// <value>Auflistung aller ThesaurusEntries (Synonym-Gruppen)</value>
    public IEnumerable<string> ThesaurusEntries
      => _entries.Keys;

    public void Dispose()
    {
      _reverseEntries.Clear();
      _entries.Clear();
    }

    /// <summary>
    ///   Fügt dem hesaurus einen neuen Eintrag hinzu
    /// </summary>
    /// <param name="synonyms">Synonyme (erstes Wort in der Liste wird zum ThesaurusEntry)</param>
    public void Add(string[] synonyms)
    {
      var entries = synonyms.Where(x => !string.IsNullOrWhiteSpace(x));

      string eid = null;
      foreach (var entry in entries)
      {
        if (eid == null)
          eid = entry.Trim();

        SafeAdd(eid, entry.Trim());
      }
    }

    private void SafeAdd(string eid, string entry)
    {
      if (_entries.ContainsKey(eid))
        _entries[eid].Add(entry);
      else
        _entries.Add(eid, new HashSet<string> {entry});

      if (_reverseEntries.ContainsKey(entry))
        _reverseEntries[entry].Add(eid);
      else
        _reverseEntries.Add(entry, new HashSet<string> {eid});
    }

    /// <summary>
    ///   Gibt alle Einträge zurück, die unter dem ThesaurusEntry gelistet sind
    /// </summary>
    /// <value>Gibt alle Einträge zurück, die unter dem ThesaurusEntry gelistet sind</value>
    public IEnumerable<string> GetAllOfSpecificThesaurusEntry(string thesaurusEntry)
    {
      return _entries[thesaurusEntry];
    }

    /// <summary>
    ///   Gibt eine Auflistung aller ThesaurusEntries (Synonym-Gruppen) zurück, die wordOrPhrase als Eintrag enthalten
    /// </summary>
    /// <param name="wordOrPhrase">Wort oder Phrase</param>
    /// <value>Gibt eine Auflistung aller ThesaurusEntries (Synonym-Gruppen) zurück, die wordOrPhrase als Eintrag enthalten</value>
    public IEnumerable<string> GetAllThesaurusEntries(string wordOrPhrase)
    {
      return _reverseEntries[wordOrPhrase];
    }

    /// <summary>
    ///   Gibt alle Kontexte zurück, in denen wordOrPhrase als Eintrag vorkommt.
    /// </summary>
    /// <param name="wordOrPhrase">Wort oder Phrase</param>
    /// <returns>Gibt alle Kontexte zurück, in denen wordOrPhrase als Eintrag vorkommt.</returns>
    public Dictionary<string, IEnumerable<string>> GetContexts(string wordOrPhrase)
    {
      return _reverseEntries[wordOrPhrase].ToDictionary(x => x, x => (IEnumerable<string>) _entries[x]);
    }

    /// <summary>
    ///   Alle Synonyme für wordOrPhrase.
    /// </summary>
    /// <param name="wordOrPhrase">Wort oder Phrase</param>
    /// <returns>Alle Synonyme für wordOrPhrase.</returns>
    public IEnumerable<string> GetSynonyms(string wordOrPhrase)
    {
      return _reverseEntries[wordOrPhrase].SelectMany(x => _entries[x]);
    }

    /// <summary>
    ///   Reduziert alle Schlüssel auf eine 1-zu-N-Beziehung
    /// </summary>
    internal void LaunchPostProcessing()
    {
      // Bereingung von N-zu-N-Keys
      foreach (var x in _reverseEntries.Keys.ToArray())
      {
        // Wenn keine Dopplung im Reverse-Index, dann fahre fort.
        if (_reverseEntries[x].Count == 1)
          continue;

        // Wenn sich der Wert selbst beinhaltet, dann nehme ihn als Master-Value
        if (!_reverseEntries[x].Contains(x))
          continue;

        var old = _reverseEntries[x]; // Entferne Selbstreferenz
        old.Remove(x);
        _reverseEntries[x] = new HashSet<string> {x};

        // Setze alle Werte auf den neuen Master-Value
        foreach (var o in old)
          if (_reverseEntries.ContainsKey(o))
            _reverseEntries[o] = new HashSet<string> {x};
          else
            _reverseEntries.Add(o, new HashSet<string> {x});
      }

      // Bereingung von N-zu-M-Keys
      foreach (var x in _reverseEntries.Keys.ToArray())
      {
        // Wenn keine Dopplung im Reverse-Index, dann fahre fort.
        if (_reverseEntries[x].Count == 1)
          continue;

        var test = _reverseEntries[x]; // Entfernte Referenzen

        // Finde Master
        string master = null;
        var neu = new List<string>();
        foreach (var t in test)
        {
          if (_reverseEntries.ContainsKey(t) && _reverseEntries[t].Count == 1 && master == null)
            master = t;
          if (!_reverseEntries.ContainsKey(t))
            neu.Add(t);
        }

        if (master == null)
          continue;

        _reverseEntries[x] = new HashSet<string> {master};
        foreach (var n in neu)
          _reverseEntries.Add(n, new HashSet<string> {master});
      }
    }
  }
}