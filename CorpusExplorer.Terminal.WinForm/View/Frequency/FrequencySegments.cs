using System;
using System.Windows;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Segements;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;

namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
  public partial class FrequencySegments : AbstractView
  {
    private readonly SegmentView _wpfDoc;
    private readonly SegmentView _wpfSen;
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
    }

    private void btn_execute_Click(object sender, EventArgs e)
    {
      if ((combo_layer.SelectedItem == null) ||
          string.IsNullOrEmpty(txt_query.Text))
        return;

      _vm.LayerDisplayname = combo_layer.SelectedItem.Text;
      _vm.Queries = txt_query.Text.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
      _vm.Analyse();

      _wpfDoc.SetSegements(_vm.GranulatedDocument);
      _wpfSen.SetSegements(_vm.GranulatedSentence);
    }

    private void SegmentVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = ViewModelGet<DocumentGranulationViewModel>();
      combo_layer.DataSource = _vm.Layers;
    }
  }
}