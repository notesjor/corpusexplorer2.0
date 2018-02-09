namespace Bcs.Addon.Interfaces
{
  /// <summary>
  ///   Hostet Addons
  /// </summary>
  public interface IAddonHost
  {
    /// <summary>
    ///   Dem <see cref="AddonHost" /> zugeordnetes <see cref="Window" /> (WPF) oder
    ///   Form (WinForm)
    /// </summary>
    IHostWindow Window { get; }

    /// <summary>
    ///   Gibt das Addon mit dem eindeutigen Bezeichner zurück
    /// </summary>
    /// <param name="guid">Eindeutiger Bezeichner des Addons</param>
    /// <returns>
    ///   Addon (Im Fehlerfall: null)
    /// </returns>
    IAddon GetAddonBy(string guid);
  }
}