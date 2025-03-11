using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Helper.UiFramework
{
  public static class InAppAddonHelper
  {
    public static void InitializeInAppCorpusRepository(RadScrollablePanel panel)
    {
      panel.Controls.Clear();
      var items = ReadCorpusRepository("repository_corpora.manifest");
      for (var i = items.Length - 1; i > -1; i--)
      {
        try
        {
          var x = items[i];
          panel.Controls.Add(new AddonCorpusInstallState(x.Label, x.Size, x.Documents, x.Sentences, x.Token, x.Layer,
                                                         x.Url, x.Description)
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
      var items = ReadAppRepository("repository_addons.manifest");
      for (var i = items.Length - 1; i > -1; i--)
      {
        var x = items[i];
        panel.Controls.Add(new AddonAppInstallState(x.Label, x.Description, x.Size, x.UrlInfo, x.UrlInstall, x.AddonName)
        {
          Padding = new System.Windows.Forms.Padding(3, 5, 2, 5),
          Dock = System.Windows.Forms.DockStyle.Left
        });
      }
    }

    private static RepositoryAddonEntry[] ReadAppRepository(string file)
    {
      var lines = File.ReadAllLines(file, Encoding.UTF8);

      return (from line in lines
              select line.Split(Splitter.Tab, StringSplitOptions.RemoveEmptyEntries)
              into split
              where split.Length == 6
              select new RepositoryAddonEntry
              {
                Label = split[0],
                Description = split[1],
                Size = split[2],
                UrlInfo = split[3],
                UrlInstall = split[4],
                AddonName = split[5]
              }).ToArray();
    }

    private static RepositoryCorpusEntry[] ReadCorpusRepository(string file)
    {
      var lines = File.ReadAllLines(Path.Combine(Configuration.AppPath, file), Encoding.UTF8);

      return (from line in lines
              select line.Split(Splitter.Tab, StringSplitOptions.RemoveEmptyEntries)
              into split
              where split.Length == 8
              select new RepositoryCorpusEntry
              {
                Label = split[0],
                Size = split[1],
                Documents = split[2],
                Sentences = split[3],
                Token = split[4],
                Layer = split[5],
                Url = split[6],
                Description = split[7]
              }).ToArray();
    }

    private class RepositoryCorpusEntry
    {
      public string Label { get; set; }
      public string Size { get; set; }
      public string Documents { get; set; }
      public string Sentences { get; set; }
      public string Token { get; set; }
      public string Url { get; set; }
      public string Description { get; set; }
      public string Layer { get; set; }
    }

    private class RepositoryAddonEntry
    {
      public string Label { get; set; }
      public string Description { get; set; }
      public string Size { get; set; }
      public string UrlInfo { get; set; }
      public string UrlInstall { get; set; }
      public string AddonName { get; set; }
    }
  }
}
