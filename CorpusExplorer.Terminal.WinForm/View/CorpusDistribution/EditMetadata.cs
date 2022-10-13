using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.View.CorpusDistribution
{
  public partial class EditMetadata : AbstractView
  {
    private DocumentMetadataViewModel _vm;

    public EditMetadata()
    {
      InitializeComponent();
    }

    private void btn_doReplace_Click(object sender, EventArgs e)
    {
      _vm.Replace(txt_search.Text, txt_replace.Text);
      
      Refresh();
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {Filter = "TSV-Datei (*.tsv)|*.tsv" };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      _vm.Export(sfd.FileName);
    }

    private void btn_import_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog {Filter = "TSV-Datei (*.tsv)|*.tsv"};
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _vm.Import(ofd.FileName);
      Refresh();
    }

    private void Refresh()
    {
      _vm = GetViewModel<DocumentMetadataViewModel>();
      _vm.Execute();

      radGridView1.DataBindings.Clear();
      radGridView1.DataSource = _vm.DataTable;
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
    }

    private void btn_meta_add_Click(object sender, EventArgs e)
    {
      var form = new CorpusExplorer.Tool4.DocPlusEditor.Forms.MetadataNew(new HashSet<string>(from DataColumn c in _vm.DataTable.Columns select c.ColumnName));
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _vm.AddMetaEntry(form.Result.Key, form.Result.Value);
      Refresh();
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      _vm.Save();
    }

    private void DocumentMetadataVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      Refresh();
    }
  }
}