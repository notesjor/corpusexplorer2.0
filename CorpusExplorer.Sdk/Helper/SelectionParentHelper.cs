using System;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public static class SelectionParentHelper
  {
    /// <summary>
    ///   Gibt die übergeordnete Selection zurück.
    /// </summary>
    /// <param name="selection">Selection zu der die übergeordnete Selection gesucht werden soll.</param>
    /// <returns>
    ///   Gibt die übergeordnete Selection zurück. Wenn die Selection direkt Project unterstellt ist,
    ///   dann wird Project.SelectAll zurück gegeben. Wenn es sich um eine temporäre Selection handelt wird null
    ///   zurückgegeben.
    /// </returns>
    public static Selection GetParentSelection(this Selection selection)
    {
      var proj = selection.Project;
      foreach (var s in proj.Selections)
      {
        if (s.Guid == selection.Guid)
          return proj.SelectAll;

        var res = GetParentSelection(s, selection.Guid);
        if (res != null)
          return res;
      }

      return null;
    }

    private static Selection GetParentSelection(Selection selection, Guid guid)
    {
      foreach (var s in selection.SubSelections)
      {
        if (s.Guid == guid)
          return selection;

        var res = GetParentSelection(s, guid);
        if (res != null)
          return res;
      }

      return null;
    }
  }
}