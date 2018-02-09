#region

using System.Collections.Generic;
using System.ComponentModel;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
  [ToolboxItem(true)]
  public partial class WebRequestVisualisation : WebSimpleUrlVisualisation
  {
    public WebRequestVisualisation() { InitializeComponent(); }

    public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
  }
}