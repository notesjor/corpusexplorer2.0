using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Terminal.Automate.Properties;
using CorpusExplorer.Terminal.Console.Xml.Extensions;
using CorpusExplorer.Terminal.Console.Xml.Model;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class SessionForm : AbstractForm
  {
    private session _result;

    public SessionForm(session session = null)
    {
      InitResult();
      InitializeComponent();
      if (session != null)
        Result = session;
    }

    private void InitResult()
    {
      _result = new session
      {
        actions = new actions
        {
          action = new action[0],
          mode = ""
        },
        @override = false,
        overrideSpecified = false,
        queries = new queries
        {
          Items = new object[0]
        },
        sources = new sources
        {
          Items = new object[0],
          processing = ""
        }
      };
    }

    public session Result
    {
      get
      {
        _result.@override = drop_sessionOverride.SelectedIndex == 1;
        _result.sources.processing = drop_sourcesProcessing.SelectedItem.Text;
        _result.actions.mode = drop_actionsMode.SelectedItem.Text;

        return _result;
      }
      private set
      {
        _result = value;
        ReloadUi();
      }
    }

    private void info_session_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("Der Knoten <session> definiert eine Analyse-Session. Quellen (sources) stehen nur innerhalb der Session zur Verfügung - ebenso Schnappschüsse (queries). Analysen (actions) können a/synchron darauf zugreifen.",
                        "<session>",
                        MessageBoxButtons.OK);

    private void info_sources_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("<sources> können Korpora per <annotate> oder <import> erstellen. Das Attribut \"processing\" erlaubt drei Modi: none = normal, merge = alle Quellen werden zusammengefasst, loop = die Quellen werden nacheinander geladen und bearbeitet.",
                        "<sources>",
                        MessageBoxButtons.OK);

    private void info_queries_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("<queries> sind Abfragen auf die Gesamtmenge (sources - siehe auch processing-Modi).",
                        "<queries>",
                        MessageBoxButtons.OK);

    private void info_actions_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("<actions> sind die Aktionen/Analysen die auf Basis der Schnappschüsse (queries) ausgeführt werden.",
                        "<actions>",
                        MessageBoxButtons.OK);

    private void btn_source_add_Click(object sender, EventArgs e)
    {
      var form = new SourceForm();
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _result.sources.Items = _result.sources.Items.Concat(new[] { form.Result }).ToArray();
      ReloadUi();
    }

    private void grid_sources_CommandCellClick(object sender, GridViewCellEventArgs e)
    {
      if (e.ColumnIndex == 1)
      {
        var form = new SourceForm(_result.sources.Items[e.RowIndex]);
        if (form.ShowDialog() != DialogResult.OK)
          return;

        _result.sources.Items[e.RowIndex] = form.Result;
      }
      else if (e.ColumnIndex == 2)
      {
        if (MessageBox.Show("Möchten Sie diese Session wirklich löschen?",
                            "Session löschen?",
                            MessageBoxButtons.YesNo) == DialogResult.No)
          return;

        var list = _result.sources.Items.ToList();
        list.RemoveAt(e.RowIndex);
        _result.sources.Items = list.ToArray();
      }
      ReloadUi();
    }

    private void btn_query_add_Click(object sender, EventArgs e)
    {
      var form = new QueryBuilderForm(_result.queries.GetNames());
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _result.queries.Items = _result.queries.Items.Concat(new[] { form.Result }).ToArray();
      ReloadUi();
    }

    private void grid_queries_CommandCellClick(object sender, GridViewCellEventArgs e)
    {
      if (e.ColumnIndex == 1)
      {
        var form = new QueryBuilderForm(_result.queries.GetNames(), _result.queries.Items[e.RowIndex]);
        if (form.ShowDialog() != DialogResult.OK)
          return;

        _result.queries.Items[e.RowIndex] = form.Result;
      }
      else if (e.ColumnIndex == 2)
      {
        if (MessageBox.Show("Möchten Sie diese Session wirklich löschen?",
                            "Session löschen?",
                            MessageBoxButtons.YesNo) == DialogResult.No)
          return;

        var list = _result.queries.Items.ToList();
        list.RemoveAt(e.RowIndex);
        _result.queries.Items = list.ToArray();
      }
      ReloadUi();
    }

    private void btn_action_add_Click(object sender, EventArgs e)
    {
      var form = new ActionForm(_result.queries.GetNames());
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _result.actions.action = _result.actions.action.Concat(new[] { form.Result }).ToArray();
      ReloadUi();
    }

    private void grid_actions_CommandCellClick(object sender, GridViewCellEventArgs e)
    {
      if (e.ColumnIndex == 1)
      {
        var form = new ActionForm(_result.queries.GetNames(), _result.actions.action[e.RowIndex]);
        if (form.ShowDialog() != DialogResult.OK)
          return;

        _result.actions.action[e.RowIndex] = form.Result;
      }
      else if (e.ColumnIndex == 2)
      {
        if (MessageBox.Show("Möchten Sie diese Session wirklich löschen?",
                            "Session löschen?",
                            MessageBoxButtons.YesNo) == DialogResult.No)
          return;

        var list = _result.actions.action.ToList();
        list.RemoveAt(e.RowIndex);
        _result.actions.action = list.ToArray();
      }
      ReloadUi();
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(Resources.DialogChangesAcceptedMessage, Resources.DialogChangesAcceptedMessageHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      DialogResult = DialogResult.OK;
      Close();
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(Resources.DialogChangesAbortMessage, Resources.DialogChangesAbortMessageHead, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      DialogResult = DialogResult.Abort;
      Close();
    }

    private void ReloadUi()
    {
      // Dropdowns 
      for (var i = 0; i < drop_sessionOverride.Items.Count; i++)
        if (drop_sessionOverride.Items[i].Text == _result.@override.ToString())
        {
          drop_sessionOverride.SelectedIndex = i;
          break;
        }

      for (var i = 0; i < drop_sourcesProcessing.Items.Count; i++)
        if (drop_sourcesProcessing.Items[i].Text == _result.sources.processing)
        {
          drop_sourcesProcessing.SelectedIndex = i;
          break;
        }

      for (var i = 0; i < drop_actionsMode.Items.Count; i++)
        if (drop_actionsMode.Items[i].Text == _result.actions.mode)
        {
          drop_actionsMode.SelectedIndex = i;
          break;
        }

      // Grids
      grid_actions.Rows.Clear();
      try
      {
        foreach (var action in _result.actions.action)
          grid_actions.Rows
                      .Add($"{action.type} ({(string.IsNullOrEmpty(action.query) ? "ALL" : action.query)}) > {action.output.format} [Arguments: {action.arguments?.Length}]");
      }
      catch
      {
        // ignore
      }

      try
      {
        grid_queries.Rows.Clear();
        foreach (var x in _result.queries.query())
          grid_queries.Rows.Add($"[QUERY] {x.name}: {(string.IsNullOrEmpty(x.parent) ? "ALL" : x.parent)} > {string.Join(" ", x.Text)}");
        foreach (var x in _result.queries.queryBuilder())
          grid_queries.Rows
                      .Add($"[QUERYBUILDER] {x.name}: {(string.IsNullOrEmpty(x.parent) ? "ALL" : x.parent)} > PREFIX: {x.prefix} & {x.value.Length} VALUES");
        foreach (var x in _result.queries.queryGroup())
          grid_queries.Rows
                      .Add($"[QUERYGROUP] {x.name} (OPERAND: {x.@operator}): {(string.IsNullOrEmpty(x.parent) ? "ALL" : x.parent)} > PREFIX: {x.prefix} & {x.query.Length} VALUES");
      }
      catch
      {
        // ignore
      }

      try
      {
        grid_sources.Rows.Clear();
        foreach (var x in _result.sources.annotate())
          grid_sources.Rows.Add($"{x.type} ({x.Items?.Length}) > {x.tagger} ({x.language})");
        foreach (var x in _result.sources.import())
          grid_sources.Rows.Add($"{x.type} ({x.Items.Length})");
      }
      catch
      {
        // ignore
      }

    }

    private void grid_CellFormatting(object sender, CellFormattingEventArgs e)
    {
      if (e.CellElement is GridCommandCellElement cmdCell)
        cmdCell.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
    }
  }
}
