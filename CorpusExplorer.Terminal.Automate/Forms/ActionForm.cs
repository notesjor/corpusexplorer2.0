using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Terminal.Automate.Helper;
using CorpusExplorer.Terminal.Automate.Properties;
using CorpusExplorer.Terminal.Console.Xml.Model;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class ActionForm : AbstractForm
  {
    private Dictionary<string, AbstractTableWriter> _outputAction;
    private Dictionary<string, AbstractExporter> _outputExporter;

    private ActionForm()
    {
      InitializeComponent();
    }

    public ActionForm(string[] queries, action action = null)
    {
      InitializeComponent();
      LoadDropDownOptions();

      drop_queries.Items.AddRange(queries);

      if (action != null)
        Result = action;
    }

    private void LoadDropDownOptions()
    {
      drop_actionType.Items.AddRange(Configuration.AddonConsoleActions.Where(x => x.Action != "cluster").OrderBy(x => x.Action).Select(x => new RadListDataItem(x.Action)));
      _outputAction = Configuration.AddonTableWriter.ToDictionary(x => x.Value.TableWriterTag.Replace("F:", ""), x => x.Value);
      _outputExporter = Configuration.AddonExporters.Convert();
      drop_actionType.SelectedIndex = 0;
    }

    public action Result
    {
      get
      {
        if (!switch_cluster.Value)
          return new action
          {
            type = drop_actionType.SelectedItem.Text,
            output = GetOutput(),
            query = drop_queries.SelectedIndex == -1 ? "" : drop_queries.SelectedItem.Text,
            arguments = grid_arguments.Rows.Select(x => x.Cells[0].Value.ToString()).ToArray()
            // mode hier nicht möglich
          };

        var args = new List<string> { "cluster" };
        args.AddRange(grid_arguments.Rows.Select(x => x.Cells[0].Value.ToString()).ToArray());

        return new action
        {
          type = drop_actionType.SelectedItem.Text,
          output = GetOutput(),
          query = drop_queries.SelectedIndex == -1 ? "" : drop_queries.SelectedItem.Text,
          arguments = args.ToArray(),
          mode = switch_merge.Value ? "merge" : null
        };
      }
      private set
      {
        drop_actionType.SelectValue(value.type);
        drop_outputFormat.SelectValue(value.output.format);
        txt_outputPath.Text = value.output.Value;
        throw new NotImplementedException();
        /*
        foreach (var VARIABLE in COLLECTION)
        {
          
        }
        */
      }
    }

    private output GetOutput() =>
      new output
      {
        format = switch_tid.Visible && !switch_tid.Value 
                   ? drop_outputFormat.SelectedItem.Tag.ToString().Replace("F:", "FNT:") 
                   : drop_outputFormat.SelectedItem.Tag.ToString(),
        Value = txt_outputPath.Text
      };

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

    private void btn_outputPath_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog();
      if (sfd.ShowDialog() == DialogResult.OK)
        txt_outputPath.Text = sfd.FileName;
    }

    private void switch_cluster_ValueChanged(object sender, EventArgs e)
    {
      panel_cluster.Visible = panel_clusterMerge.Visible = switch_cluster.Value;
    }

    private void drop_actionType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      if (drop_actionType.SelectedItem.Text == "query" || drop_actionType.SelectedItem.Text == "convert")
      {
        panel_tid.Visible = false;
        drop_outputFormat.Items.Clear();
        drop_outputFormat.Items.AddRange(_outputExporter.Select(x => new RadListDataItem(x.Key) { Tag = x.Value.GetType().Name }));
      }
      else
      {
        panel_tid.Visible = true;
        drop_outputFormat.Items.Clear();
        drop_outputFormat.Items.AddRange(_outputAction.Select(x => new RadListDataItem(x.Key) { Tag = x.Value.TableWriterTag }));
      }
    }

    private void btn_clusterAssistant_Click(object sender, EventArgs e)
    {
      var form = new ClusterAssistant();
      if (form.ShowDialog() != DialogResult.OK)
        return;

      txt_cluster.Text = form.Result;
    }
  }
}
