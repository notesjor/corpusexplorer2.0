using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;
using CorpusExplorer.Terminal.WinForm.Forms.Dashboard;
using CorpusExplorer.Terminal.WinForm.Properties;
using Newtonsoft.Json;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Helper.UiFramework
{
  public static class InAppAddonHelper
  {
    public static void InitializeInAppCorpusRepository(RadScrollablePanel panel)
    {
      panel.Controls.Clear();
      var items = ConvertToAddonItem(Resources.AddonJsonInfoCorpora);
      for (var i = items.Length - 1; i > -1; i--)
      {
        try
        {
          var x = items[i];
          var text = $"<html>{x.Info}<br/><i>ca. {x.SizeDocuments} Dokumente - ca. {x.SizeSentences} Sätze - ca. {x.SizeTokens} Token - Layer: {x.Layer}</i></html>";
          panel.Controls.Add(new AddonAppInstallState(x.Name, text, x.SizeFile, x.UrlInfo, x.UrlPack, x.RemoveInfo, Configuration.MyCorpora)
          {
            Padding = new System.Windows.Forms.Padding(3, 5, 2, 5),
            Dock = System.Windows.Forms.DockStyle.Left
          });
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }
      }
    }

    public static void InitializeInAppAddonRepository(RadScrollablePanel panel)
    {
      panel.Controls.Clear();
      var items = ConvertToAddonItem(Resources.AddonJsonInfoPlugin);
      for (var i = items.Length - 1; i > -1; i--)
      {
        var x = items[i];
        panel.Controls.Add(new AddonAppInstallState(x.Name, x.Info, x.SizeFile, x.UrlInfo, x.UrlPack, x.RemoveInfo, Configuration.MyAddons)
        {
          Padding = new System.Windows.Forms.Padding(3, 5, 2, 5),
          Dock = System.Windows.Forms.DockStyle.Left
        });
      }
    }

    private static AddonItem[] ConvertToAddonItem(string json) => JsonConvert.DeserializeObject<AddonItem[]>(json);
  }
}
