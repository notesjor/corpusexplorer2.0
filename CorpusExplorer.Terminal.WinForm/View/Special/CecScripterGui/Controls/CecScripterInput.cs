using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Terminal.Console.Helper;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.View.Special.CecScripterControls.Abstract;

namespace CorpusExplorer.Terminal.WinForm.View.Special.CecScripterControls
{
  public partial class CecScripterInput : AbstractCecScripterControl
  {
    private Dictionary<string, string> _scraper;
    private Dictionary<string, string> _importer;
    private string _file;
    private string _tagger;
    private string _language;

    public CecScripterInput()
    {
      InitializeComponent();
      _scraper = Configuration.AddonScrapers.GetDictionaryForScriptEditor();
      _importer = Configuration.AddonImporters.GetDictionaryForScriptEditor();
    }

    private void CecScripterInput_Load(object sender, EventArgs e)
    {
      drop_mode.SelectedIndex = 0;
    }

    public override string Query
    {
      get => string.IsNullOrEmpty(_file)
        ? null
        : (drop_mode.SelectedItem.Text == "import"
          ? $"import#{drop_format.SelectedItem.Text}#{_file}"
          : (string.IsNullOrEmpty(_tagger)
            ? null
            : $"annotate#{drop_format.SelectedItem.Text}#{_tagger}#{_language}#{_file}"));
      set => base.Query = value;
    }

    private void drop_mode_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      if (drop_mode.SelectedItem.Text == "import")
      {
        btn_options.Visible = false;
        DictionaryBindingHelper.BindDictionary(_importer, drop_format);
      }
      else
      {
        btn_options.Visible = true;
        DictionaryBindingHelper.BindDictionary(_scraper, drop_format);
      }
    }

    private void btn_options_Click(object sender, EventArgs e)
    {

    }

    private void btn_file_Click(object sender, EventArgs e)
    {
      if (drop_mode.SelectedItem.Text == "import")
      {
        var ofd = new OpenFileDialog { Filter = drop_format.SelectedItem.Value.ToString(), Multiselect = true };
        if (ofd.ShowDialog() == DialogResult.OK)
          _file = string.Join("|", from x in ofd.FileNames select $"\"{x}\"");
      }
      else
      {
        var fbd = new FolderBrowserDialog();
        if (fbd.ShowDialog() == DialogResult.OK)
          _file = $"\"{fbd.SelectedPath}\"";
      }
    }
  }
}
