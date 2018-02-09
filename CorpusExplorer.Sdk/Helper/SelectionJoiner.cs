using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public static class SelectionJoiner
  {
    public static Selection JoinFull(this Selection selectionA, Selection selectionB, string newSelectionDisplayname)
    {
      var defA = selectionA.ToDictionary();
      var defB = selectionB.ToDictionary();

      foreach (var csel in defB)
        if (defA.ContainsKey(csel.Key))
          foreach (var dsel in csel.Value)
            defA[csel.Key].Add(dsel);
        else
          defA.Add(csel.Key, csel.Value);

      return selectionA.Project.Equals(selectionB.Project)
               ? selectionA.Project.CreateSelection(defA, newSelectionDisplayname)
               : selectionA.Project.JoinFull(selectionB.Project).SelectAll.Create(defA, newSelectionDisplayname);
    }

    public static Selection JoinInner(this Selection selectionA, Selection selectionB, string newSelectionDisplayname)
    {
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

      return selectionA.Project.Equals(selectionB.Project)
               ? selectionA.Project.CreateSelection(defC, newSelectionDisplayname)
               : selectionA.Project.JoinFull(selectionB.Project).SelectAll.Create(defC, newSelectionDisplayname);
    }

    public static Selection JoinLeft(this Selection selectionA, Selection selectionB, string newSelectionDisplayname)
    {
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

      return selectionA.Project.Equals(selectionB.Project)
               ? selectionA.Project.CreateSelection(defA, newSelectionDisplayname)
               : selectionA.Project.JoinFull(selectionB.Project).SelectAll.Create(defA, newSelectionDisplayname);
    }

    public static Selection JoinOuter(this Selection selectionA, Selection selectionB, string newSelectionDisplayname)
    {
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

      return selectionA.Project.Equals(selectionB.Project)
               ? selectionA.Project.CreateSelection(defC, newSelectionDisplayname)
               : selectionA.Project.JoinFull(selectionB.Project).SelectAll.Create(defC, newSelectionDisplayname);
    }
  }
}