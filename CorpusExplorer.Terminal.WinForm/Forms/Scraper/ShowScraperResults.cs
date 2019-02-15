#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Scraper
{
  public partial class ShowScraperResults : AbstractDialog
  {
    private const string _ignoreLabel = "!IGNORE";
    private readonly RadCheckBoxElement _checkBox;
    private readonly IndexList<Dictionary<string, object>> _documets;

    public ShowScraperResults()
    {
      InitializeComponent();
    }

    public ShowScraperResults(IEnumerable<Dictionary<string, object>> documets)
    {
      InitializeComponent();

      ButtonOkClick += (sender, args) => DataSave();
      _documets =
        new IndexList<Dictionary<string, object>>(
                                                  documets.Where(doc => !string.IsNullOrEmpty(doc.Get("Text", ""))));

      _checkBox = new RadCheckBoxElement {Text = Resources.ShowScraperResults_IgnoreText};
      commandBarHostItem1.HostedItem = _checkBox;

      metadataEditor1.NewProperty += MetadataEditor1_NewProperty;
      FormClosing += (a, e) => DataSave();

      DataLoad();

      Processing.SplashClose();
    }

    public ConcurrentQueue<Dictionary<string, object>> Documets
    {
      get
      {
        var res = _documets.Where(doc => !doc.Get(_ignoreLabel, false));
        foreach (var doc in res)
          doc.Remove(_ignoreLabel);
        return new ConcurrentQueue<Dictionary<string, object>>(res);
      }
    }

    private void btn_menu_next_Click(object sender, EventArgs e)
    {
      DataSave();
      _documets.Next();
      DataLoad();
    }

    private void btn_menu_preview_Click(object sender, EventArgs e)
    {
      DataSave();
      _documets.Preview();
      DataLoad();
    }

    private void DataLoad()
    {
      lbl_menu.Text = @"0 / 0";

      if (_documets       == null ||
          _documets.Count == 0)
        return;

      lbl_menu.Text = $"{_documets.CurrentIndex + 1} / {_documets.Count}";

      txt_text.Text = _documets.CurrentItem.Get("Text", "");
      _checkBox.Checked = _documets.CurrentItem.Get(_ignoreLabel, false);

      var store = new Dictionary<string, object>();
      foreach (var x in _documets.CurrentItem)
        if (x.Key != "Text" ||
            x.Key.StartsWith(_ignoreLabel))
          store.Add(x.Key, x.Value);

      metadataEditor1.Metadata = store;
    }

    private void DataSave()
    {
      if (_documets.CurrentItem == null)
        return;

      try
      {
        _documets.CurrentItem.Set("Text", txt_text.Text);
      }
      catch
      {
        // ignore
      }

      try
      {
        _documets.CurrentItem.Set(_ignoreLabel, _checkBox.Checked);
      }
      catch
      {
        // ignore
      }

      foreach (var x in metadataEditor1.Metadata)
        try
        {
          _documets.CurrentItem.Set(x.Key, x.Value);
        }
        catch
        {
          // ignore
        }
    }

    private void MetadataEditor1_NewProperty(object sender, EventArgs e)
    {
      DataSave();
      var entry = (KeyValuePair<string, Type>) sender;

      foreach (var documet in _documets)
        documet.Set(entry.Key, entry.Value == typeof(string) ? "" : Activator.CreateInstance(entry.Value));
      DataLoad();
    }
  }
}