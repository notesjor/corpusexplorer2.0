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

    public SourceForm()
    {
      InitializeComponent();
      LoadDropDownOptions();
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
      anno_drop_tagger.Items.AddRange(_taggers.Keys.Select(x => new RadListDataItem(x)));
      _importers = Configuration.AddonImporters.Convert();
    }

    public object Result
    {
      get =>
        drop_starttag.SelectedItem.Text == "annotate"
          ? (object)new annotate
          {
            type = drop_type.SelectedItem.Text,
            language = anno_drop_language.SelectedItem.Text,
            tagger = anno_drop_tagger.SelectedItem.Text,
            Items = GetSources()
          }
          : new import
          {
            type = drop_type.SelectedItem.Text,
            Items = GetSources()
          };
      private set
      {
        if (value is annotate a)
        {
          drop_starttag.SelectedIndex = 0;
          drop_type.SelectValue(a.type);
          anno_drop_tagger.SelectValue(a.tagger);
          anno_drop_language.SelectValue(a.language);
          ListSources(a.Items);
        }
        else
        {
          var import = value as import;
          drop_starttag.SelectedIndex = 1;
          drop_type.SelectValue(import?.type);
          ListSources(import?.Items);
        }
      }
    }

    private object[] GetSources()
    {
      var res = grid_files.Rows.Select(row => new file { Value = row.Cells[0].Value.ToString() }).Cast<object>().ToList();
      res.AddRange(grid_directories.Rows.Select(row => new directory { Value = row.Cells[0].Value.ToString(), filter = row.Cells[1].Value.ToString() }));
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
      if (MessageBox.Show(Resources.DialogChangesAcceptedMessage, Resources.DialogChangesAcceptedMessageHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      DialogResult = DialogResult.OK;
      Close();
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(Resources.DialogChangesAbortMessage, Resources.DialogChangesAbortMessageHead, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
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
      {
        drop_type.Items.Clear();
        drop_type.Items.AddRange(_scrapers.Keys.Select(x => new RadListDataItem(x)));
      }
      else
      {
        drop_type.Items.Clear();
        drop_type.Items.AddRange(_importers.Keys.Select(x => new RadListDataItem(x)));
      }
    }

    private void anno_drop_tagger_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      anno_drop_language.Items.Clear();
      if (!_taggers.ContainsKey(anno_drop_tagger.SelectedItem.Text))
        return;
      anno_drop_language.Items.AddRange(_taggers[anno_drop_tagger.SelectedItem.Text]
                                       .LanguagesAvailabel.Select(x => new RadListDataItem(x)));
    }
  }
}
