#region

using System.Drawing;
using CorpusExplorer.Sdk.Addon.Example.Properties;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering
{
  public class WordcloudVisualisationView : IAddonView
  {
    private WordcloudVisualisation _vm;

    /// <summary>
    ///   Icon das für dieses Addon angezeigt wird (wird nicht von allen Terminals unterstützt).
    ///   Es wird empfohlen ein PNG-Bild mit einer Auflösung von 24*24 Pixeln bereitzustellen.
    /// </summary>
    public Image Image24X24 => Resources.jor24x24;

    /// <summary>
    ///   Icon das für dieses Addon angezeigt wird (wird nicht von allen Terminals unterstützt).
    ///   Es wird empfohlen ein PNG-Bild mit einer Auflösung von 48*48 Pixeln bereitzustellen.
    /// </summary>
    public Image Image48X48 => Resources.jor48x48;

    /// <summary>
    ///   Wird aufgerufen wenn die View angezeigt werden soll.
    /// </summary>
    /// <param name="selection">Aktuelles Auswahl auf die das Addon seine Analyse anwenden soll.</param>
    /// <param name="addonViewContainer">
    ///   Übergeordneter Addon-Container. Der Addon-Hersteller muss sicherstellen, dass er
    ///   kompatible GUI-Addon bereitstellt.
    /// </param>
    public void Initialize(IAddonViewContainer addonViewContainer)
    {
      _vm = new WordcloudVisualisation();
      addonViewContainer.Add(_vm);
    }

    /// <summary>
    ///   Name/Bezeichnung des Addons. Achten Sie auf eine möglichst kurze Bezeichnung.
    /// </summary>
    public string Label { get { return "Beispiel Addon (Level 200)"; } }

    public void Refresh(Selection selection) { _vm.Refresh(selection); }
  }
}