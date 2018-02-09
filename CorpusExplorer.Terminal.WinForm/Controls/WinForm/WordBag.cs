using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class WordBag : AbstractUserControl
  {
    private Selection _selection;

    public WordBag() { InitializeComponent(); }

    public IEnumerable<string> Queries
    {
      get
      {
        return radAutoCompleteBox1.Text.Replace(" ", "").Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
      }
      set { radAutoCompleteBox1.Text = string.Join(";", value); }
    }

    public string SelectedLayer { get { return cmb_layer.SelectedItem.Text; } }

    public Selection Selection
    {
      get { return _selection; }
      set
      {
        _selection = value;
        if (value == null)
          return;
        cmb_layer.DataSource = value.LayerUniqueDisplaynames;
      }
    }

    public void AddToRow1(CommandBarStripElement strip) { commandBarRowElement1.Strips.Add(strip); }

    private void btn_go_Click(object sender, EventArgs e)
    {
      try
      {
        if ((Queries == null) ||
            !Queries.Any())
          throw new ArgumentException();
      }
      catch
      {
        MessageBox.Show(
          Resources.Snapshot_GreenValueError,
          Resources.Snapshot_GreenValueHintHead,
          MessageBoxButton.OK,
          MessageBoxImage.Warning);
        return;
      }

      ExecuteButtonClicked?.Invoke(sender, e);
    }

    private void cmb_layer_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (e.Position == -1)
        return;

      radAutoCompleteBox1.Text = null;
      radAutoCompleteBox1.AutoCompleteDataSource = Selection.GetLayerValues(cmb_layer.SelectedItem.Text);
    }

    public event EventHandler ExecuteButtonClicked;
  }
}