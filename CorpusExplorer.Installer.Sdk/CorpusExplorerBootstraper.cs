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
using CorpusExplorer.Installer.Sdk.Model;
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

    private static string MyAddons => Path.Combine(
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
      Resources.CorpusExplorerMyAddons);

    private static string MyCorpora => Path.Combine(
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
      Resources.CorpusExplorerMyCorpora);

    private static string MyDataSources => Path.Combine(
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
      Resources.CorpusExplorerMyDataSources);

    private static string MyProjects => Path.Combine(
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
      Resources.CorpusExplorerMyProjects);

    public static void InstallOnly(string repositoryUrl, string appPath)
    {
      Run(repositoryUrl, null, appPath, true);
    }

    public static void Launch(string repositoryUrl, string[] args, string appPath = null)
    {
      Run(repositoryUrl, args, appPath, false);
    }

    private static void AddonInstaller(string[] args)
    {
      if (args == null || args.Length == 0)
        return;

      var valid = args.Where(x => x.ToLower().EndsWith(".ceaddon") && File.Exists(x) && !x.StartsWith(MyAddons))
        .ToArray();
      if (valid.Length == 0)
        return;

      foreach (var x in valid)
        try
        {
          File.Copy(x, Path.Combine(MyAddons, Path.GetFileName(x)));
        }
        catch
        {
          // ignore
        }
    }

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

        // Vergleiche lokal und online verfügbare Versionen. Es werden nur die URLs der neuen oder nicht installierter Komponenten zurückgegeben.        
        var list = new List<UpdateState>();
        foreach (var oentry in online)
          try
          {
            var ientry = _installed.FirstOrDefault(x => oentry[0] == x[0]);
            if (oentry[0].StartsWith("LINK#"))
              list.Add(
                new UpdateState(oentry[0])
                {
                  OnlineVersion = "SET",
                  InstallationCompleted = ientry != null
                });
            else if (oentry[0].StartsWith("CALL#") && (ientry == null || ientry[1] != oentry[1]))
              list.Add(
                new UpdateState(oentry[0])
                {
                  OnlineVersion = oentry[1],
                  InstallationCompleted = ientry != null
                });
            else if (ientry == null || ientry[1] != oentry[1])
              list.Add(
                new UpdateState(oentry[0])
                {
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

    // ReSharper disable once SuggestBaseTypeForParameter
    private static void DoUpdate(UpdateState[] updates)
    {
      var tempDir = Path.Combine(Path.GetTempPath(), "CorpusExplorer");

      if (!Directory.Exists(tempDir))
        Directory.CreateDirectory(tempDir);

      var mb = 1024d * 1024d;
      var hasError = false;
      for (var i = 0; i < updates.Length; i++)
      {
        try
        {
          Processing.SplashMessage($"Paket {i + 1} von {updates.Length} wird heruntergeladen und installiert.");
        }
        catch
        {
          // ignore
        }

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
          switch (updates[i].Type)
          {
            case UpdateStateType.Cec5:
            case UpdateStateType.Cec6:
            case UpdateStateType.Cec7:
            case UpdateStateType.Cec8:
            case UpdateStateType.Cec9:
              DoUpdate_Cec(updates[i].Url);
              break;
            case UpdateStateType.Cecp:
              DoUpdate_Cecp(updates[i].Url, tempDir, i);
              break;
            case UpdateStateType.Cedb:
              DoUpdate_Cedb(updates[i].Url);
              break;
            case UpdateStateType.Cefs:
              DoUpdate_Cefs(updates[i].Url, tempDir, i);
              break;
            case UpdateStateType.Cml:
              DoUpdate_Cml(updates[i].Url);
              break;
            case UpdateStateType.Link:
              DoUpdate_Link(updates[i].Url);
              break;
            case UpdateStateType.Call:
              DoUpdate_Call(updates[i].Url, tempDir, i);
              break;
            case UpdateStateType.Zip:
              DoUpdate_Zip(updates[i].Url, tempDir, i);
              break;
            // ReSharper disable once RedundantCaseLabel
            case UpdateStateType.None:
            default:
              throw new ArgumentOutOfRangeException("UNKNOWN UPDATE TYPE");
          }

          updates[i].InstallationCompleted = true;
        }
        catch (Exception ex)
        {
          hasError = true;
          InMemoryErrorConsole.Log(ex);
        }
      }

      if (hasError)
        MessageBox.Show(
          "HINWEIS: Während der Installation/Aktualisierung kam es zu Problemen. Wie Sie selbst alle Probleme beheben können:\n1. Beenden Sie den CorpusExplorer.\n2. Sorgen Sie für eine stabile Internetverbindung.\n3. Starten Sie den CorpusExplorer erneut.",
          "Problem: Schlechte Internetverbindung", MessageBoxButtons.OK, MessageBoxIcon.Information);

      try
      {
        Directory.Delete(tempDir, true);
      }
      catch
      {
      }

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

    private static void DoUpdate_Call(string url, string tempDir, int i)
    {
      var info = url.Split(new[] { "#" }, StringSplitOptions.None);
      if (info.Length != 3)
        return;

      var tempFile = Path.Combine(tempDir, $"update.{i}.{info[1]}");
      DownloadFile(url, tempFile);

      var process = Process.Start(new ProcessStartInfo
      {
        Arguments = info[2],
        FileName = tempFile
      });
      process?.WaitForExit();
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

    private static void DoUpdate_Cec(string url)
    {
      var path = Path.Combine(MyCorpora, url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1));
      DownloadFile(url, path);

      if (path.ToLower().EndsWith(".gz"))
        DecompressGzipFile(path);
    }

    private static void DoUpdate_Cecp(string url, string tempDir, int i)
    {
      var tempFile = Path.Combine(tempDir, "update." + i + ".zip");
      DownloadFile(url, tempFile);

      var zip = new FastZip();
      zip.ExtractZip(tempFile, MyCorpora, null);
    }

    private static void DoUpdate_Cedb(string url)
    {
      var path = Path.Combine(MyCorpora, url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1));
      DownloadFile(url, path);
    }

    private static void DoUpdate_Cefs(string url, string tempDir, int i)
    {
      var tempFile = Path.Combine(tempDir, "update." + i + ".zip");
      var path = Path.Combine(MyCorpora,
        url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1).Replace(".cefs", ""));
      DownloadFile(url, tempFile);

      var zip = new FastZip();
      zip.ExtractZip(tempFile, path, null);
    }

    private static void DoUpdate_Cml(string url)
    {
      var path = Path.Combine(MyDataSources, url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1));
      DownloadFile(url, path);
    }

    private static void DoUpdate_Delete(string delete)
    {
      Directory.Delete(Path.Combine(_appPath, delete), true);
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

    private static void DoUpdate_Zip(string url, string tempDir, int i)
    {
      var tempFile = Path.Combine(tempDir, "update." + i + ".zip");
      DownloadFile(url, tempFile);
      
      var zip = new FastZip();
      zip.ExtractZip(tempFile, _appPath, null);
    }

    private static void DownloadFile(string url, string file)
    {
      using (var wc = new CorpusExplorerWebClient())
      {
        wc.DownloadFile(url, file);
      }
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
        catch
        {
        }
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
      var cecPath = Path.Combine(_appPath, "cec.exe");

      // Überprüf die Standardverzeichnisse
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
            {
              arguments.Add(s);
            }
      }
      catch
      {
      }

      // Wird InstallOnly gesetzt wird aus Sicherheitsgründen die Installation/Updates von Addons unterbunden.
      if (!installOnly)
        try
        {
          // Add-ons installiert sind und 
          Load3rdPartyRepositories();
        }
        catch
        {
        }

      try
      {
        // Muss der CE installiert/aktualisiert werden?
        if (File.Exists(exePath))
        {
          // führe Update vor Programmstart aus...          
          DoUpdate(true);
        }
        else
        {
          // führe Installation aus...
          if (!StartInstallation())
            // Wenn Installation fehlerhaft/abgebrochen, dann schließe Programm...
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
        var process = args == null
          ? Process.Start(exePath)
          : Process.Start(args.Any(arg => Path.GetExtension(arg)?.ToLower() == ".ceshell") ? cecPath : exePath,
            string.Join(" ", arguments));
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
      foreach (var repo in manifest.Where(repo => repo != null && repo.Length == 2))
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
        Main(AppDomain.CurrentDomain.SetupInformation.ActivationArguments?.ActivationData ?? args, installOnly,
          appPath);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
      finally
      {
        mutex.ReleaseMutex();
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

      if (update == null ||
          update.Count(x => !x.InstallationCompleted) == 0)
        return;

      if (!_muteGui)
      {
        if (askForUpdate)
          if (
            MessageBox.Show(
              "Für den CorpusExplorer steht ein Update bereit. Soll dieses jetzt installiert werden?",
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
        } while (processes.Length > 0);
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
        return lines.Select(line =>
          line.Replace("{CPU}", Environment.Is64BitProcess ? "x64" : "x86")
            .Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries));
      }
      catch
      {
        return null;
      }
    }    
  }
}