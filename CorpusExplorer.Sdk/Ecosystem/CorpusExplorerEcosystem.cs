#region

using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Cache;
using CorpusExplorer.Sdk.Model.Cache.Abstract;
using CorpusExplorer.Sdk.Terminal;

#endregion

namespace CorpusExplorer.Sdk.Ecosystem
{
  public static class CorpusExplorerEcosystem
  {
    private static TerminalController _controller;

    /// <summary>
    ///   Initialisiert ein vollständiges CorpusExplorer-Ökosystem.
    /// </summary>
    /// <param name="cacheStrategy">
    ///   Erlaubt es das Block-Caching-Verhalten zu ändern. Für Initialize(null) ist
    ///   CacheStrategyCurrentSelection festgelegt.
    /// </param>
    /// <param name="alternative3rdPartyPath">
    /// Normalerweise wird nur im Pfad der aktuellen EXEcutable nach 3rd-Party-Addons gesucht.
    /// Mit diesem Parameter kann ein anderer Ordner als Suchpfad angegeben werden.
    /// </param>
    /// <returns>TerminalController - erlaubt das Verwalten von Projekten</returns>
    public static TerminalController Initialize(AbstractCacheStrategy cacheStrategy = null, string alternative3rdPartyPath = null)
    {
      if (_controller != null)
        return _controller;

      Configuration.Initialize(InitialOptionsEnum.MinimalAnd3rdParty, alternative3rdPartyPath: alternative3rdPartyPath);
      Configuration.Cache = cacheStrategy ?? new CacheStrategyCurrentSelection();
      _controller = new TerminalController();
      _controller.ProjectNew();

      return _controller;
    }

    /// <summary>
    ///   Initialisiert ein minimales CorpusExplorer-Ökosystem.
    ///   Erlaubt keine Projektverwaltung
    /// </summary>
    /// <param name="cacheStrategy">
    ///   Erlaubt es das Block-Caching-Verhalten zu ändern. Für InitializeMinimal(null) ist
    ///   CacheStrategyDisableCaching festgelegt.
    /// </param>
    /// <param name="alternative3rdPartyPath">
    /// Normalerweise wird nur im Pfad der aktuellen EXEcutable nach 3rd-Party-Addons gesucht.
    /// Mit diesem Parameter kann ein anderer Ordner als Suchpfad angegeben werden.
    /// </param>
    /// <returns>Project</returns>
    public static Project InitializeMinimal(AbstractCacheStrategy cacheStrategy = null, string alternative3rdPartyPath = null)
    {
      if (_controller != null)
        return _controller.Project;

      Configuration.Initialize(InitialOptionsEnum.Minimal, alternative3rdPartyPath: alternative3rdPartyPath);
      Configuration.Cache = cacheStrategy ?? new CacheStrategyDisableCaching();
      _controller = new TerminalController();
      _controller.ProjectNew();

      return _controller.Project;
    }
  }
}