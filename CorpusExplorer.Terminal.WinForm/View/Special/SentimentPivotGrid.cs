using System.IO;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.SentimentDetection.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SentimentDetection;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Localizer.PivotGrid;
using Telerik.Pivot.Core;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  public partial class SentimentPivotGrid : AbstractView
  {
    private SentimentDetectionViewModel _vm;

    public SentimentPivotGrid()
    {
      PivotGridLocalizationProvider.CurrentProvider = new PivotGridViewGermanLocalizer();
      InitializeComponent();
    }

    private void commandBarButton2_Click(object sender, System.EventArgs e)
    {
      var form = new SentimentDetectionConfiguration();
      if (form.ShowDialog() != DialogResult.OK)
        return;

      commandBarLabel1.Text = $"Das Model ist: {form.ModelDisplayname}";
      _vm = GetViewModel<SentimentDetectionViewModel>();
      _vm.LayerDisplayname = "Wort";

      Processing.Invoke("Sentiment Detection läuft...", () =>
      {
        _vm.Model = form.Model;

        if (!_vm.Execute())
          return;

        var dataProvider = new LocalDataSourceProvider
        {
          ItemsSource = _vm.GetDataTable()
        };
        radPivotGrid1.DataProvider = dataProvider;
      });
    }
  }
}