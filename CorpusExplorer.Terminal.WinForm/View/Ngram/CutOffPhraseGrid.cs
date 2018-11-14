#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class CutOffPhraseGrid : AbstractGridViewWithTextLense
  {
    private CutOffPhraseViewModel _vm;
    private DateTime _preventDoubleCommandClick2;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public CutOffPhraseGrid()
    {
      InitializeComponent();
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
      radGridView1.AllowAutoSizeColumns = true;
      InitializeGrid(radGridView1);
    }

    private void Analyse()
    {
      _vm = GetViewModel<CutOffPhraseViewModel>();
      _vm.WordSpan = int.Parse(txt_size.Text);
      _vm.LayerQuery1 = txt_start.Text;
      _vm.LayerQuery2 = txt_end.Text;
      if (SelectedLayerDisplaynames != null)
        _vm.LayerDisplayname = SelectedLayerDisplaynames[0];
      if (!_vm.Execute())
        return;
      BindData();

      UseParentCellForHighlighting = Resources.NGramm;

      AddSummaryRow();
    }

    private void BindData()
    {
      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();

      var pre = radGridView1.Columns["Pre"];
      pre.TextAlignment = ContentAlignment.MiddleRight;
      pre.AutoSizeMode = BestFitColumnMode.AllCells;
      pre.Name = Resources.Links;

      var match = radGridView1.Columns["Match"];
      match.TextAlignment = ContentAlignment.MiddleCenter;
      match.AutoSizeMode = BestFitColumnMode.AllCells;
      match.Name = Resources.Fundstelle;

      var post = radGridView1.Columns["Post"];
      post.TextAlignment = ContentAlignment.MiddleLeft;
      post.AutoSizeMode = BestFitColumnMode.AllCells;
      post.Name = Resources.Rechts;

      radGridView1.Columns["Frequenz"].MaxWidth = 80;
      radGridView1.Columns["Info"].IsVisible = false;

      radGridView1.Columns.Add(new GridViewCommandColumn(Resources.Details)
      {
        AllowFiltering = false,
        AllowGroup = false,
        HeaderText = "",
        DefaultText = "",
        UseDefaultText = true,
        MaxWidth = 37,
        Image = Resources.find
      });

      _grid.CommandCellClick += OnGridOnCommandCellClick;
    }

    private void OnGridOnCommandCellClick(object sender, GridViewCellEventArgs arg)
    {
      if ((DateTime.Now - _preventDoubleCommandClick2).Seconds < 1)
        return;

      if (!(sender is GridCommandCellElement cell))
        return;

      var vm = GetViewModel<QuickInfoTextViewModel>();
      vm.Documents = cell.RowElement.RowInfo.Cells["Info"].Value as IEnumerable<KeyValuePair<Guid, int>>;
      vm.Execute();

      var form = new SimpleTextView(vm.QuickDocumentInfoResults, Project);
      form.NewProperty += (o, a) => { vm.SetNewDocumentMetadata((KeyValuePair<string, Type>)o); };

      if (form.ShowDialog() == DialogResult.OK)
        foreach (var doc in form.Documents)
          Project.CurrentSelection.SetDocumentMetadata(doc.DocumentGuid, doc.DocumentMetadata);

      _preventDoubleCommandClick2 = DateTime.Now;
    }

    /// <summary>
    ///   The btn_calc_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_calc_Click(object sender, EventArgs e)
    {
      CalculatorFunction();
    }

    /// <summary>
    ///   The btn_csv export_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_csvExport_Click(object sender, EventArgs e)
    {
      ExportFunction();
    }

    private void btn_execute_Click(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.ErstelleUndZähleNGramme, Analyse);
    }

    private void btn_filtereditor_Click(object sender, EventArgs e)
    {
      QueryBuilderFunction(Resources.NGramm);
    }

    private void btn_filterlist_Click(object sender, EventArgs e)
    {
      FilterListFunction(Resources.NGram);
    }

    /// <summary>
    ///   The btn_function_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_function_Click(object sender, EventArgs e)
    {
      PredefinedFunctions(_vm, Resources.Frequency);
    }

    /// <summary>
    ///   The btn_print_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_print_Click(object sender, EventArgs e)
    {
      radGridView1.PrintPreview();
    }

    private void btn_snapshot_create_Click(object sender, EventArgs e)
    {
      var res = new List<Guid>();
      foreach (var r in radGridView1.SelectedRows)
      {
        if(!(r.Cells["Info"].Value is IEnumerable<KeyValuePair<Guid, int>> items))
          continue;
        res.AddRange(items.Select(item => item.Key));
      }

      CreateSelection(res);
    }

    private void GridNGramVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<CutOffPhraseViewModel>();
    }

    private void btn_layer_Click(object sender, EventArgs e)
    {
      var form = new Select1Layer(SelectedLayerDisplaynames);
      form.ShowDialog();
      SelectedLayerDisplaynames = form.ResultSelectedLayerDisplaynames;
      Analyse();
    }

    private void btn_regex_Click(object sender, EventArgs e)
    {
      RegexFunction();
    }
  }
}