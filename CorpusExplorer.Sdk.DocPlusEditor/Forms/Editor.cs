#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bcs.Addon;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Terminal;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Meta;
using CorpusExplorer.Tool4.DocPlusEditor.Controls;
using CorpusExplorer.Tool4.DocPlusEditor.Forms.Abstract;
using CorpusExplorer.Tool4.DocPlusEditor.Properties;
using CorpusExplorer.Tool4.DocPlusEditor.ViewModel;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.Forms
{
  public partial class Editor : AbstractForm
  {
    private const string _filter = "DocPlusXmlCorpus (*.dpxc)|*.dpxc|CorpusExplorer-Rohdaten (*.sdd)|*.sdd";
    private readonly MetadataEditor _editor;

    // ReSharper disable once NotAccessedField.Local
    private readonly TerminalController _terminal;
#pragma warning disable 169
    private AddonHost _host; // Nicht entfernen
#pragma warning restore 169
    private int _lastIndex;
    private string _lastPath;

    public Editor()
    {
      InitializeComponent();
    }

    public Editor(TerminalController terminal)
    {
      _terminal = terminal;
      DialogResult = DialogResult.None;

      ViewModel = new DocPlusViewModel { Index = 0 };

      InitializeComponent();

      SuspendLayout();
      _editor = new MetadataEditor
      {
        Location = new Point(0, 0),
        Size = radGroupBox1.Size,
        Dock = DockStyle.Fill
      };

      radGroupBox1.Controls.Add(_editor);
      _editor.Dock = DockStyle.Fill;
      _editor.KeyUp += Editor_KeyUp;

      _editor.NewProperty += _editor_NewProperty;

      ResumeLayout(false);

      DataLoad();
    }

    private DocPlusViewModel ViewModel { get; set; }

    private void _editor_NewProperty(object sender, EventArgs e)
    {
      DataSave();
      ViewModel.AddProperty((KeyValuePair<string, Type>)sender);
      DataLoad();
    }

    private void btn_auto_meta_Click(object sender, EventArgs e)
    {
      var form = new MetadataFixer(ViewModel.MetadataSchema);
      form.ShowDialog();

      ViewModel.ApplyAutoFixes(form.Result);
      DataLoad();
    }

    private void btn_auto_text_Click(object sender, EventArgs e)
    {
      var form = new TextAutoFixer();
      form.ShowDialog();

      ViewModel.ApplyAutoFixes(form.Result);
      DataLoad();
    }

    private void btn_menu_add_Click(object sender, EventArgs e)
    {
      DataSave();
      ViewModel.DocumentAdd();
      DataLoad();
    }

    private void btn_menu_export_Click(object sender, EventArgs e)
    {
      Hide();
      using (var file = new TemporaryFile(Path.Combine(Path.GetTempPath(), "DPXC"), ".sdd"))
      {
        Serializer.Serialize(ViewModel.DocumentsAll().ToArray(), file.Path, false);
        var ce = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CorpusExplorer",
                              "App", "CorpusExplorer.exe");
        var process = Process.Start(new ProcessStartInfo
        {
          FileName = ce,
          // ReSharper disable once AssignNullToNotNullAttribute
          WorkingDirectory = Path.GetDirectoryName(ce),
          Arguments = $"--anno ListOfScrapDocumentScraper {file.Path}",
          CreateNoWindow = true,
          WindowStyle = ProcessWindowStyle.Hidden
        });
        process?.WaitForExit();
      }

      Show();
    }

    private void btn_menu_import_Click(object sender, EventArgs e)
    {
      var dic = Configuration.AddonScrapers.ToArray();
      var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        CheckPathExists = true,
        Multiselect = true,
        Filter = string.Join("|", dic.Select(x => x.Key))
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      DataSave();
      Hide();

      // Warum auch immer der FilterIndex ist NICHT nullbasiert, daher -1
      var scraper = dic[ofd.FilterIndex - 1].Value;
      foreach (var x in ofd.FileNames)
        scraper.Input.Enqueue(x);
      scraper.Execute();

      var cleaner1 = new StandardCleanup { Input = scraper.Output };
      cleaner1.Execute();
      var cleaner2 = new RegexXmlMarkupCleanup { Input = cleaner1.Output };
      cleaner2.Execute();

      ViewModel.DocumentAddRange(cleaner2.Output);

      Show();

      DataLoad();
    }

    private void btn_menu_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        Filter = _filter,
        CheckFileExists = true
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _lastIndex = ofd.FilterIndex;
      ViewModel = ofd.FilterIndex == 1
                    ? DocPlusViewModel.Load(ofd.FileName)
                    : DocPlusViewModel.LoadRawData(ofd.FileName);
      _lastPath = ofd.FileName;
      DataLoad();
    }

    private void btn_menu_new_Click(object sender, EventArgs e)
    {
      ViewModel = new DocPlusViewModel();
      _lastPath = null;
      DataLoad();
    }

    private void btn_menu_next_Click(object sender, EventArgs e)
    {
      DataSave();
      ViewModel.DocumentNext();
      DataLoad();
    }

    private void btn_menu_preview_Click(object sender, EventArgs e)
    {
      DataSave();
      ViewModel.DocumentPreview();
      DataLoad();
    }

    private void btn_menu_replace_Click(object sender, EventArgs e)
    {
      var form = new TextFindAndReplace(txt_menu_search.Text);
      if (form.ShowDialog() != DialogResult.OK)
        return;

      ViewModel.ApplyAutoFixes(form.Result);
      DataLoad();
    }

    private void btn_menu_save_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(_lastPath))
        btn_menu_saveas_Click(null, null);
      else
        Save(_lastPath, _lastIndex);
    }

    private void btn_menu_saveas_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog
      {
        Filter = _filter,
        CheckPathExists = true
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      Save(sfd.FileName, sfd.FilterIndex);
    }

    private void btn_menu_search_Click(object sender, EventArgs e)
    {
      DataSave();
      ViewModel.Index = ViewModel.SearchJump(txt_menu_search.Text);
      DataLoad();
    }

    private void btn_openrefine_export_Click(object sender, EventArgs e)
    {
      MessageBox.Show(Resources.OpenRefineExportHint,
                      Resources.OpenRefineExportHead, MessageBoxButtons.OK,
                      MessageBoxIcon.Information);

      ViewModel.ApplyAutoFixes(new List<AbstractAutoFix> { new MetaAddGuidAutoFix() });
      DataLoad();

      btn_menu_save_Click(null, null);

      var sfd = new SaveFileDialog { Filter = Resources.FilterTSV };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      ViewModel.Export(sfd.FileName);
    }

    private void btn_openrefine_import_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog { Filter = Resources.FilterTSV };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;
      ViewModel.Import(ofd.FileName);
      DataLoad();
    }

    private void DataLoad()
    {
      lbl_menu_index.Text = @" / 0";
      if (ViewModel == null)
        return;
      if (ViewModel.DocumentsCount == 0)
        ViewModel.DocumentAdd();

      // ReSharper disable once LocalizableElement
      lbl_menu_index.Text = $" / {ViewModel.DocumentsCount}";
      // ReSharper disable once LocalizableElement
      txt_menu_index.Text = $"{ViewModel.Index + 1}";
      txt_text.Text = ViewModel.DocumentCurrent["Text"].ToString();

      _editor.Metadata = ViewModel.DocumentCurrent.Where(x => x.Key != "Text").ToDictionary(x => x.Key, x => x.Value);
      _editor.MetadataSchema = ViewModel.MetadataSchema;
    }

    private void DataSave()
    {
      var res = new Dictionary<string, object> { { "Text", txt_text.Text } };
      foreach (var item in _editor.Metadata)
        res.Add(item.Key, item.Value);

      ViewModel.SaveDocument(res);
    }

    private void Editor_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.PageUp &&
          e.KeyCode != Keys.PageDown)
        return;

      DataSave();

      if (e.KeyCode == Keys.PageUp)
        ViewModel.DocumentNext();
      if (e.KeyCode == Keys.PageDown)
        ViewModel.DocumentPreview();

      DataLoad();
    }

    private void Save(string path, int index)
    {
      DataSave();
      if (index == 1)
        ViewModel.Save(path);
      else
        Serializer.Serialize(ViewModel.DocumentsAll().ToArray(), path, false);
      _lastPath = path;
      _lastIndex = index;
    }

    private void ShowScraperResults_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (DialogResult == DialogResult.Abort)
      {
        MessageBox.Show(Resources.FormClosingError);
        e.Cancel = true;
      }
    }

    private void txt_menu_index_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Enter)
        return;

      if (!int.TryParse(txt_menu_index.Text, out var index))
        return;

      DataSave();
      ViewModel.Index = index - 1;
      DataLoad();
    }
  }
}