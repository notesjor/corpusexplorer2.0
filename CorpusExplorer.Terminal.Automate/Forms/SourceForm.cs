using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Terminal.Automate.Helper;
using CorpusExplorer.Terminal.Automate.Properties;
using CorpusExplorer.Terminal.Console.Xml.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class SourceForm : AbstractForm
  {
    private Dictionary<string, AbstractScraper> _scrapers;
    private Dictionary<string, AbstractTagger> _taggers;
    private Dictionary<string, AbstractImporter> _importers;
    
    private Validator _validator;

    public SourceForm()
    {
      InitializeComponent();
      LoadDropDownOptions();
      drop_starttag.SelectedIndex = 1;
      drop_starttag.SelectedIndex = 0;

      _validator = new Validator
      {
        Rules = new List<Validator.Rule>
        {
          new Validator.Rule()
          {
            Control = grid_directories,
            ErrorMessage = "Bitte löschen Sie den leeren Verzeichniseintrag.",
            ValidationFunction = grid =>
            {
              return ((RadGridView)grid).Rows.All(row => !string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()) || string.IsNullOrWhiteSpace(row.Cells[1].Value.ToString()));
            }
          },
          new Validator.Rule()
          {
            Control = grid_directories,
            ErrorMessage = "Sie müssen für alle Verzeichnisse einen Filter setzen - z. B. *.txt",
            ValidationFunction = grid =>
            {
              return ((RadGridView)grid).Rows.All(row => string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()) || !string.IsNullOrWhiteSpace(row.Cells[1].Value.ToString()));
            }
          }
        }
      };
    }

    public SourceForm(object data)
    {
      InitializeComponent();
      LoadDropDownOptions();
      Result = data;
    }

    private void LoadDropDownOptions()
    {
      _scrapers = Configuration.AddonScrapers.Convert();
      _taggers = Configuration.AddonTaggers.ToDictionary(x => x.DisplayName, x => x);
      _importers = Configuration.AddonImporters.Convert();

      anno_drop_tagger.Items.AddRange(_taggers.Keys.Select(x => new RadListDataItem(x)));
    }

    public object Result
    {
      get =>
        drop_starttag.SelectedItem.Text == "annotate"
          ? (object)new annotate
          {
            type = drop_type.SelectedItem.Tag.ToString(),
            language = anno_drop_language.SelectedItem.Text,
            tagger = anno_drop_tagger.SelectedItem.Text,
            Items = GetSources()
          }
          : new import
          {
            type = drop_type.SelectedItem.Tag.ToString(),
            Items = GetSources()
          };
      private set
      {
        var type = "";
        if (value is annotate annotate)
        {
          drop_starttag.SelectedIndex = 0;
          anno_drop_tagger.SelectValue(annotate.tagger);
          anno_drop_language.SelectValue(annotate.language);
          ListSources(annotate.Items);
          DropTypeRefreshAnnotate();
          type = annotate.type;
        }
        else
        {
          var import = value as import;
          drop_starttag.SelectedIndex = 1;
          ListSources(import?.Items);
          DropTypeRefreshImport();
          type = import?.type;
        }

        for (var i = 0; i < drop_type.Items.Count; i++)
          if (drop_type.Items[i].Tag.ToString() == type)
          {
            drop_type.SelectedIndex = i;
            break;
          }
      }
    }

    private object[] GetSources()
    {
      var res = grid_files.Rows.Select(row => new file { Value = row.Cells[0].Value.ToString() }).Cast<object>().ToList();
      res.AddRange(grid_directories.Rows.Select(row => new directory { Value = row.Cells[0].Value?.ToString(), filter = row.Cells[1].Value?.ToString() }));
      return res.ToArray();
    }

    private void ListSources(object[] items)
    {
      foreach (var item in items)
      {
        switch (item)
        {
          case file f:
            grid_files.Rows.Add(f.Value);
            break;
          case directory d:
            grid_directories.Rows.Add(d.Value, d.filter);
            break;
        }
      }
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      if (_validator != null)
        if (!_validator.Validate())
        {
          MessageBox.Show(_validator.SimpleErrorMessage());
          return;
        }

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

    private void drop_starttag_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      anno_drop_language.Visible =
        anno_drop_tagger.Visible =
          anno_lbl_language.Visible =
            anno_lbl_tagger.Visible = drop_starttag.SelectedItem.Text == "annotate";

      lbl_endtag.Text =
        $"<html><span style=\"color: #0000ff\">&lt;/{drop_starttag.SelectedItem.Text}&gt;</span></html>";

      if (drop_starttag.SelectedItem.Text == "annotate")
        DropTypeRefreshAnnotate();
      else
        DropTypeRefreshImport();

      drop_type.SelectedIndex = 0;
    }

    private void DropTypeRefreshImport()
    {
      drop_type.Items.Clear();
      drop_type.Items.AddRange(_importers.Select(x => new RadListDataItem(x.Key) { Tag = x.Value.GetType().Name }));
    }

    private void DropTypeRefreshAnnotate()
    {
      drop_type.Items.Clear();
      drop_type.Items.AddRange(_scrapers.Select(x => new RadListDataItem(x.Key) { Tag = x.Value.GetType().Name }));
      anno_drop_tagger.SelectedIndex = 0;
    }

    private void anno_drop_tagger_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      anno_drop_language.Items.Clear();
      if (!_taggers.ContainsKey(anno_drop_tagger.SelectedItem.Text))
        return;
      anno_drop_language.Items.AddRange(_taggers[anno_drop_tagger.SelectedItem.Text]
                                       .LanguagesAvailabel.Select(x => new RadListDataItem(x)));
      anno_drop_language.SelectedIndex = 0;
    }

    private string GetFileExtensions(string[] files)
    {
      var first = files?.First();
      return first == null ? "" : $"*{Path.GetFileName(first).Replace(Path.GetFileNameWithoutExtension(first), "")}";
    }

    private void btn_add_directories_Click(object sender, EventArgs e)
    {
      var fbd = new FolderBrowserDialog();
      if (fbd.ShowDialog() != DialogResult.OK)
        return;

      grid_directories.Rows.Add(fbd.SelectedPath, GetFileExtensions(Directory.GetFiles(fbd.SelectedPath)));
    }

    private void btn_add_files_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog { Multiselect = true };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      foreach (var fn in ofd.FileNames)
        grid_files.Rows.Add(fn);
    }
  }
}
