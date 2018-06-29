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
      btn_home.UseMnemonic = false;
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

    internal GuiModelBuilderProjectRequestDelegate GetProjectDelegate { get; set; }

    public GuiModulePrototype AddView(
      AbstractView view,
      Image iconHeigh,
      Image iconLow,
      string label,
      bool isBeta = false)
    {
      try
      {
        AddView_Initialize(view);

        var page = AddView_AddPage(view, label);
        Pages.Pages.Add(page);

        AddView_AddMenuItem1(view, iconLow, page);
        AddView_AddMenuItem2(view, iconLow, page);
        AddView_AddTile(view, iconHeigh, isBeta, page);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }

      return this;
    }

    private void AddView_AddTile(AbstractView view, Image iconHeigh, bool isBeta, RadPageViewPage page)
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
        InMemoryErrorConsole.TrackPageView($"page_mod_{view.GetType()}");
        Execute(p);
      };
      modul_viewstates.Items.Add(tile);
    }

    private void AddView_AddMenuItem2(AbstractView view, Image iconLow, RadPageViewPage page)
    {
      var menuItem2 = new RadMenuItem(page.Text) {Tag = page, Image = iconLow};
      menuItem2.Click += (sender, args) =>
      {
        var p = (RadPageViewPage) ((RadMenuItem) sender).Tag;

        if (Project == null ||
            Project.CountCorpora == 0)
        {
          MessageBox.Show(Resources.PleaseLoadACorpus);
          return;
        }

        ModulPage(null, null);
        Pages.SelectedPage = p;
        InMemoryErrorConsole.TrackPageView($"page_mod_{view.GetType()}");
        Execute(p);
      };
      _topMenu.Items.Add(menuItem2);
    }

    private void AddView_AddMenuItem1(AbstractView view, Image iconLow, RadPageViewPage page)
    {
      var menuItem1 = new RadMenuItem(page.Text) {Tag = page, Image = iconLow};

      menuItem1.Click += (sender, args) =>
      {
        var p = (RadPageViewPage) ((RadMenuItem) sender).Tag;

        if (Project == null ||
            Project.CountCorpora == 0)
        {
          MessageBox.Show(Resources.PleaseLoadACorpus);
          return;
        }

        ModulPage(null, null);
        Pages.SelectedPage = p;
        InMemoryErrorConsole.TrackPageView($"page_mod_{view.GetType()}");
        Execute(p);
      };
    }

    private static RadPageViewPage AddView_AddPage(AbstractView view, string label)
    {
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
      return page;
    }

    private void AddView_Initialize(AbstractView view)
    {
      VisualTweak(view);
      view.InitializeVisualisation(GetProjectDelegate);
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