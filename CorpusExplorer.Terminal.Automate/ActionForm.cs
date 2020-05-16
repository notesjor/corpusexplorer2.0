using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Terminal.Automate.Helper;
using CorpusExplorer.Terminal.Automate.Properties;
using CorpusExplorer.Terminal.Console.Xml.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class ActionForm : AbstractForm
  {
    private Dictionary<string, AbstractTableWriter> _outputAction;
    private Dictionary<string, AbstractExporter> _outputExporter;

    public ActionForm(action action = null)
    {
      InitializeComponent();
      LoadDropDownOptions();
      Result = action;
    }

    private void LoadDropDownOptions()
    {
      drop_actionType.Items.AddRange(Configuration.AddonConsoleActions.Select(x => new RadListDataItem(x.Action)));
      _outputAction = Configuration.AddonTableWriter.GetReflectedTypeNameDictionary();
      _outputExporter = Configuration.AddonExporters.GetReflectedTypeNameDictionary();
    }

    public action Result
    {
      get
      {
        throw new NotImplementedException();
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

    }

    private void drop_actionType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      if (drop_actionType.SelectedItem.Text == "query" || drop_actionType.SelectedItem.Text == "convert")
      {
        drop_outputFormat.Items.Clear();
        drop_outputFormat.Items.AddRange(_outputExporter.Select(x => new RadListDataItem(x.Key)));
      }
      else
      {
        drop_outputFormat.Items.Clear();
        drop_outputFormat.Items.AddRange(_outputAction.Select(x => new RadListDataItem(x.Key)));
      }
    }
  }
}
