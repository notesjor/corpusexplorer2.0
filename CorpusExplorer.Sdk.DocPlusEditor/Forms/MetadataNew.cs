#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CorpusExplorer.Tool4.DocPlusEditor.Forms.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.Forms
{
  public partial class MetadataNew : AbstractForm
  {
    private readonly HashSet<string> _schema;

    public MetadataNew(HashSet<string> schema)
    {
      _schema = schema;
      InitializeComponent();

      SuspendLayout();
      cmb_type.Items.Add("Text");
      cmb_type.Items.Add("Ganzzahl");
      cmb_type.Items.Add("Kommazahl");
      cmb_type.Items.Add("Datum");
      cmb_type.Items.Add("Boolean");
      ResumeLayout(false);
    }

    public KeyValuePair<string, Type> Result
    {
      get
      {
        Type type = null;

        switch (cmb_type.SelectedIndex)
        {
          case 0:
            type = typeof(string);
            break;
          case 1:
            type = typeof(int);
            break;
          case 2:
            type = typeof(double);
            break;
          case 3:
            type = typeof(DateTime);
            break;
          case 4:
            type = typeof(bool);
            break;
        }

        return new KeyValuePair<string, Type>(txt_propertyName.Text, type);
      }
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      Close();
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      if(cmb_type.SelectedIndex < 0)
      {
        MessageBox.Show("Bitte geben Sie den Datentyp an.");
        return;
      }
      if(txt_propertyName.Text.Length < 1)
      {
        MessageBox.Show("Bitte geben Sie den Bezeichnung ein.");
        return;
      }
      if(panel_warn.Visible)
      {
        MessageBox.Show("Eine Metaangabe mit der Bezeichnung exsistiert bereits. Bitte geben Sie eine andere Bezeichnung ein.");
        return;
      }

      DialogResult = DialogResult.OK;
      Close();
    }

    private void txt_propertyName_TextChanged(object sender, EventArgs e)
    {
      var match = _schema.Contains(txt_propertyName.Text);

      btn_ok.Enabled = !match;
      panel_warn.Visible = match;
    }
  }
}