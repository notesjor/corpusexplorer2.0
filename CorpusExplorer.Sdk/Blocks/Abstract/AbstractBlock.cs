#region

using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.CorpusExplorer;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Abstract
{
  /// <summary>
  ///   Abstrakter Analyseblock
  /// </summary>
  public abstract class AbstractBlock : CeObject
  {
    /// <summary>
    ///   The _selection.
    /// </summary>
    private Selection _selection;

    /// <summary>
    ///   Gets or sets the project.
    /// </summary>
    protected Project Project { get; set; }

    /// <summary>
    ///   Auswahl mit dem der Block arbeitet
    /// </summary>
    // ReSharper disable once MemberCanBeProtected.Global
    protected internal Selection Selection
    {
      get => _selection;
      set => _selection = value;
    }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public abstract void Calculate();

    /// <summary>
    ///   Ersetzt den Konsstruktor. Wird über Selection.CreateBlock aufgerufen.
    ///   Stellt sicher das pro Selection nur ein Block gleichen Typs exsistiert.
    /// </summary>
    /// <param name="project">
    ///   Projekt
    /// </param>
    /// <param name="selection">
    ///   Auswahl
    /// </param>
    /// <param name="block">
    ///   Block
    /// </param>
    /// <returns>
    ///   The <see cref="AbstractBlock" />.
    /// </returns>
    internal static AbstractBlock InitializeInstance(Project project, Selection selection, AbstractBlock block)
    {
      block._selection = selection;
      block.Project = project;
      return block;
    }
  }
}