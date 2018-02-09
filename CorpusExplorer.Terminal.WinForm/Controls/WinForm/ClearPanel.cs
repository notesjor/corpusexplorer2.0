#region

using System.ComponentModel;
using Telerik.WinControls;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public class ClearPanel : RadPanel
  {
    public ClearPanel()
    {
      PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
      Text = "";
    }
  }
}