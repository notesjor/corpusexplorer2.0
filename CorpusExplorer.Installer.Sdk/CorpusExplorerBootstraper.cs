#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Installer.Sdk.Properties;
using CorpusExplorer.Installer.Sdk.View;
using CorpusExplorer.Sdk.Diagnostic;
using ICSharpCode.SharpZipLib.Zip;
using IWshRuntimeLibrary;
using File = System.IO.File;

#endregion

namespace CorpusExplorer.Installer.Sdk
{
  public static class CorpusExplorerBootstraper
  {
    private static string _appPath;
    private static List<string[]> _installed;
    private static bool _muteGui;
    private static readonly List<string> _repositoryUrls = new List<string>();
    private static string _updateInfo;

    private static UpdateState[] CheckForUpdates()
    {
      try
      {
        // Datei in der die Update-Versionen gespeichert werden
        _updateInfo = Path.Combine(_appPath, "update.info");

        // Lade lokale update.info
        _installed = File.Exists(_updateInfo)
                       ? new List<string[]>(TextToManifest(FileIO.ReadText(_updateInfo)))
                       : new List<string[]>();

        // Lade online update.info (aka updates.manifest)
        var online = new List<string[]>();

        foreach (var url in _repositoryUrls)
        {
          string text = null;
          try
          {
            using (var wc = new WebClient())
            {
              text = wc.DownloadString(url);
            }
          }
          catch (WebException ex)
          {
            InMemoryErrorConsole.Log(ex);
          }
          catch (Exception ex)
          {
            InMemoryErrorConsole.Log(ex);
          }
          if (string.IsNullOrEmpty(text))
            continue;
          online.AddRange(TextToManifest(text));
        }

        // Vergleiche lokal und online verf�gbare Versionen. Es werden nur die URLs der neuen oder nicht installierter Komponenten zur�ckgegeben.        
        var list = new List<UpdateState>();
        foreach (var oentry in online)
          try
          {
            var ientry = _installed.FirstOrDefault(x => oentry[0] == x[0]);
            if (oentry[0].StartsWith("LINK#"))
              list.Add(
                new UpdateState
                {
                  Url = oentry[0],
                  InstalledVersion = "SET",
                  OnlineVersion = "SET",
                  InstallationCompleted = ientry != null
                });
            else if ((ientry == null) ||
                     (ientry[1] != oentry[1]))
              list.Add(
                new UpdateState
                {
                  Url = oentry[0],
                  InstalledVersion = oentry[1],
                  OnlineVersion = oentry[1],
                  Delete = oentry.Length == 3 ? oentry[2] : null,
                  InstallationCompleted = false
                });
          }
          catch (Exception ex)
          {
            InMemoryErrorConsole.Log(ex);
          }
        return list.ToArray();
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    // ReSharper disable once SuggestBaseTypeForParameter
    private static void DoUpdate(UpdateState[] updates)
    {
      var tempDir = Path.Combine(Path.GetTempPath(), "CorpusExplorer");

      if (!Directory.Exists(tempDir))
        Directory.CreateDirectory(tempDir);

      for (var i = 0; i < updates.Length; i++)
      {
        try
        {
          if (!string.IsNullOrEmpty(updates[i].Delete))
            if (Directory.Exists(updates[i].Delete))
              DoUpdate_Delete(updates[i].Delete);
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }
        try
        {
          if (updates[i].IsCEC8)
            DoUpdate_Cec8(updates[i].Url);
          else if (updates[i].IsCEC7)
            DoUpdate_Cec7(updates[i].Url);
          else if (updates[i].IsCEC6)
            DoUpdate_Cec6(updates[i].Url);
          else if (updates[i].IsCEC5)
            DoUpdate_Cec5(updates[i].Url);
          else if (updates[i].IsCEDB)
            DoUpdate_Cedb(updates[i].Url);
          else if (updates[i].IsCML)
            DoUpdate_Cml(updates[i].Url);
          else if (updates[i].IsCEFS)
            DoUpdate_Cefs(updates[i].Url, tempDir, i);
          else if (updates[i].IsLink)
            DoUpdate_Link(updates[i].Url);
          else if (updates[i].IsZIP)
            DoUpdate_Zip(updates[i].Url, tempDir, i);
          else if (updates[i].IsCECP)
            DoUpdate_Cecp(updates[i].Url, tempDir, i);

          updates[i].InstallationCompleted = true;
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }
      }

      try
      {
        Directory.Delete(tempDir, true);
      }
      catch { }

      foreach (var update in updates)
      {
        if (!update.InstallationCompleted)
          continue;

        var index = _installed.FindIndex(x => x[0] == update.Url);
        if (index == -1)
          _installed.Add(new[] { update.Url, update.OnlineVersion });
        else
          _installed[index][1] = update.OnlineVersion;
      }

      // Speichere lokale update.info
      try
      {
        FileIO.Write(_updateInfo, ManifestToText(_installed));
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }

    private static void DoUpdate_Delete(string delete)
    {
      Directory.Delete(Path.Combine(_appPath, delete), true);
    }

    private static void DoUpdate(bool askForUpdate)
    {
      try
      {
        StartUpdate(Resources.UpdateIsRunningPleaseBePatient, askForUpdate);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
      try
      {
        var pflag = Path.Combine(_appPath, "globalpath.flag");
        if (File.Exists(pflag))
          return;

        Process.Start(
          new ProcessStartInfo
          {
            Arguments = $"PATH \"{_appPath}\";%PATH%",
            CreateNoWindow = true,
            FileName = "SETX",
            UseShellExecute = true,
            WindowStyle = ProcessWindowStyle.Hidden
          });

        File.Create(pflag).Close();
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }

    private static void DoUpdate_Cec8(string url)
    {
      var path = Path.Combine(MyCorpora, url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1));

      using (var wc = new WebClient())
      {
        wc.DownloadFile(url, path);
      }

      if (path.ToLower().EndsWith(".gz"))
        DecompressGzipFile(path);
    }

    private static void DoUpdate_Cec7(string url)
    {
      var path = Path.Combine(MyCorpora, url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1));

      using (var wc = new WebClient())
      {
        wc.DownloadFile(url, path);
      }

      if (path.ToLower().EndsWith(".gz"))
        DecompressGzipFile(path);
    }

    private static void DoUpdate_Cec6(string url)
    {
      var path = Path.Combine(MyCorpora, url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1));

      using (var wc = new WebClient())
      {
        wc.DownloadFile(url, path);
      }

      if (path.ToLower().EndsWith(".gz"))
        DecompressGzipFile(path);
    }

    private static void DecompressGzipFile(string path)
    {
      using (var output = File.OpenWrite(path.Substring(0, path.Length - 3)))
      using (var input = File.OpenRead(path))
      using (var gz = new GZipStream(input, CompressionMode.Decompress))
      {
        gz.CopyTo(output);
      }

      try
      {
        File.Delete(path);
      }
      catch
      {
        // ignore
      }
    }

    private static void DoUpdate_Cedb(string url)
    {
      var path = Path.Combine(MyCorpora, url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1));

      using (var wc = new WebClient())
      {
        wc.DownloadFile(url, path);
      }
    }

    private static void DoUpdate_Cec5(string url)
    {
      var path = Path.Combine(MyCorpora, url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1));

      using (var wc = new WebClient())
      {
        wc.DownloadFile(url, path);
      }
    }

