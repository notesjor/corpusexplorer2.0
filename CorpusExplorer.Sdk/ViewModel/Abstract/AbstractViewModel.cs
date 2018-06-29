#region

using System;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel.Abstract
{
  public abstract class AbstractViewModel : IViewModel
  {
    /// <summary>
    ///   Führt die Anylse des ViewModels aus.
    /// </summary>
    /// <returns><c>true</c> wenn Analyse zulässig und erfolgreich, <c>false</c> unzulässig oder Ausnahme.</returns>
    public bool Analyse()
    {
      if (Selection == null ||
          !IsValid)
        return false;
      try
      {
        ExecuteAnalyse();
        return true;
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return false;
      }
    }

    public bool IsValid
    {
      get
      {
        try
        {
          return Validate();
        }
        catch
        {
          return false;
        }
      }
    }

    public Selection Selection { get; set; }
    protected abstract void ExecuteAnalyse();
    protected abstract bool Validate();
  }
}