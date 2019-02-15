using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Terminal.WinForm.Forms.Dashboard;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Helper.UiFramework
{
  public static class FavoriteManager
  {
    private static Dictionary<string, FavoriteManagerEntry> _entries = new Dictionary<string, FavoriteManagerEntry>();
    private static Dashboard _dashboard;
    private static bool _loadDefault;

    public static RadMenuItem[] PinnedItems
      => _loadDefault
           ? LoadDefault()
           : AddEventHandlers((from x in _entries where x.Value.IsPinned select x.Value)
                             .Select(x => new RadMenuItem(x.Title) {Image = x.Image, Tag = x}).ToArray());

    public static RadMenuItem[] MostFrequentItems
      => AddEventHandlers((from x in _entries where !x.Value.IsPinned && x.Value.Count > 0 select x.Value)
                         .OrderByDescending(x => x.Count)
                         .Take(10)
                         .Select(x => new RadMenuItem(x.Title) {Image = x.Image, Tag = x}).ToArray());

    public static ListViewDataItem[] PinnedConfiguration
    {
      get
      {
        var res = (from x in _entries where x.Value.IsPinned select x)
                 .Select(x => new ListViewDataItem(x.Value.Title) {CheckState = ToggleState.On, Tag = x.Key}).ToList();
        res.AddRange((from x in _entries where !x.Value.IsPinned select x)
                    .OrderByDescending(x => x.Value.Count).Select(x => new ListViewDataItem(x.Value.Title)
                                                                    {CheckState = ToggleState.Off, Tag = x.Key}));
        return res.ToArray();
      }
      set
      {
        foreach (var x in value)
        {
          var key = x.Tag as string;
          if (string.IsNullOrEmpty(key))
            continue;

          if (_entries.ContainsKey(key))
            _entries[key].IsPinned = x.CheckState == ToggleState.On;
        }
      }
    }

    public static void InitializeFavoriteManager(Dashboard dashboard)
    {
      _dashboard = dashboard;
      Load();
    }

    public static void Load()
    {
      try
      {
        _entries = Serializer.Deserialize<Dictionary<string, FavoriteManagerEntry>>("fav.bin");
      }
      catch
      {
        // ignore
      }

      if (_entries != null)
        return;

      _entries = new Dictionary<string, FavoriteManagerEntry>();
      _loadDefault = true;
    }

    public static void Save()
    {
      try
      {
        Serializer.Serialize(_entries, "fav.bin", true);
      }
      catch
      {
        // ignore
      }
    }

    public static void InitializeView(string title, Image image, string modulePage, RadPageViewPage page)
    {
      if (_entries.ContainsKey(modulePage))
        _entries[modulePage].Page = page;
      else
        _entries.Add(modulePage, new FavoriteManagerEntry
        {
          Count = 0,
          Image = image,
          IsPinned = false,
          ModulePage = modulePage,
          Title = title,
          Page = page
        });
    }

    public static void CountPage(string modulePage)
    {
      if (_entries.ContainsKey(modulePage))
        _entries[modulePage].Count++;
    }

    private static RadMenuItem[] LoadDefault()
    {
      _loadDefault = false;

      var predef = new[]
      {
        "CorpusExplorer.Terminal.WinForm.View.Fulltext.FulltextKwicSearch",
        "CorpusExplorer.Terminal.WinForm.View.Frequency.FrequencyGrid",
        "CorpusExplorer.Terminal.WinForm.View.Cooccurrence.CooccurrenceGridSearch",
        "CorpusExplorer.Terminal.WinForm.View.Cooccurrence.CooccurrenceTagPie",
        "CorpusExplorer.Terminal.WinForm.View.CorpusDistribution.CorpusDistributionHeatmap",
        "CorpusExplorer.Terminal.WinForm.View.Special.Html5DevLab"
      };

      foreach (var x in predef.Where(x => _entries.ContainsKey(x)))
        _entries[x].IsPinned = true;

      return AddEventHandlers(predef
                             .Where(x => _entries.ContainsKey(x))
                             .Select(x => new RadMenuItem(_entries[x].Title)
                                       {Image = _entries[x].Image, Tag = _entries[x]}).ToArray());
    }

    private static RadMenuItem[] AddEventHandlers(RadMenuItem[] items)
    {
      foreach (var item in items)
        item.Click += (s, e) =>
        {
          var proj = CorpusExplorerEcosystem.InitializeMinimal();
          if (proj.CountCorpora == 0)
          {
            MessageBox.Show(Resources.Msg_YouNeedToLoadACorpus);
            return;
          }

          var mi = s as RadMenuItem;
          var p = mi?.Tag as FavoriteManagerEntry;
          var c = p?.Page.Controls.OfType<AbstractView>().FirstOrDefault();
          if (c == null)
            return;
          _dashboard.CurrentView = c;
          c.OnShowVisualisation();

          var rpv0 = p.Page.Parent as RadPageView;
          var gui0 = rpv0?.Parent as GuiModulePrototype;
          var rpvp1 = gui0?.Parent as RadPageViewPage;
          var rpv1 = rpvp1?.Parent as RadPageView;
          var rpvp2 = rpv1?.Parent as RadPageViewPage;
          var rpv2 = rpvp2?.Parent as RadPageView;
          var rpvp3 = rpv2?.Parent as RadPageViewPage;
          var rpv3 = rpvp3?.Parent as RadPageView;

          rpv0.SelectedPage = p.Page;
          rpv1.SelectedPage = rpvp1;
          rpv2.SelectedPage = rpvp2;
          rpv3.SelectedPage = rpvp3;
        };
      return items;
    }
  }

  [Serializable]
  public class FavoriteManagerEntry
  {
    [NonSerialized] public RadPageViewPage Page;

    public string Title { get; set; }
    public Image Image { get; set; }
    public string ModulePage { get; set; }
    public bool IsPinned { get; set; }
    public int Count { get; set; }
  }
}