#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Meta;
using CorpusExplorer.Tool4.DocPlusEditor.Forms.Abstract;
using Telerik.WinControls.UI.Data;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.Forms
{
  public partial class MetadataFixer : AbstractForm
  {
    public MetadataFixer(Dictionary<string, Type> schema)
    {
      InitializeComponent();

      SuspendLayout();
      foreach (var k in schema.Keys.Where(x => x != "Text"))
        cmb_1_metaName.Items.Add(k);

      cmb_2_selectAutoFix.Items.Add("Datentyp ändern");
      cmb_2_selectAutoFix.Items.Add("Umbenennen");
      cmb_2_selectAutoFix.Items.Add("Löschen");

      cmb_3_convertType.Items.Add("Text");
      cmb_3_convertType.Items.Add("Ganzzahl");
      cmb_3_convertType.Items.Add("Kommazahl");
      cmb_3_convertType.Items.Add("Datum");
      cmb_3_convertType.Items.Add("Boolean");
      ResumeLayout(false);

      cmb_1_metaName.SelectedIndex = 0;
      cmb_2_selectAutoFix.SelectedIndex = 0;
      cmb_3_convertType.SelectedIndex = 0;
    }

    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
    public List<AbstractAutoFix> Result { get; private set; } = new List<AbstractAutoFix>();

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      Close();
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;

      switch (cmb_2_selectAutoFix.SelectedIndex)
      {
        case 0:
          switch (cmb_3_convertType.SelectedIndex)
          {
            case 0:
              Result.Add(new StringCastMetaAutoFix
              {
                SelectedEntry = cmb_1_metaName.Items[cmb_1_metaName.SelectedIndex].Text
              });
              break;
            case 1:
              Result.Add(new IntCastMetaAutoFix
              {
                SelectedEntry = cmb_1_metaName.Items[cmb_1_metaName.SelectedIndex].Text
              });
              break;
            case 2:
              Result.Add(new DoubleCastMetaAutoFix
              {
                SelectedEntry = cmb_1_metaName.Items[cmb_1_metaName.SelectedIndex].Text
              });
              break;
            case 3:
              Result.Add(new DateTimeCastMetaAutoFix
              {
                SelectedEntry = cmb_1_metaName.Items[cmb_1_metaName.SelectedIndex].Text,
                DateTimeFormat = txt_4_options.Text
              });
              break;
            case 4:
              Result.Add(new BooleanCastMetaAutoFix
              {
                SelectedEntry = cmb_1_metaName.Items[cmb_1_metaName.SelectedIndex].Text,
                TrueExpression = txt_4_options.Text
              });
              break;
          }

          break;
        case 1:
          Result.Add(new MetaRenameAutoFix
          {
            SelectedEntry = cmb_1_metaName.Items[cmb_1_metaName.SelectedIndex].Text,
            EntryNewName = txt_4_options.Text
          });
          break;
        case 2:
          Result.Add(new MetaDeleteAutoFix
          {
            SelectedEntry = cmb_1_metaName.Items[cmb_1_metaName.SelectedIndex].Text
          });
          break;
      }

      Close();
    }

    private void cmb_fix_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
      => RefreshVisualOptions();

    private void cmb_type_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
      => RefreshVisualOptions();

    private void RefreshVisualOptions()
    {
      switch (cmb_2_selectAutoFix.SelectedIndex)
      {
        case 0:
          grp_type.Visible = true;
          switch (cmb_3_convertType.SelectedIndex)
          {
            case 0:
              grp_options.Visible = false;
              break;
            case 1:
              grp_options.Visible = false;
              break;
            case 2:
              grp_options.Visible = false;
              break;
            case 3:
              grp_options.Visible = true;
              break;
            case 4:
              grp_options.Visible = true;
              break;
          }

          break;
        case 1:
          grp_type.Visible = false;
          grp_options.Visible = true;
          break;
        case 2:
          grp_type.Visible = false;
          grp_options.Visible = false;
          break;
      }
    }
  }
}