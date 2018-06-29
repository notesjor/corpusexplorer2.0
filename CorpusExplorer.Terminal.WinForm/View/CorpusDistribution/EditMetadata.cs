using System;
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
      radGridView1.DataBindings.Clear();
      radGridView1.DataSource = _vm.DataTable;
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {Filter = "CSV-Datei (*.csv)|*.csv"};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      _vm.Export(sfd.FileName);
    }

    private void btn_import_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog {Filter = "CSV-Datei (*.csv)|*.csv"};
      if (ofd.ShowDialog() != DialogResult.OK)
        return;
      _vm.Import(ofd.FileName);
      DocumentMetadataVisualisation_ShowVisualisation(null, null);
    }

    private void btn_meta_add_Click(object sender, EventArgs e)
    {
      var form = new SimpleTextInput(
        "Neue Metaangabe",
        "Geben Sie den Namen der neuen Metaangabe an. Dieser Wert kann später nicht mehr geändert werden.",
        Resources.tag_green,
        "Name hier eingeben...");
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _vm.AddMetaEntry(form.Result, typeof(string));
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      _vm.Save();
    }

    private void DocumentMetadataVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<DocumentMetadataViewModel>();
      _vm.Analyse();
      radGridView1.DataSource = _vm.DataTable;
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
    }
  }
}