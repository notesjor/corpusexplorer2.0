#region

using System;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Localizer.PivotGrid;
using Telerik.Pivot.Core;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.StyleMetrics
{
  public partial class ReadingEasePivotGrid : AbstractView
  {
    public ReadingEasePivotGrid()
    {
      PivotGridLocalizationProvider.CurrentProvider = new PivotGridViewGermanLocalizer();
      InitializeComponent();
    }

    private void PivotGridVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      Processing.Invoke(
        null,
        () =>
        {
          var vm = ViewModelGet<ReadingEaseViewModel>();
          vm.Analyse();

          var dataProvider = new LocalDataSourceProvider
          {
            ItemsSource = vm.GetDataTable()
          };
          radPivotGrid1.DataProvider = dataProvider;
        });
    }
  }
}