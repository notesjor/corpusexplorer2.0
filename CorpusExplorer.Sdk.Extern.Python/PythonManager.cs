#region

using System;
using System.Diagnostics;
using CorpusExplorer.Sdk.Ecosystem.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Python
{
  public static class PythonManager
  {
    private static string _path;

    public static string Path
    {
      get
      {
        if (_path == null)
          _path = Configuration.GetDependencyPath("Python/python.exe");

        return _path;
      }
    }

    public static void InstallPackage(string package)
    {
      UpgradeInstallation();
      RunPythonCommand($"-m pip install {package}");
    }

    public static bool RunPythonCommand(string command)
    {
      try
      {
        var info = new ProcessStartInfo
        {
          FileName = Path,
          Arguments = command,
          CreateNoWindow = true,
          WindowStyle = ProcessWindowStyle.Hidden,
          UseShellExecute = true
        };

        Process.Start(info)?.WaitForExit();

        return true;
      }
      catch
      {
        return false;
      }
    }

    public static string RunPythonCommandPipe(string command)
    {
      try
      {
        var info = new ProcessStartInfo
        {
          FileName = Path,
          Arguments = command,
          CreateNoWindow = true,
          WindowStyle = ProcessWindowStyle.Hidden,
          UseShellExecute = false,
          RedirectStandardOutput = true
        };

        var process = Process.Start(info);
        if (process == null)
          return null;

        var res = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        return res;
      }
      catch
      {
        return null;
      }
    }

    public static void UpgradeInstallation()
    {
      RunPythonCommand("-m pip install pip --upgrade");
      var lines = RunPythonCommandPipe("-m pip list --outdated")
      ?.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
      if (lines == null || lines.Length < 3 || !lines[0].StartsWith("Package") || !lines[1].StartsWith("--"))
        return;

      for (var i = 2; i < lines.Length; i++)
      {
        var split = lines[i].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
        if (split.Length != 4)
          continue;

        RunPythonCommand($"-m pip install {split[0]} --upgrade");
      }
    }
  }
}