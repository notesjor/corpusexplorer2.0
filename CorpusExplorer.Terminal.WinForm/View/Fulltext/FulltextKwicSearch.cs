﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  public partial class FulltextKwicSearch : AbstractGridView
  {
    private RadCheckBox _checkBox;
    private DateTime _preventDoubleCommandClick = DateTime.Now;
    private TextLiveSearchViewModel _vm;

    public FulltextKwicSearch()
    {
      InitializeComponent();
      _checkBox = new RadCheckBox { Text = "Phrasen-Suche?" };
      commandBarHostItem1.Padding = new Padding(0, 3, 0, 0);
      commandBarHostItem1.HostedControl = _checkBox;

      InitializeGrid(radGridView1);
      ShowView += OnShowView;
    }

    private void Analyse()
    {
      _vm.ClearQueries();
      if (wordBag1.ResultSelectedLayerDisplayname != null)
        _vm.LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname;
      _vm.AddQuery(
        _checkBox.Checked ? (AbstractFilterQuery)
                   new FilterQuerySingleLayerExactPhrase
                   {
                     Inverse = false,
                     LayerDisplayname = _vm.LayerDisplayname,
                     LayerQueries = wordBag1.ResultQueries
                   }
                   :
                   new FilterQuerySingleLayerAnyMatch
                   {
                     Inverse = false,
                     LayerDisplayname = _vm.LayerDisplayname,
                     LayerQueries = wordBag1.ResultQueries
                   });
      _vm.Execute();

      radGridView1.DataSource = _vm.GetUniqueDataTableGui();
      radGridView1.ResetBindings();

      AddSummaryRow();
      ApplyFilterDelay();
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

      try
      {
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
      catch
      {
        // ignore
      }
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
      DataTableExporter.Export(_vm.GetUniqueDataTableCsvMeta());
    }

    private void btn_filter_Click(object sender, EventArgs e)
    {
      FilterListFunction("Pre", "Match", "Post");
    }

    private void btn_filterEditor_Click(object sender, EventArgs e)
    {
      QueryBuilderFunction(Resources.Frequency);
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
      var docs = new HashSet<Guid>();
      foreach (var r in radGridView1.SelectedRows)
        if (r.Cells["Info"]?.Value is IEnumerable<KeyValuePair<Guid, int>> info)
          foreach (var x in info)
            docs.Add(x.Key);

      CreateSelection(docs);
    }

    private void OnGridOnCommandCellClick(object sender, GridViewCellEventArgs arg)
    {
      if ((DateTime.Now - _preventDoubleCommandClick).Seconds < 1)
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

      _preventDoubleCommandClick = DateTime.Now;
    }

    private void OnShowView(object sender, EventArgs eventArgs)
    {
      _vm = GetViewModel<TextLiveSearchViewModel>();
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      Analyse();
    }

    private void btn_regex_Click(object sender, EventArgs e)
    {
      RegexFunction();
    }
  }
}