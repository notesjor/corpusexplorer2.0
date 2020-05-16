using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorpusExplorer.Terminal.Automate.Properties;
using CorpusExplorer.Terminal.Console.Xml.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class SessionForm : AbstractForm
  {
    private session result;

    public SessionForm(session session = null)
    {
      InitializeComponent();
      if (session != null)
        Result = session;
    }

    public session Result
    {
      get
      {
        result.@override = drop_sessionOverride.SelectedItem.Text == "true";
        result.sources.processing = drop_sourcesProcessing.SelectedItem.Text;
        result.actions.mode = drop_actionsMode.SelectedItem.Text;

        return result;
      }
      private set
      {
        result = value;

        for (var i = 0; i < drop_sessionOverride.Items.Count; i++)
          if (drop_sessionOverride.Items[i].Text == result.@override.ToString())
          {
            drop_sessionOverride.SelectedIndex = i;
            break;
          }

        for (var i = 0; i < drop_sourcesProcessing.Items.Count; i++)
          if (drop_sourcesProcessing.Items[i].Text == result.sources.processing)
          {
            drop_sourcesProcessing.SelectedIndex = i;
            break;
          }

        for (var i = 0; i < drop_actionsMode.Items.Count; i++)
          if (drop_actionsMode.Items[i].Text == result.actions.mode)
          {
            drop_actionsMode.SelectedIndex = i;
            break;
          }
      }
    }

    private void grid_sessions_CellFormatting(object sender, CellFormattingEventArgs e)
    {
      if (e.CellElement is GridCommandCellElement cmdCell)
        cmdCell.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
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
      if (form.ShowDialog() == DialogResult.OK)
        result.sources.Items = result.sources.Items.Concat(new[] {form.Result}).ToArray();
    }

    private void btn_query_add_Click(object sender, EventArgs e)
    {
      var form = new QueryForm();
      if (form.ShowDialog() == DialogResult.OK)
        result.queries.Items = result.queries.Items.Concat(new[] { form.Result }).ToArray();
    }

    private void btn_action_add_Click(object sender, EventArgs e)
    {
      var form = new ActionForm();
      if (form.ShowDialog() == DialogResult.OK)
        result.actions.action = result.actions.action.Concat(new[] { form.Result }).ToArray();
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
  }
}
