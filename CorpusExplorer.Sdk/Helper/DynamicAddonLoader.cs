using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public static class DynamicAddonLoader
  {
    public enum LoadState
    {
      Offline,
      Online,
      NeedsUpdate
    }

    /// <summary>
    ///   Gibt alle verfügbaren Komponenten unter der url bzw. dem offlinePath zurück.
    /// </summary>
    /// <param name="url">URL unter der die Online-Komponenten verfügbar sind.</param>
    /// <param name="offlinePath">Relativer Pfad unter dem die verfügbaren Offline-Komponeten gelistet werden</param>
    /// <returns>Auflistung von Komponenten</returns>
    public static DynamicComponent[] GetComponents(string url, string offlinePath)
    {
      try
      {
        var res = new Dictionary<string, DynamicComponent>();

        var offline = TextToManifest(FileIO.ReadText(offlinePath, Encoding.UTF8));
        if (offline != null)
          foreach (var x in offline)
            if (!res.ContainsKey(x[0]) && File.Exists(Configuration.GetDependencyPath(x[3])))
              res.Add(x[0], new DynamicComponent(x[0], x[1], LoadState.Offline, x[2], x[3], offlinePath));

        var online = GetOnlineComponents(url);
        if (online != null)
          foreach (var x in online)
            if (res.ContainsKey(x[0]) && res[x[0]].Version != x[1])
            {
              res[x[0]].LoadState = LoadState.NeedsUpdate;
              res[x[0]].Version = $"{res[x[0]].Version} > {x[1]}";
            }
            else
            {
              res[x[0]] = new DynamicComponent(x[0], x[1], LoadState.Online, x[2], x[3], offlinePath);
            }

        return res.Count == 0 ? null : res.Values.ToArray();
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static IEnumerable<string[]> GetOnlineComponents(string url)
    {
      try
      {
        using (var wc = new CorpusExplorerWebClient())
        {
          return TextToManifest(wc.DownloadString(url));
        }
      }
      catch
      {
        return null;
      }
    }

    private static IEnumerable<string[]> TextToManifest(string text)
    {
      // Anpassungen gegenüber CorpusExplorer.Installer.Sdk.CorpusExplorerBootstrapper
      // 1. - Filterung von # - z. B. CALL# oder LINK#
      // 2. - DynamicAddon.Manifests haben folgendes Schema NAME|VERSION|URL|LOCAL - NAME ist der Name der Komponente / auf LOCAL erfolgt später Zugriff

      try
      {
        var lines = text.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
        return lines
              .Where(line => !line.Contains("#")) // Anpassung 1.
              .Select(line =>
                        line.Replace("{CPU}", Environment.Is64BitProcess ? "x64" : "x86")
                            .Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries)); // Anpassung 2.
      }
      catch
      {
        return null;
      }
    }

    public class DynamicComponent
    {
      public DynamicComponent(string name, string version, LoadState loadState, string url, string localPath,
                              string offlineManifestPath)
      {
        Name = name;
        Version = version;
        LoadState = loadState;
        Url = url;
        LocalPath = Configuration.GetDependencyPath(localPath);
        OfflineManifestPath = Path.Combine(Configuration.DependencyPath, $"mod_{offlineManifestPath}.info");
      }

      public string Name { get; }
      public string Version { get; set; }
      public LoadState LoadState { get; set; }
      public string Url { get; }
      public string LocalPath { get; }
      public string OfflineManifestPath { get; }

      public bool Ensure()
      {
        switch (LoadState)
        {
          case LoadState.NeedsUpdate:
            if (Install())
              return true;
            LoadState = LoadState.Offline;
            return Ensure();
          case LoadState.Offline:
            if (File.Exists(LocalPath))
              return true;
            LoadState = LoadState.Online;
            return Ensure();
          case LoadState.Online:
            return Install() && File.Exists(LocalPath);
          default:
            throw new ArgumentOutOfRangeException();
        }
      }

      private bool Install()
      {
        try
        {
          var tempDir = Path.Combine(Path.GetTempPath(), "CorpusExplorer");

          if (!Directory.Exists(tempDir))
            Directory.CreateDirectory(tempDir);

          var tempFile = Path.Combine(tempDir, "mod.zip");
          using (var wc = new CorpusExplorerWebClient())
          {
            wc.DownloadFile(Url, tempFile);
          }

          ZipHelper.Uncompress(tempFile, Configuration.DependencyPath);

          RegisterInUpdateInfo();

          return true;
        }
        catch
        {
          return false;
        }
      }

      private void RegisterInUpdateInfo()
      {
        try
        {
          var updateInfo = Path.Combine(Configuration.AppPath, "update.info");
          FileIO.Write(updateInfo,
                       new HashSet<string>(FileIO.ReadLines(updateInfo, Encoding.UTF8))
                       {
                         $"{Url}|{Version}"
                       }.ToArray());
        }
        catch
        {
          // ignore
        }
      }
    }
  }
}