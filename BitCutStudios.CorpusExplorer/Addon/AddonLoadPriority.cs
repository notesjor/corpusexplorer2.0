namespace Bcs.Addon
{
  /// <summary>
  ///   Enum der Addon-Lade-Priorität
  /// </summary>
  public enum AddonLoadPriority
  {
    /// <summary>
    ///   Läd noch vor dem Boot (Höchste Priorität)
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    Level0PreBoot = 10,

    /// <summary>
    ///   Bootvorgang (Hohe Priorität)
    /// </summary>
    Level1Boot = 20,

    /// <summary>
    ///   Systemanwendung (Normale Priorität)
    /// </summary>
    Level2System = 30,

    /// <summary>
    ///   Anwendungsebene (Geringe Priorität)
    /// </summary>
    Level3Applikation = 40,

    /// <summary>
    ///   Erweiterungsplugin (Sehr geringe Priorität)
    /// </summary>
    Level4ApplikationProcess = 50
  }
}