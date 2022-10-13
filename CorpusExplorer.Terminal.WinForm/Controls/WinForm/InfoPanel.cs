#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  /// <summary>
  ///   The help panel.
  /// </summary>
  [ToolboxItem(true)]
  public partial class InfoPanel : UserControl
  {
    /// <summary>
    ///   Initialisiert eine neue Instanz der <see cref="HelpPanel" /> Klasse.
    /// </summary>
    public InfoPanel()
    {
      InitializeComponent();
    }

    public long CountCorpora { get => num_corpora.Value; set => num_corpora.Value = value; }
    public long CountDocuments { get => num_docs.Value; set => num_docs.Value = value; }
    public long CountLayers { get => num_layer.Value; set => num_layer.Value = value; }
    public long CountTokens { get => num_token.Value; set => num_token.Value = value; }
  }
}