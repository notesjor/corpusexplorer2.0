#region

using System.Drawing;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Addon
{
  /// <summary>
  ///   Interface IAddonView
  /// </summary>
  public interface IAddonView
  {
    /// <summary>
    ///   Icon das für dieses Addon angezeigt wird (wird nicht von allen Terminals unterstützt).
    ///   Es wird empfohlen ein PNG-Bild mit einer Auflösung von 24*24 Pixeln bereitzustellen.
    /// </summary>
    System.Drawing.Image Image24X24 { get; }

    /// <summary>
    ///   Icon das für dieses Addon angezeigt wird (wird nicht von allen Terminals unterstützt).
    ///   Es wird empfohlen ein PNG-Bild mit einer Auflösung von 48*48 Pixeln bereitzustellen.
    /// </summary>
    System.Drawing.Image Image48X48 { get; }

    /// <summary>
    ///   Name/Bezeichnung des Addons. Achten Sie auf eine möglichst kurze Bezeichnung.
    /// </summary>
    string Label { get; }

    /// <summary>
    ///   Wird aufgerufen wenn die View angezeigt werden soll.
    /// </summary>
    /// <param name="addonViewContainer">
    ///   Übergeordneter Addon-Container. Der Addon-Hersteller muss sicherstellen, dass er
    ///   kompatible GUI-Addon bereitstellt.
    /// </param>
    void Initialize(IAddonViewContainer addonViewContainer);

    /// <summary>
    ///   Wird aufgerufen, wenn die View angezeigt wird.
    /// </summary>
    /// <param name="selection">Aktuelles Auswahl auf die das Addon seine Analyse anwenden soll.</param>
    void Refresh(Selection selection);
  }
}