using System;
using System.Windows;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Colorizer;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Segements;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;

namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
  public partial class FrequencySegments : AbstractView
  {
    private readonly SegmentView _wpfDoc;
    private readonly SegmentView _wpfSen;
    private readonly Colorizer _wpfColorizer;
    private DocumentGranulationViewModel _vm;

    public FrequencySegments()
    {
      InitializeComponent();

      _wpfDoc = new SegmentView
      {
        HorizontalAlignment = HorizontalAlignment.Stretch,
        VerticalAlignment = VerticalAlignment.Stretch
      };

      elementHost1.Child = _wpfDoc;

      _wpfSen = new SegmentView
      {
        HorizontalAlignment = HorizontalAlignment.Stretch,
        VerticalAlignment = VerticalAlignment.Stretch
      };

      elementHost2.Child = _wpfSen;

      _wpfColorizer = new Colorizer
      {
        HorizontalAlignment = HorizontalAlignment.Stretch,
        VerticalAlignment = VerticalAlignment.Stretch
      };
      _wpfColorizer.ColorsChanged += _wpfColorizer_ColorsChanged;

      elementHost3.Child = _wpfColorizer;
    }

    private void _wpfColorizer_ColorsChanged(object sender, EventArgs e)
    {
      _wpfDoc.SetColorizer(_wpfColorizer);
      _wpfSen.SetColorizer(_wpfColorizer);
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      DataTableExporter.Export(_vm.GetDataTable());
    }

    private void SegmentVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<DocumentGranulationViewModel>();
      _wpfColorizer_ColorsChanged(null, null);
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      _vm.LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname;
      _vm.Queries = wordBag1.ResultQueries;
      Processing.Invoke("Zähle an allen Positionen...", () =>
      {
        if (!_vm.Analyse())
          return;

        _wpfDoc.SetSegements(_vm.GranulatedDocument);
        _wpfSen.SetSegements(_vm.GranulatedSentence);
      });
    }
  }
}