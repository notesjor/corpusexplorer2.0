using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.ViewModel.Interfaces
{
  public interface IViewModel
  {
    /// <summary>
    ///   Ist das ViewModel valide? Sind alle nötigen Paramter gesetzt um eine Analyse ausführen zu können?
    /// </summary>
    /// <value>Valide?</value>
    bool IsValid { get; }

    /// <summary>
    ///   Mit welcher Selection arbeitet das ViewModel
    /// </summary>
    /// <value>The selection.</value>
    Selection Selection { get; set; }

    /// <summary>
    ///   Führt die Analyse durch
    /// </summary>
    /// <returns>War die Analyse erfolgreich?</returns>
    bool Execute();
  }
}