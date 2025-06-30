using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public static class SelectionJoiner
  {
    public static Dictionary<Guid, HashSet<Guid>> JoinToDictionary(this IEnumerable<Selection> selections)
    {
      var dict = new Dictionary<Guid, HashSet<Guid>>();
      if (selections == null)
        return dict;
      foreach (var selection in selections)
      {
        var sel = selection.CorporaAndDocumentGuids;
        if (sel == null)
          continue;

        foreach (var csel in sel)
        {
          if (!dict.ContainsKey(csel.Key))
            dict.Add(csel.Key, new HashSet<Guid>());
          foreach (var dsel in csel.Value)
            dict[csel.Key].Add(dsel);
        }
      }
      return dict;
    }

    public static Selection JoinFull(this IEnumerable<Selection> selections, string newSelectionDisplayname)
    {
      var list = selections.ToList();
      var first = selections.First();
      list.RemoveAt(0);

      foreach (var x in list)
        first = JoinFull(first, x, newSelectionDisplayname);

      return first;
    }

    public static Selection JoinFull(this Selection selectionA, Selection selectionB, string newSelectionDisplayname)
    {
      if (!selectionA.Project.Equals(selectionB.Project))
        throw new ArgumentException();

      var defA = selectionA.ToDictionary();
      var defB = selectionB.ToDictionary();

      foreach (var csel in defB)
        if (defA.ContainsKey(csel.Key))
          foreach (var dsel in csel.Value)
            defA[csel.Key].Add(dsel);
        else
          defA.Add(csel.Key, csel.Value);

      return string.IsNullOrEmpty(newSelectionDisplayname)
               ? selectionA.Project.CreateSelectionTemporary(defA)
               : selectionA.Project.CreateSelection(defA, newSelectionDisplayname);
    }

    public static Selection JoinInner(this Selection selectionA, Selection selectionB, string newSelectionDisplayname)
    {
      if (!selectionA.Project.Equals(selectionB.Project))
        throw new ArgumentException();

      var defA = selectionA.ToDictionary();
      var defB = selectionB.ToDictionary();
      var defC = new Dictionary<Guid, HashSet<Guid>>();

      foreach (var csel in defA)
      {
        if (!defB.ContainsKey(csel.Key))
          continue;

        var hs = new HashSet<Guid>();
        foreach (var guid in csel.Value.Where(guid => defB[csel.Key].Contains(guid)))
          hs.Add(guid);

        defC.Add(csel.Key, hs);
      }

      return string.IsNullOrEmpty(newSelectionDisplayname)
               ? selectionA.Project.CreateSelectionTemporary(defC)
               : selectionA.Project.CreateSelection(defC, newSelectionDisplayname);
    }

    public static Selection JoinLeft(this Selection selectionA, Selection selectionB, string newSelectionDisplayname)
    {
      if (!selectionA.Project.Equals(selectionB.Project))
        throw new ArgumentException();

      var defA = selectionA.ToDictionary();
      var defB = selectionB.ToDictionary();

      foreach (var csel in defB)
      {
        if (defA.ContainsKey(csel.Key))
          foreach (var dsel in csel.Value.Where(dsel => defA[csel.Key].Contains(dsel)))
            defA[csel.Key].Remove(dsel);

        if (defA[csel.Key].Count == 0)
          defA.Remove(csel.Key);
      }

      selectionA.Project.CreateSelection(defA, newSelectionDisplayname);

      return string.IsNullOrEmpty(newSelectionDisplayname)
               ? selectionA.Project.CreateSelectionTemporary(defA)
               : selectionA.Project.CreateSelection(defA, newSelectionDisplayname);
    }

    public static Selection JoinOuter(this Selection selectionA, Selection selectionB, string newSelectionDisplayname)
    {
      if (!selectionA.Project.Equals(selectionB.Project))
        throw new ArgumentException();

      var defA = selectionA.ToDictionary();
      var defB = selectionB.ToDictionary();
      var defC = new Dictionary<Guid, HashSet<Guid>>();

      foreach (var csel in defA)
      {
        if (!defB.ContainsKey(csel.Key))
        {
          defC.Add(csel.Key, csel.Value);
          continue;
        }

        var hs = new HashSet<Guid>();
        foreach (var guid in csel.Value.Where(guid => !defB[csel.Key].Contains(guid)))
          hs.Add(guid);

        defC.Add(csel.Key, hs);
      }

      return string.IsNullOrEmpty(newSelectionDisplayname)
               ? selectionA.Project.CreateSelectionTemporary(defC)
               : selectionA.Project.CreateSelection(defC, newSelectionDisplayname);
    }
  }
}