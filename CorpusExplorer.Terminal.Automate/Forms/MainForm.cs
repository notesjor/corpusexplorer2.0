using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class MainForm : AbstractForm
  {
    private string _filter = "CorpusExplorerConsole XML-Script (*.cecs)|*.cecs";
    private AutomateViewModel _vm;

    public MainForm()
    {
      InitializeComponent();
      _vm = new AutomateViewModel();
    }

    private void grid_sessions_CellFormatting(object sender, CellFormattingEventArgs e)
    {
      if (e.CellElement is GridCommandCellElement cmdCell)
        cmdCell.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
    }

    private void btn_session_add_Click(object sender, EventArgs e)
    {
      Hide();
      var form = new SessionForm();
      if (form.ShowDialog() == DialogResult.OK)
      {
        _vm.Add(form.Result);
      }

      PersistUi();
      ReloadUi();
      Show();
    }

    private void btn_script_new_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Möchten Sie ein neues Skript erstellen?", "Neues Skript erstellen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      var question =
        MessageBox.Show("Soll das zuvor erstellte Skript gespeichert werden? Nicht gespeicherte Änderungen gehen sonst verloren.",
                        "Änderungen speichern?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
      switch (question)
      {
        case DialogResult.Cancel:
        case DialogResult.Yes:
          SaveScript();
          return;
        default:
          _vm.New();
          ReloadUi();
          break;
      }
    }

    private void btn_script_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog { Multiselect = false, Filter = _filter };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _vm.Load(ofd.FileName);
      ReloadUi();
    }

    private void btn_script_save_Click(object sender, EventArgs e)
    {
      SaveScript();
    }

    private string SaveScript()
    {
      var sfd = new SaveFileDialog { Filter = _filter };
      if (sfd.ShowDialog() != DialogResult.OK)
        return null;

      _vm.Save(sfd.FileName,
               drop_version.SelectedItem.Text,
               drop_sessionMode.SelectedItem.Text,
               grid_headMeta.Rows.Select(x => new KeyValuePair<string, string>(x.Cells[0].Value.ToString(), x.Cells[1].Value.ToString())).ToArray().ToArray());
      return sfd.FileName;
    }

    private void btn_script_execute_Click(object sender, EventArgs e)
    {
      _vm.Execute(SaveScript());
    }

    private void PersistUi()
    {
      grid_headMeta.EndEdit();
    }

    private void ReloadUi()
    {
      for (var i = 0; i < drop_version.Items.Count; i++)
        if (drop_version.Items[i].Text == _vm.Version)
        {
          drop_version.SelectedIndex = i;
          break;
        }

      grid_headMeta.Rows.Clear();
      foreach (var m in _vm.Metas)
        grid_headMeta.Rows.Add(m.Key, m.Value);

      for (var i = 0; i < drop_sessionMode.Items.Count; i++)
        if (drop_sessionMode.Items[i].Text == _vm.SessionMode)
        {
          drop_sessionMode.SelectedIndex = i;
          break;
        }

      grid_sessions.Rows.Clear();
      try
      {
        foreach (var s in _vm?.List())
          grid_sessions.Rows.Add(s);
      }
      catch
      {
        // ignore
      }
    }

    private void grid_headMeta_CellEndEdit(object sender, GridViewCellEventArgs e)
    {
      _vm.Metas = grid_headMeta.Rows.ToDictionary(row => row.Cells[0].Value.ToString(),
                                                  row => row.Cells[1].Value.ToString());
    }

    private void grid_sessions_CommandCellClick(object sender, GridViewCellEventArgs e)
    {
      if (e.ColumnIndex == 1)
      {
        Hide();
        var form = new SessionForm(_vm.Get(e.RowIndex));
        var res = form.ShowDialog();
        Show();

        if (res != DialogResult.OK)
          return;

        _vm.Change(e.RowIndex, form.Result);
      }
      else if (e.ColumnIndex == 2)
      {
        if (MessageBox.Show("Möchten Sie diese Session wirklich löschen?", 
                            "Session löschen?",
                            MessageBoxButtons.YesNo) == DialogResult.No)
          return;

        _vm.Delete(e.RowIndex);
      }
      ReloadUi();
    }
  }
}
