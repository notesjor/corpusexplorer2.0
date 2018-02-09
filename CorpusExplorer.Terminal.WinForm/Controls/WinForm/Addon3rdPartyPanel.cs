#region

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Addon;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(false)]
  public partial class Addon3rdPartyPanel : RadScrollablePanel, IAddonViewContainer
  {
    public Addon3rdPartyPanel()
    {
      InitializeComponent();
      VerticalScrollBarState = ScrollState.AlwaysShow;
    }

    public void Add(object control)
    {
      Controls.Clear();

      if (!(control is UserControl))
        return;

      var c = (UserControl) control;
      c.Size = Size;
      c.Location = new Point(0, 0);
      c.Dock = DockStyle.Fill;

      PanelContainer.Controls.Add(c);
    }
  }
}