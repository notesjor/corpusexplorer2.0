#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Interfaces;
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
    private RadMenuItem _topMenu;
    private RadTileElement _topTile;

    /// <summary>
    ///   Initializes a new instance of the <see cref="GuiModulePrototype" /> class.
    /// </summary>
    public GuiModulePrototype(
      Image iconBig,
      Image iconSmall,
      string header,
      string describtion,
      string urlHandbook,
      string urlHandsOnLab,
      string urlVideo,
      string urlOnline)
    {
      InitializeComponent();
      Pages.GetChildAt(0).GetChildAt(0).Visibility = ElementVisibility.Collapsed;

      ihd_home.IHDImage = iconBig;
      ihd_home.IHDHeader = header;
      ihd_home.IHDDeescribtion = describtion;

      helpPanel1.HelpHandbookUrl = urlHandbook;
      helpPanel1.HelpHandsonlabUrl = urlHandsOnLab;
      helpPanel1.HelpOnlineUrl = urlOnline;
      helpPanel1.HelpVideoUrl = urlVideo;

      btn_home.Text = header;
      btn_home.Image = iconSmall;
    }

    public IMainForm Dashboard { get; set; }

    internal GuiModelBuilderProjectRequestDelegate GetProjectDelegate { get; set; }

    public bool IsVisible
    {
      get { return _topMenu.Visibility == ElementVisibility.Visible; }
      set
      {
        _topMenu.Visibility = _topTile.Visibility = value ? ElementVisibility.Visible : ElementVisibility.Collapsed;
      }
    }

    public EventHandler ModulPage { get; set; }

    public Project Project { get { return GetProjectDelegate(); } }

    public GuiModulePrototype AddView(
      AbstractView view,
      Image iconHeigh,
      Image iconLow,
      string label,
      bool isBeta = false)
    {
      VisualTweak(view);
      view.InitializeVisualisation(GetProjectDelegate);

      var page = new RadPageViewPage
      {
        Location = new Point(0, 0),
        Margin = new Padding(0),
        Padding = new Padding(0),
        Name = "Page_" + label,
        Text = label
      };

      view.Location = new Point(0, 0);
      view.Dock = DockStyle.Fill;

      page.Controls.Add(view);

      var menuItem1 = new RadMenuItem(page.Text) {Tag = page, Image = iconLow};

      menuItem1.Click += (sender, args) =>
      {
        var p = (RadPageViewPage) ((RadMenuItem) sender).Tag;

        if ((Project == null) ||
            (Project.CountCorpora == 0))
        {
          MessageBox.Show(Resources.PleaseLoadACorpus);
          return;
        }

        ModulPage(null, null);
        Pages.SelectedPage = p;
        InMemoryErrorConsole.TrackPageView($"page_mod_{view.GetType()}");
        Execute(p);
      };

      var menuItem2 = new RadMenuItem(page.Text) {Tag = page, Image = iconLow};
      menuItem2.Click += (sender, args) =>
      {
        var p = (RadPageViewPage) ((RadMenuItem) sender).Tag;

        if ((Project == null) ||
            (Project.CountCorpora == 0))
        {
          MessageBox.Show(Resources.PleaseLoadACorpus);
          return;
        }

        ModulPage(null, null);
        Pages.SelectedPage = p;
        InMemoryErrorConsole.TrackPageView($"page_mod_{view.GetType()}");
        Execute(p);
      };

      var tile = new RadTileElement
      {
        Text = page.Text,
        Tag = page,
        Column = modul_viewstates.Items.Count,
        Row = 0,
        Image = iconHeigh,
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
        InMemoryErrorConsole.TrackPageView($"page_mod_{view.GetType()}");
        Execute(p);
      };

      Pages.Pages.Add(page);
      _topMenu.Items.Add(menuItem2);
      modul_viewstates.Items.Add(tile);

      return this;
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

    public void SaveStates(RadTileElement topTile, RadMenuItem topMenu)
    {
      _topTile = topTile;
      _topMenu = topMenu;
    }

    public void StartModule() { Pages.SelectedPage = page_HOME; }

    private void VisualTweak(object control)
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