    private static void DoUpdate_Cefs(string url, string tempDir, int i)
    {
      var tempFile = Path.Combine(tempDir, "update." + i + ".zip");
      var path = Path.Combine(MyCorpora, url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1).Replace(".cefs", ""));

      using (var wc = new WebClient())
      {
        wc.DownloadFile(url, tempFile);
      }

      var zip = new FastZip();
      zip.ExtractZip(tempFile, path, null);
    }

    private static void DoUpdate_Cml(string url)
    {
      var path = Path.Combine(MyDataSources, url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1));

      using (var wc = new WebClient())
      {
        wc.DownloadFile(url, path);
      }
    }

    private static void DoUpdate_Link(string url)
    {
      var info = url.Split(new[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
      if (info.Length != 3)
        return;

      var wshShell = new WshShell();
      var NewShortcut =
        (IWshShortcut)
        wshShell.CreateShortcut($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{info[1]}.lnk");
      var path = Path.Combine(_appPath, info[2]);

      NewShortcut.TargetPath = path;
      NewShortcut.WindowStyle = 1;
      NewShortcut.IconLocation = $"{path},0";
      NewShortcut.WorkingDirectory = _appPath;
      NewShortcut.Save();
    }

    private static void DoUpdate_Cecp(string url, string tempDir, int i)
    {
      var tempFile = Path.Combine(tempDir, "update." + i + ".zip");

      using (var wc = new WebClient())
      {
        wc.DownloadFile(url, tempFile);
      }

      var zip = new FastZip();
      zip.ExtractZip(tempFile, MyCorpora, null);
    }

    private static void DoUpdate_Zip(string url, string tempDir, int i)
    {
      var tempFile = Path.Combine(tempDir, "update." + i + ".zip");

      using (var wc = new WebClient())
      {
        wc.DownloadFile(url, tempFile);
      }

      var zip = new FastZip();
      zip.ExtractZip(tempFile, _appPath, null);
    }

    private static void EnsurePath(string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
    }

    private static void EnsurePaths()
    {
      EnsurePath(_appPath);
      EnsurePath(MyCorpora);
      EnsurePath(MyProjects);
      EnsurePath(MyDataSources);
      EnsurePath(MyAddons);
    }

    private static string MyAddons => Path.Combine(
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
      Resources.CorpusExplorerMyAddons);
    private static string MyDataSources => Path.Combine(
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
      Resources.CorpusExplorerMyDataSources);
    private static string MyProjects => Path.Combine(
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
      Resources.CorpusExplorerMyProjects);
    private static string MyCorpora => Path.Combine(
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
      Resources.CorpusExplorerMyCorpora);

    public static void InstallOnly(string repositoryUrl, string appPath) { Run(repositoryUrl, null, appPath, true); }

    public static void Launch(string repositoryUrl, string[] args, string appPath = null)
    {
      Run(repositoryUrl, args, appPath, false);
    }

    private static void Load3rdPartyRepositories()
    {
      if (!Directory.Exists(MyAddons))
        return;

      var addons = Directory.GetFiles(MyAddons, "*.ceAddon", SearchOption.TopDirectoryOnly);
      foreach (var addon in addons)
        try
        {
          var urls = FileIO.ReadLines(addon);
          foreach (var url in urls.Where(url => url.StartsWith("http://") || url.StartsWith("https://")))
            _repositoryUrls.Add(url);
        }
        catch { }
    }

    private static void Main(string[] args, bool installOnly, string appPath = null)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      _muteGui = installOnly;
      _appPath = appPath ?? Path.Combine(
                   Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                   @"CorpusExplorer\App");
      var exePath = Path.Combine(_appPath, "CorpusExplorer.exe");

      // �berpr�f die Standardverzeichnisse
      try
      {
        EnsurePaths();
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }

      var arguments = new List<string>();
      try
      {
        if (args != null)
          foreach (var s in args)
            if (s.ToLower().EndsWith(".ceaddon") && File.Exists(s))
            {
              var path = Path.Combine(MyAddons, Path.GetFileName(s));
              if (s != path)
                File.Copy(s, path);
            }
            else
              arguments.Add(s);
      }
      catch { }

      // Wird InstallOnly gesetzt wird aus Sicherheitsgr�nden die Installation/Updates von Addons unterbunden.
      if (!installOnly)
        try
        {
          // Add-ons installiert sind und 
          Load3rdPartyRepositories();
        }
        catch { }

      try
      {
        // Muss der CE installiert/aktualisiert werden?
        if (File.Exists(exePath))
        {
          // f�hre Update vor Programmstart aus...          
          DoUpdate(true);
        }
        else
        {
          // f�hre Installation aus...
          if (!StartInstallation())
            // Wenn Installation fehlerhaft/abgebrochen, dann schlie�e Programm...
            return;
        }
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }

      // Wenn der CorpusExplorer nur installiert werden soll
      if (installOnly)
        return;

      // Alles aktuell und installiert? - Starte Programm      
      try
      {
        var process = args == null ? Process.Start(exePath) : Process.Start(exePath, string.Join(" ", arguments));
        process?.WaitForExit();
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }

    private static string ManifestToText(List<string[]> manifest)
    {
      var stb = new StringBuilder();
      foreach (var repo in manifest.Where(repo => (repo != null) && (repo.Length == 2)))
        stb.AppendLine($"{repo[0]}|{repo[1]}");
      return stb.ToString();
    }

    private static void Run(string repositoryUrl, string[] args, string appPath, bool installOnly)
    {
      AddonInstaller(args);

      bool createdNew;
      var mutex = new Mutex(true, "CorpusExplorer v2.0", out createdNew);
      if (!createdNew)
        return;

      TerminateAllRunningInstances();
      _repositoryUrls.Add(repositoryUrl);

      try
      {
        Main(AppDomain.CurrentDomain.SetupInformation.ActivationArguments?.ActivationData ?? args, installOnly, appPath);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
      finally
      {
        mutex.ReleaseMutex();
      }

      if (installOnly)
        return;

      if (!InMemoryErrorConsole.Errors.Any())
        return;

      var form = new ErrorReport();
      form.ShowDialog();
    }

    private static void AddonInstaller(string[] args)
    {
      if (args == null || args.Length == 0)
        return;

      var valid = args.Where(x => x.ToLower().EndsWith(".ceaddon") && File.Exists(x) && !x.StartsWith(MyAddons)).ToArray();
      if (valid.Length == 0)
        return;

      foreach (var x in valid)
      {
        try
        {
          File.Copy(x, Path.Combine(MyAddons, Path.GetFileName(x)));
        }
        catch
        {
          // ignore
        }
      }
    }

    private static bool StartInstallation()
    {
      if (!_muteGui)
      {
        var form = new MainForm();
        if (form.ShowDialog() != DialogResult.OK)
          return false;
      }

      StartUpdate(Resources.InstallationIsRunningPleaseBePatient, false);
      return true;
    }

    private static void StartUpdate(string message, bool askForUpdate)
    {
      var update = CheckForUpdates();

      if ((update == null) ||
          (update.Count(x => !x.InstallationCompleted) == 0))
        return;

      if (!_muteGui)
      {
        if (askForUpdate)
          if (
            MessageBox.Show(
              "F�r den CorpusExplorer steht ein Update bereit. Soll dieses jetzt installiert werden?",
              "CorpusExplorer aktualisieren?",
              MessageBoxButtons.YesNo) == DialogResult.No)
            return;

        Processing.SplashShow();
        Processing.SplashMessage(message);
      }

      DoUpdate(update);

      if (!_muteGui)
        Processing.SplashClose(Resources.UpdateCompleted);
    }

    private static void TerminateAllRunningInstances()
    {
      try
      {
        Process[] processes;
        do
        {
          processes = Process.GetProcessesByName("CorpusExplorer");
          foreach (var p in processes)
          {
            try
            {
              p.CloseMainWindow();
              continue;
            }
            catch (Exception ex)
            {
              InMemoryErrorConsole.Log(ex);
            }
            try
            {
              p.Close();
              continue;
            }
            catch (Exception ex)
            {
              InMemoryErrorConsole.Log(ex);
            }
            try
            {
              p.Kill();
            }
            catch (Exception ex)
            {
              InMemoryErrorConsole.Log(ex);
            }
          }
        }
        while (processes.Length > 0);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }

    private static IEnumerable<string[]> TextToManifest(string text)
    {
      try
      {
        var lines = text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        return lines.Select(line => line.Replace("{CPU}", Environment.Is64BitProcess ? "x64" : "x86").Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries));
      }
      catch
      {
        return null;
      }
    }

    private class UpdateState
    {
      public bool InstallationCompleted { get; set; }
      public string InstalledVersion { get; set; }

      public bool IsCEDB => Url.ToLower().EndsWith(".cedb");
      public bool IsCECP => Url.ToLower().EndsWith(".cecp");
      public bool IsCEC8 => Url.ToLower().EndsWith(".cec8.gz") || Url.ToLower().EndsWith(".cec8");
      public bool IsCEC7 => Url.ToLower().EndsWith(".cec7.gz") || Url.ToLower().EndsWith(".cec7");
      public bool IsCEC6 => Url.ToLower().EndsWith(".cec6.gz") || Url.ToLower().EndsWith(".cec6");
      public bool IsCEC5 => Url.ToLower().EndsWith(".cec5");
      public bool IsCEFS => Url.ToLower().EndsWith(".cefs");
      public bool IsCML => Url.ToLower().EndsWith(".cml");
      public bool IsLink => Url.StartsWith("LINK#");
      public bool IsZIP => Url.ToLower().EndsWith(".zip");
      public string OnlineVersion { get; set; }
      public string Url { get; set; }
      public string Delete { get; set; }
    }
  }
}