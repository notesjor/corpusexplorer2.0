namespace Bcs.Addon.Interfaces
{
  /// <summary>
  ///   Form/Window oder Control das visuelles Addons hosten kann
  /// </summary>
  public interface IHostWindow
  {
    /// <summary>
    ///   AddonHost
    /// </summary>
    IAddonHost AddonHost { get; set; }

    /// <summary>
    ///   Wird vom Addon aufgerufen um Informationen an dieses Form/Window/Control zu senden.
    /// </summary>
    /// <param name="view">View</param>
    void SetGuiContent(IView view);
  }
}