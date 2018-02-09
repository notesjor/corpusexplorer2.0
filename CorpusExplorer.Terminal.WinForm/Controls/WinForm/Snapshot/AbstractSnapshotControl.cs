#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Snapshot
{
  [ToolboxItem(false)]
  public partial class AbstractSnapshotControl : UserControl
  {
    protected AbstractSnapshotControl() { Initialize(); }

    public AbstractSnapshotControl(Selection selection)
    {
      Selection = selection;
      Initialize();
    }

    public virtual AbstractFilterQuery Query { get { return null; } }

    protected Selection Selection { get; set; }

    private void btn_remove_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(
            Resources.Snapshot_ConditionDelete,
            Resources.Snapshot_ConditionDeleteHead,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) == DialogResult.No)
        return;

      QueryRemove?.Invoke(this, null);
    }

    private void Initialize()
    {
      ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      InitializeComponent();
      Font = new Font("Segoe UI", 11);
    }

    public event EventHandler QueryRemove;
  }
}