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

    private void InitializeComponent()
    {
      ((ISupportInitialize) this).BeginInit();
      SuspendLayout();
      ((ISupportInitialize) this).EndInit();
      ResumeLayout(false);
    }
  }
}