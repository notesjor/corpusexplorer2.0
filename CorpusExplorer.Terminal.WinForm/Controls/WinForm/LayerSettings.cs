using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class LayerSettings : AbstractUserControl
  {
    private readonly List<string> _names;
    private bool _isLayerOptional;

    public LayerSettings()
    {
      InitializeComponent();
      _names = CorpusExplorerEcosystem.CurrentProject.LayerDisplaynames.ToList();
      cmb_names.Items.AddRange(_names);
    }

    public string Header
    {
      get => grp.Text;
      set => grp.Text = value;
    }

    public bool IsLayerOptional
    {
      get => _isLayerOptional;
      set => _isLayerOptional = chk_active.Visible = value;
    }

    public string ResultSelectedLayer => cmb_names.SelectedIndex == -1 ? null : _names[cmb_names.SelectedIndex];

    public bool ResultUseLayer
    {
      get
      {
        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (!IsLayerOptional)
          return true;
        return chk_active.Checked;
      }
    }

    public void SelectLayer(string initValue)
    {
      cmb_names.SelectedIndex = _names.IndexOf(initValue);
    }

    private void chk_active_CheckStateChanged(object sender, EventArgs e)
    {
      cmb_names.Enabled = chk_active.Checked;
    }
  }
}