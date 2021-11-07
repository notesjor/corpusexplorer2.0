using System;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Extern.SentimentDetection.Model;
using CorpusExplorer.Sdk.Extern.SentimentDetection.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SentimentDetection;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Localizer.PivotGrid;
using Telerik.Pivot.Core;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  public partial class SentimentPivotGrid : AbstractView
  {
    private SentimentDetectionViewModel _vm;
    private readonly string _fileFilter = "Pivot-Layout (*.pivot)|*.pivot";

    public SentimentPivotGrid()
    {
      PivotGridLocalizationProvider.CurrentProvider = new PivotGridViewGermanLocalizer();
      InitializeComponent();
    }

    private void commandBarButton2_Click(object sender, EventArgs e)
    {
      var form = new SentimentDetectionConfiguration();
      if (form.ShowDialog() != DialogResult.OK)
        return;

      commandBarLabel1.Text = $"Das Model ist: {form.ModelDisplayname}";
      _vm = GetViewModel<SentimentDetectionViewModel>();
      _vm.LayerDisplayname = "Wort";

      Processing.Invoke("Sentiment Detection läuft...", () =>
      {
        _vm.Model = form.GetModel<SentimentDetectionTagModel>();

        if (!_vm.Execute())
          return;

        var dataProvider = new LocalDataSourceProvider
        {
          ItemsSource = _vm.GetDataTable()
        };
        radPivotGrid1.DataProvider = dataProvider;
      });
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      DataTableExporter.Export(radPivotGrid1);
    }

    private void btn_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog { Filter = _fileFilter };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      radPivotGrid1.LoadLayout(ofd.FileName);
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = _fileFilter };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      radPivotGrid1.SaveLayout(sfd.FileName);
    }
  }
}