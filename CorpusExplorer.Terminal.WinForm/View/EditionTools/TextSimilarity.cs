using System.Drawing;
using System.Linq;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.Data;

#region

using System;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.EditionTools
{
  /// <summary>
  ///   The text similarity page.
  /// </summary>
  public partial class TextSimilarity : AbstractView
  {
    private DocumentSimilarityViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public TextSimilarity()
    {
      InitializeComponent();
    }

    private void TextSimilarityPage_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<DocumentSimilarityViewModel>();
      combo_meta.DataSource = _vm.DocumentMetaProperties;
      combo_meta.SelectedIndex = 0;
    }

    private void btn_go_Click(object sender, EventArgs e)
    {
      Processing.Invoke("Suche nach Ähnlichkeiten...", () =>
      {
        _vm.MetadataKey = combo_meta.SelectedItem.Text;
        _vm.Execute();

        radGridView1.DataSource = _vm.GetDataTable();
        radGridView1.Refresh();
        radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        radGridView1.AllowAutoSizeColumns = true;
        radGridView1.EnableGrouping = true;
        radGridView1.EnableFiltering = true;
      });
    }

    private void btn_search_Click(object sender, EventArgs e)
    {
      radGridView1.FilterDescriptors.Clear();

      var composite = new CompositeFilterDescriptor { LogicalOperator = FilterLogicalOperator.Or };

      composite.FilterDescriptors.Add(
                                      new FilterDescriptor
                                      {
                                        PropertyName = Resources.StringLabel,
                                        Operator = FilterOperator.Contains,
                                        Value = txt_query.Text,
                                        IsFilterEditor = true
                                      });
      composite.FilterDescriptors.Add(
                                      new FilterDescriptor
                                      {
                                        PropertyName = Resources.Cooccurrence,
                                        Operator = FilterOperator.Contains,
                                        Value = txt_query.Text,
                                        IsFilterEditor = true
                                      });

      radGridView1.FilterDescriptors.Add(composite);
    }
  }
}