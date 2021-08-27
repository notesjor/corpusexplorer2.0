using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Terminal.Automate.Helper;
using CorpusExplorer.Terminal.Automate.Properties;
using CorpusExplorer.Terminal.Console.Xml.Model;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class AutoSplitForm : AbstractForm
  {
    public AutoSplitForm(string query = null)
    {
      InitializeComponent();
      drop_type.SelectedIndex = 0;
      Result = query;
    }

    public string Result
    {
      get
      {
        if (string.IsNullOrEmpty(txt_meta.Text))
          return null;

        try
        {
          var res = $"XS{txt_meta.Text.Trim()}::";
          switch (drop_type.SelectedIndex)
          {
            case 0:
              res += "TEXT";
              break;
            case 1:
              res += $"INT;{txt_size.Text}";
              break;
            case 2:
              res += $"FLOAT;{txt_size.Text}";
              break;
            case 3:
              res += $"{GetAutoSplitDateCommand()}{(drop_date.SelectedIndex == 0 ? $";{txt_size.Text}" : "")}";
              break;
          }

          return res;
        }
        catch
        {
          return null;
        }
      }
      set
      {
        if (string.IsNullOrWhiteSpace(value))
          return;

        var txt = value.Substring(2);
        var vals = txt.Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
        txt_meta.Text = vals[0];

        if (vals[1].StartsWith("TEXT"))
          drop_type.SelectedIndex = 0;
        if (vals[1].StartsWith("INT"))
        {
          drop_type.SelectedIndex = 1;
          txt_size.Text = vals[1].Replace("INT;", "");
        }
        if (vals[1].StartsWith("FLOAT"))
        {
          drop_type.SelectedIndex = 2;
          txt_size.Text = vals[1].Replace("FLOAT;", "");
        }
        if (vals[1].StartsWith("DATE"))
        {
          drop_type.SelectedIndex = 3;
          vals = vals[1].Replace("DATE;", "").Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

          drop_date.SelectStartsWithValue($"DATE;{vals[0]} ");
          if (vals.Length > 1)
            txt_size.Text = vals[1];
        }
      }
    }
    
    private void btn_ok_Click(object sender, EventArgs e)
    {
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

    private void RefreshLivePreview()
    {
      txt_livePreview.Text = Result;
    }

    private void refreshlive_textbox(object sender, EventArgs e)
    {
      RefreshLivePreview();
    }

    #region AutoSplit
    private void drop_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      switch (drop_type.SelectedIndex)
      {
        case 0:
          panle_date.Visible = panel_size.Visible = false;
          break;
        case 1:
        case 2:
          panel_size.Visible = true;
          panle_date.Visible = false;
          break;
        case 3:
          drop_date.SelectedIndex = 4;
          panle_date.Visible = true;
          break;
      }

      RefreshLivePreview();
    }

    private void drop_date_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      panel_size.Visible = drop_date.SelectedIndex == 0;
      RefreshLivePreview();
    }

    private string GetAutoSplitDateCommand()
    {
      if (drop_date.SelectedIndex == -1)
        return null;

      var txt = drop_date.SelectedItem.Text;
      var f = txt.IndexOf("=");
      return txt.Substring(0, f - 1).Trim();
    }
    #endregion
  }
}
