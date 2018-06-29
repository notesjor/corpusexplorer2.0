using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class WordBag : AbstractUserControl
  {
    public WordBag()
    {
      InitializeComponent();
    }

    public IEnumerable<string> ResultQueries
    {
      get => cmb_values.ResultQueries;
      set => cmb_values.ResultQueries = value;
    }

    public string ResultSelectedLayerDisplayname
    {
      get => cmb_values.SelectedLayerDisplayname;
      set => cmb_values.SelectedLayerDisplayname = value;
    }

    public event EventHandler ExecuteButtonClicked;

    private void btn_go_Click(object sender, EventArgs e)
    {
      try
      {
        if (ResultQueries == null ||
            !ResultQueries.Any())
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

    private void btn_selectLayer_Click(object sender, EventArgs e)
    {
      var form = new Select1Layer(new[] { "Wort" });
      form.ShowDialog();

      if (string.IsNullOrEmpty(form.ResultSelectedLayer1Displayname))
        return;

      if (ResultSelectedLayerDisplayname == form.ResultSelectedLayer1Displayname)
        return;

      ResultSelectedLayerDisplayname = form.ResultSelectedLayer1Displayname;
      SelectedLayerChanged?.Invoke(this, null);
    }

    public event EventHandler SelectedLayerChanged;
  }
}