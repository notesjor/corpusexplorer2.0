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
    private readonly Validator<RadTextBox> _validator;

    private ActionForm()
    {
      InitializeComponent();
      _validator = new Validator<RadTextBox>
      {
        Rules = new List<Validator<RadTextBox>.ValidatorRule<RadTextBox>>
        {
          new Validator<RadTextBox>.ValidatorRule<RadTextBox>
          {
            Control = txt_outputPath,
            ErrorMessage = "Bitte tragen Sie einen einen Ausgabepfad ein.",
            ValidationFunction = box => !string.IsNullOrWhiteSpace(box.Text)
          },
          new Validator<RadTextBox>.ValidatorRule<RadTextBox>
          {
            Control = txt_cluster,
            ErrorMessage = "Sie haben die Cluster-Funktion aktiviert. Bitte geben Sie daher auch einen Cluster-Query ein.",
            ValidationFunction = box => !string.IsNullOrWhiteSpace(box.Text)
          }
        }
      };
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
        if (switch_cluster.Value)
        {
          var args = new List<string> { txt_cluster.Text, drop_actionType.SelectedItem.Text };
          args.AddRange(grid_arguments.Rows.Select(x => x.Cells[0].Value.ToString()).ToArray());

          return new action
          {
            type = "cluster",
            output = GetOutput(),
            query = drop_queries.SelectedIndex == -1 ? "" : drop_queries.SelectedItem.Text,
            arguments = args.ToArray(),
            mode = switch_cluster.Value && switch_merge.Value ? "merge" : null
          };
        }

        return new action
        {
          type = drop_actionType.SelectedItem.Text,
          output = GetOutput(),
          query = drop_queries.SelectedIndex == -1 ? "" : drop_queries.SelectedItem.Text,
          arguments = grid_arguments.Rows.Select(x => x.Cells[0].Value.ToString()).ToArray(),
          mode = null
        };
      }
      private set
      {
        List<string> args;
        if (value.type == "cluster")
        {
          switch_cluster.Value = true;
          switch_merge.Value = !string.IsNullOrEmpty(value.mode) && value.mode == "merge";
          drop_actionType.SelectValue(value.arguments[1]);
          txt_cluster.Text = value.arguments[0];
          args = value.arguments.ToList();
          args.RemoveAt(0);
          args.RemoveAt(0);

          drop_outputFormat.SelectValue(value.output.format);
        }
        else
        {
          switch_cluster.Value = false;
          drop_actionType.SelectValue(value.type);
          drop_outputFormat.SelectValue(value.output.format.Replace("FNT:", "").Replace("F:", "").ToUpper());
          args = value.arguments?.ToList() ?? new List<string>();
        }

        drop_queries.SelectValue(value.query);
        grid_arguments.Rows.Clear();
        foreach (var arg in args)
          grid_arguments.Rows.Add(arg);
        txt_outputPath.Text = value.output.Value;
        switch_tid.Value = !value.output.format.StartsWith("FNT:");
      }
    }

    private output GetOutput() =>
      new output
      {
        format = !IsExporter && !switch_tid.Value
                   ? drop_outputFormat.SelectedItem.Tag.ToString().Replace("F:", "FNT:")
                   : drop_outputFormat.SelectedItem.Tag.ToString(),
        Value = txt_outputPath.Text
      };

    private void btn_ok_Click(object sender, EventArgs e)
    {
      if (_validator != null)
        if (!_validator.Validate())
        {
          MessageBox.Show(_validator.SimpleErrorMessage());
          return;
        }

      if (MessageBox.Show(Resources.DialogChangesAcceptedMessage, Resources.DialogChangesAcceptedMessageHead, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      DialogResult = DialogResult.OK;
      Close();
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(Resources.DialogChangesAbortMessage, Resources.DialogChangesAbortMessageHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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

    private bool IsExporter
      => (drop_actionType.SelectedItem.Text == "query" || drop_actionType.SelectedItem.Text == "convert");

    private void drop_actionType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      if (IsExporter)
      {
        panel_tid.Visible = false;
        drop_outputFormat.Items.Clear();
        drop_outputFormat.Items.AddRange(_outputExporter.Select(x => new RadListDataItem(x.Key) { Tag = x.Value.GetType().Name }));
        drop_outputFormat.SelectedIndex = 0;
      }
      else
      {
        panel_tid.Visible = true;
        drop_outputFormat.Items.Clear();
        drop_outputFormat.Items.AddRange(_outputAction.Select(x => new RadListDataItem(x.Key) { Tag = x.Value.TableWriterTag }));
        drop_outputFormat.SelectStartsWithValue("TSV");
      }
    }

    private void btn_clusterAssistant_Click(object sender, EventArgs e)
    {
      Hide();
      var form = new AutoSplitForm(txt_cluster.Text);
      if (form.ShowDialog() != DialogResult.OK)
      {
        Show();
        return;
      }

      txt_cluster.Text = form.Result;
      Show();
    }
  }
}
