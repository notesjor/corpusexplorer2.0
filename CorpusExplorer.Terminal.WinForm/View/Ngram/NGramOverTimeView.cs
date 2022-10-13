#region

using System;
using System.Data;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class NGramOverTimeView : AbstractGridViewWithTextLense
  {
    private NgramViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public NGramOverTimeView()
    {
      InitializeComponent();
    }

    private void Analyse()
    {
      _vm = GetViewModel<NgramViewModel>();
      _vm.NGramSize = int.Parse(txt_size.Text);
      _vm.NGramPatternSize = 0;
      if (SelectedLayerDisplaynames != null)
        _vm.LayerDisplayname = SelectedLayerDisplaynames[0];
      if (!_vm.Execute())
        return;
      BindData();

      UseParentCellForHighlighting = Resources.NGramm;
      AddSummaryRow();
      ApplyFilterDelay();
      AddChildTemplate(
                       delegate(DataRowView x)
                       {
                         var queries = x[Resources.NGramm].ToString()
                                                          .Replace(_vm.NGramPattern,
                                                                   FilterQuerySingleLayerExactPhrase.SearchPattern)
                                                          .Split(Splitter.Space, StringSplitOptions.RemoveEmptyEntries);
                         return new FilterQuerySingleLayerExactPhrase
                         {
                           Inverse = false,
                           LayerDisplayname = _vm.LayerDisplayname,
                           LayerQueries = queries
                         };
                       });
    }

    private void BindData()
    {
    }

    private void btn_execute_Click(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.ErstelleUndZähleNGramme, Analyse);
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      DataTableExporter.Export(_vm.GetDataTable());
    }

    private void GridNGramVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<NgramViewModel>();
    }

    private void btn_layer_Click(object sender, EventArgs e)
    {
      var form = new Select1Layer(SelectedLayerDisplaynames);
      form.ShowDialog();
      SelectedLayerDisplaynames = form.ResultSelectedLayerDisplaynames;
      Analyse();
    }
  }
}