namespace Bcs.Addon.Interfaces
{
  /// <summary>
  /// </summary>
  public interface IAddon
  {
    /// <summary>
    ///   AddonHost der dieses Addon verwaltet
    /// </summary>
    IAddonHost AddonHost { get; set; }

    /// <summary>
    ///   Eindeutige Bezeichnung (Name) des Addons
    /// </summary>
    string Guid { get; }

    /// <summary>
    ///   (Ent-)Lade Priorität des Plugins (Normal: Level2System)
    /// </summary>
    AddonLoadPriority LoadPriority { get; }

    /// <summary>
    ///   Funktion die beim Laden des Addons in den Speicher aufgerufen wird
    /// </summary>
    void Initialize();

    /// <summary>
    ///   Funktion die zum Ausführen des Addons aufgerufen wird
    /// </summary>
    void Start();

    /// <summary>
    ///   Funktion die zum Unterbrechen der Ausführung des Addons aufgerufen wird
    /// </summary>
    void Stop();

    /// <summary>
    ///   Funktion die beim Entfernen des Addons aus dem Speicher aufgerufen wird
    /// </summary>
    void Terminate();
  }
}