#region

using System;
using System.Windows.Forms;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Localizer.PivotGrid;
using Telerik.Pivot.Core;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
  public partial class FrequencyPivotGrid : AbstractView
  {
    private readonly string _fileFilter = "Pivot-Layout (*.pivot)|*.pivot";

    public FrequencyPivotGrid()
    {
      PivotGridLocalizationProvider.CurrentProvider = new PivotGridViewGermanLocalizer();
      InitializeComponent();
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      DataTableExporter.Export(radPivotGrid1);
    }

    private void btn_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog {Filter = _fileFilter};
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      radPivotGrid1.LoadLayout(ofd.FileName);
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {Filter = _fileFilter};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      radPivotGrid1.SaveLayout(sfd.FileName);
    }

    private void PivotGridVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      Processing.Invoke(
        null,
        Analyse);
    }

    private void Analyse()
    {
      var vm = GetViewModel<FrequencyViewModel>();
      if (SelectedLayerDisplaynames != null)
        vm.LayerDisplaynames = SelectedLayerDisplaynames;
      if (!vm.Analyse())
        return;

      var dataProvider = new LocalDataSourceProvider
      {
        ItemsSource = vm.GetDataTable()
      };
      radPivotGrid1.DataProvider = dataProvider;
    }

    private void btn_layer_Click(object sender, EventArgs e)
    {
      var form = new Select3Layer(SelectedLayerDisplaynames);
      form.ShowDialog();
      SelectedLayerDisplaynames = form.ResultSelectedLayerDisplaynames;
      Analyse();
    }
  }
}