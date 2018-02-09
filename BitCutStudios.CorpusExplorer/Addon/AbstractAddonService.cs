#region

using Bcs.Addon.Interfaces;

#endregion

namespace Bcs.Addon
{
  /// <summary>
  ///   Abstrakter AddonService
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class AbstractAddonService<T> : IAddon, IService
    where T : IServiceContract
  {
    /// <summary>
    ///   Gets or sets the contract.
    /// </summary>
    /// <value>The contract.</value>
    public abstract T Contract { get; protected set; }

    /// <summary>
    ///   AddonHost der dieses Addon verwaltet
    /// </summary>
    /// <value>The addon host.</value>
    public IAddonHost AddonHost { get; set; }

    /// <summary>
    ///   Eindeutige Bezeichnung (Name) des Addons
    /// </summary>
    /// <value>The GUID.</value>
    public abstract string Guid { get; }

    /// <summary>
    ///   Funktion die beim Laden des Addons in den Speicher aufgerufen wird
    /// </summary>
    public abstract void Initialize();

    /// <summary>
    ///   (Ent-)Lade Priorität des Plugins (Normal: Level2System)
    /// </summary>
    /// <value>The load priority.</value>
    public virtual AddonLoadPriority LoadPriority => AddonLoadPriority.Level1Boot;

    /// <summary>
    ///   Funktion die zum Ausführen des Addons aufgerufen wird
    /// </summary>
    public abstract void Start();

    /// <summary>
    ///   Funktion die zum Unterbrechen der Ausführung des Addons aufgerufen wird
    /// </summary>
    public abstract void Stop();

    /// <summary>
    ///   Funktion die beim Entfernen des Addons aus dem Speicher aufgerufen wird
    /// </summary>
    public abstract void Terminate();
  }
}