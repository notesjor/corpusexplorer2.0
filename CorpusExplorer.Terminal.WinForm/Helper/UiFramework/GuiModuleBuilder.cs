#region

using System;
using System.Drawing;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Forms.Interfaces;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Helper.UiFramework
{
  public static class GuiModuleBuilder
  {
    private static IMainForm _dashboard;

    public static void InitializeGuiModuleBuilder(IMainForm dashboard, GuiModelBuilderProjectRequestDelegate getProject)
    {
      GuiModulePrototype.GetProjectDelegate = getProject;
      _dashboard = dashboard;
    }

    public static GuiModulePrototype InitializePage(
      RadPanorama menu,
      RadMenuItem menuButton,
      EventHandler tileClick,
      RadPageViewPage page,
      Image iconBig,
      Image iconSmall,
      string header,
      string description,
      string urlHandbook,
      string urlHandsOnLab,
      string urlVideo,
      string urlOnline)
    {
      // Definiere das PanoramaMenü
      var tile = new RadTileElement
      {
        Font = new Font("Segoe UI Light", 10),
        TextAlignment = ContentAlignment.BottomCenter,
        BackColor = Color.White,
        BorderColor = Color.DarkSeaGreen,
        ForeColor = Color.Black,
        TextWrap = true,
        Text = header,
        ToolTipText = description,
        UseMnemonic = false,
        Image = iconBig,
        Row = menu.Items.Count % 2 == 0 ? 0 : 1,
        Column = menu.Items.Count / 2
      };

      var module = new GuiModulePrototype(
                                          iconBig,
                                          iconSmall,
                                          header,
                                          description,
                                          urlHandbook,
                                          urlHandsOnLab,
                                          urlVideo,
                                          urlOnline)
      {
        Location = new Point(0, 0),
        Dock = DockStyle.Fill,
        Margin = new Padding(0),
        Padding = new Padding(0),
        Name = "Modul_" + header,
        ModulPage = tileClick,
        Dashboard = _dashboard
      };

      tile.Tag = module; // Wichtig, da hierrüber das Reset des ViewModels erfolgt.
      tile.Click += tileClick;
      menu.Items.Add(tile);
      page.Controls.Add(module);

      // Erweitert das MainMenu
      var newMenuItem = new RadMenuItem {Image = iconSmall, Text = header};
      if (newMenuItem.Children[2].Children[0].Children[1].Children[0] is TextPrimitive tp)
        tp.UseMnemonic = false;
      newMenuItem.Click += tileClick;
      menuButton.Items.Add(newMenuItem);

      // Speichert Menü- und Tile-Einträge des Prototype
      module.SaveStates(tile, newMenuItem);

      return module;
    }
  }
}