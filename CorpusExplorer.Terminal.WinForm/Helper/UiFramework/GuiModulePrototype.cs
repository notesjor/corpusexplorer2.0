#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Interfaces;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Helper.UiFramework
{
  /// <summary>
  ///   The abstract multi page.
  /// </summary>
  [ToolboxItem(false)]
  public partial class GuiModulePrototype : AbstractUserControl
  {
    private readonly string _header;
    private RadMenuItem _topMenu;
    private RadTileElement _topTile;
    private List<EventHandler<EventArgs>> _eventViews = new List<EventHandler<EventArgs>>();

    /// <summary>
    ///   Initializes a new instance of the <see cref="GuiModulePrototype" /> class.
    /// </summary>
    public GuiModulePrototype(
      Image iconBig,
      Image iconSmall,
      string header,
      string description,
      string urlHandbook,
      string urlHandsOnLab,
      string urlVideo,
      string urlOnline)
    {
      InitializeComponent();
      Pages.GetChildAt(0).GetChildAt(0).Visibility = ElementVisibility.Collapsed;

      _headHome.HeadPanelImage = iconBig;
      _headHome.HeadPanelTitle = header;
      _headHome.HeadPanelDescription = description;

      helpPanel1.HelpHandbookUrl = urlHandbook;
      helpPanel1.HelpHandsonlabUrl = urlHandsOnLab;
      helpPanel1.HelpOnlineUrl = urlOnline;
      helpPanel1.HelpVideoUrl = urlVideo;

      btn_home.Text = header;
      btn_home.Image = iconSmall;
      btn_home.UseMnemonic = false;

      _header = header;
    }

    public IMainForm Dashboard { get; set; }

    public bool IsVisible
    {
      get => _topMenu.Visibility == ElementVisibility.Visible;
      set => _topMenu.Visibility =
               _topTile.Visibility = value ? ElementVisibility.Visible : ElementVisibility.Collapsed;
    }

    public EventHandler ModulPage { get; set; }

    public Project Project => GetProjectDelegate();

    internal static GuiModelBuilderProjectRequestDelegate GetProjectDelegate { get; set; }

    public GuiModulePrototype AddView(
      Type view,
      Image iconHeigh,
      Image iconLow,
      string label,
      bool isBeta = false)
    {
      try
      {
        var page = AddView_AddPage(view, label);
        Pages.Pages.Add(page);

        AddView_AddMenuItem(view, iconLow, page);
        AddView_AddTile(view, iconHeigh, isBeta, page);

        FavoriteManager.InitializeView($"{_header} > {label}", iconLow, view.GetType().ToString(), page);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }

      return this;
    }

    public GuiModulePrototype AddView(
      EventHandler<EventArgs> eventHandler,
      Bitmap iconHeigh, 
      Bitmap iconLow, 
      string label,
      string functionName,
      bool isBeta = false)
    {
      try
      {
        _eventViews.Add(eventHandler);
        AddView_AddMenuItem(label, iconLow, eventHandler, functionName);
        AddView_AddTile(label, iconHeigh, isBeta, eventHandler, functionName);

        // ToDo: FavoriteManager.InitializeView($"{_header} > {label}", iconLow, view.GetType().ToString(), page);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }

      return this;
    }

    private void AddView_AddTile(string label, Image iconHeigh, bool isBeta, EventHandler<EventArgs> eventHandler, string functionName)
    {
      var tile = new RadTileElement
      {
        Text = label,
        Tag = eventHandler,
        Column = modul_viewstates.Items.Count,
        Row = 0,
        Image = iconHeigh,
        UseMnemonic = false,
        Font = new Font("Segoe UI Light", 10),
        TextAlignment = ContentAlignment.BottomCenter,
        BackColor = Color.White,
        BorderColor = Color.DarkSeaGreen,
        ForeColor = Color.Black,
        TextWrap = true
      };
      if (isBeta)
        tile.BackgroundImage = Resources.beta;

      tile.Click += (sender, args) =>
      {
        var p = (RadPageViewPage)((RadTileElement)sender).Tag;
        Pages.SelectedPage = p;
        Execute(p);
      };
      modul_viewstates.Items.Add(tile);
    }

    private void AddView_AddMenuItem(string label, Image iconLow, EventHandler<EventArgs> eventHandler, string functionName)
    {
      var item = new RadMenuItem(label) { Tag = eventHandler, Image = iconLow };
      item.Click += (sender, args) =>
      {
        var e = (EventHandler<EventArgs>)((RadMenuItem)sender).Tag;

        if (Project              == null ||
            Project.CountCorpora == 0)
        {
          MessageBox.Show(Resources.PleaseLoadACorpus);
          return;
        }

        e(null, null);
      };
      _topMenu.Items.Add(item);
    }

    private void AddView_AddTile(Type view, Image iconHeigh, bool isBeta, RadPageViewPage page)
    {
      var tile = new RadTileElement
      {
        Text = page.Text,
        Tag = page,
        Column = modul_viewstates.Items.Count,
        Row = 0,
        Image = iconHeigh,
        UseMnemonic = false,
        Font = new Font("Segoe UI Light", 10),
        TextAlignment = ContentAlignment.BottomCenter,
        BackColor = Color.White,
        BorderColor = Color.DarkSeaGreen,
        ForeColor = Color.Black,
        TextWrap = true
      };
      if (isBeta)
        tile.BackgroundImage = Resources.beta;

      tile.Click += (sender, args) =>
      {
        var p = (RadPageViewPage) ((RadTileElement) sender).Tag;
        Pages.SelectedPage = p;
        FavoriteManager.CountPage(view.ToString());
        Execute(p);
      };
      modul_viewstates.Items.Add(tile);
    }

    private void AddView_AddMenuItem(Type view, Image iconLow, RadPageViewPage page)
    {
      var item = new RadMenuItem(page.Text) {Tag = page, Image = iconLow};
      item.Click += (sender, args) =>
      {
        var p = (RadPageViewPage) ((RadMenuItem) sender).Tag;

        if (Project              == null ||
            Project.CountCorpora == 0)
        {
          MessageBox.Show(Resources.PleaseLoadACorpus);
          return;
        }

        ModulPage(null, null);
        Pages.SelectedPage = p;
        FavoriteManager.CountPage(view.ToString());
        Execute(p);
      };
      _topMenu.Items.Add(item);
    }
    
    private static RadPageViewPage AddView_AddPage(Type type, string label)
    {
      var page = new RadPageViewPage
      {
        Location = new Point(0, 0),
        Margin = new Padding(0),
        Padding = new Padding(0),
        Name = "Page_" + label,
        Text = label,
        Tag = type
      };

      page.VisibleChanged += (s, e) =>
      {
        if (!(s is RadPageViewPage pv))
          return;

        if (pv.Controls.Count > 0)
          return;

        Processing.Invoke("Analysemodul wird geladen...", () =>
        {
          if (!(pv.Tag is Type t))
            return;

          if (!(Activator.CreateInstance(t) is AbstractView view))
            return;

          VisualTweak(view);
          view.InitializeVisualisation(GetProjectDelegate);
          view.Location = new Point(0, 0);
          view.Dock = DockStyle.Fill;
          page.Controls.Add(view);
        });
      };

      return page;
    }

    public void SaveStates(RadTileElement topTile, RadMenuItem topMenu)
    {
      _topTile = topTile;
      _topMenu = topMenu;
    }

    public void StartModule()
    {
      Pages.SelectedPage = page_HOME;
    }

    /// <summary>
    ///   The btn_home_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_home_Click(object sender, EventArgs e)
    {
      Pages.SelectedPage = page_HOME;
    }

    private void Execute(RadPageViewPage page)
    {
      foreach (var c in page.Controls.OfType<AbstractView>())
      {
        Dashboard.CurrentView = c;
        c.OnShowVisualisation();
      }
    }

    private static void VisualTweak(object control)
    {
      var view = control as AbstractView;
      if (view == null)
        return;
      var vis = view;
      foreach (
        var strip in vis.Controls.OfType<RadCommandBar>().SelectMany(rcb => rcb.Rows.SelectMany(row => row.Strips)))
        strip.OverflowButton.Visibility = ElementVisibility.Collapsed;
    }
  }
}