using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorpusExplorer.Terminal.Console.Xml.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class MainForm : AbstractForm
  {
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

    private void info_cescript_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("Der Knoten <cescript> ist der Root-Knoten. Er beinhaltet Meta-Informationen und Sessions. Über das Attribut \"version\" können Sie die Version einstellen. Verwenden Sie am besten immer die aktuellste Version.",
                        "<cescript>",
                        MessageBoxButtons.OK);

    private void info_head_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("Im Knoten <head> können Meta-Datengespeichert werden. Diese haben für das Skript keine funktionalen Eigenschaften. Vielmehr können Sie hier Informationen zum Projekthintergrund hinterlegen.",
                        "<meta>",
                        MessageBoxButtons.OK);

    private void info_sessions_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("Im Knoten <sessions> beinhaltet die Analyse-Session. Diese können synchron oder asynchron ausgeführt werden (siehe Attribut mode). Bearbeiten Sie eine Session, um weitere Informationen anzuzeigen.",
                        "<sessions>",
                        MessageBoxButtons.OK);

    private void btn_session_add_Click(object sender, EventArgs e)
    {
      var form = new SessionForm();
      if (form.ShowDialog() != DialogResult.OK)
      {
        _vm.Add(form.Result);
      }
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
        case DialogResult.Yes when !SaveScript():
          return;
        default:
          _vm.New();
          break;
      }
    }

    private void btn_script_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog { Multiselect = false };
      ofd.ShowDialog();
      _vm.Load(ofd.FileName);

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
      foreach (var s in _vm.List())
        grid_sessions.Rows.Add(s);

      
    }

    private void btn_script_save_Click(object sender, EventArgs e)
    {
      SaveScript();
    }

    private bool SaveScript()
    {
      var sfd = new SaveFileDialog();
      if (sfd.ShowDialog() != DialogResult.OK) 
        return false;

      _vm.Save(sfd.FileName, 
               drop_version.SelectedItem.Text,
               drop_sessionMode.SelectedItem.Text,
               grid_headMeta.Rows.Select(x => new KeyValuePair<string, string>(x.Cells[0].Value.ToString(),x.Cells[1].Value.ToString())).ToArray().ToArray());
      return true;
    }

    private void btn_script_execute_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog();
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      _vm.Save(sfd.FileName,
               drop_version.SelectedItem.Text,
               drop_sessionMode.SelectedItem.Text,
               grid_headMeta.Rows.Select(x => new KeyValuePair<string, string>(x.Cells[0].Value.ToString(), x.Cells[1].Value.ToString())).ToArray().ToArray());
      _vm.Execute(sfd.FileName);
    }
  }
}
