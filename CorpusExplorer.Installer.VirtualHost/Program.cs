using System;
using System.IO;
using System.Linq;
using System.Threading;
using CorpusExplorer.Installer.Sdk;
using CorpusExplorer.Sdk.Diagnostic;

namespace CorpusExplorer.Installer.VirtualHost
{
  internal class Program
  {
    [STAThread]
    private static void Main()
    {
      var desktop = Directory.Exists("C:/Users/Public/Desktop")
                      ? "C:/Users/Public/Desktop"
                      : "C:/Users/Public/Public Desktop";
      var workdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "CorpusExplorer");

      Console.Write($"CorpusExplorer v2.x Install/Update - {workdir}...");
      CorpusExplorerBootstraper.InstallOnly(
        "http://www.bitcutstudios.com/products/corpusexplorer/standard.manifest",
        workdir);
      Console.WriteLine("ok!");

      Console.WriteLine(
        $"Add shortcut {Path.Combine(workdir, "CorpusExplorer.exe")} > {Path.Combine(desktop, "CorpusExplorer.lnk")}");
      Shortcut.Create(Path.Combine(workdir, "CorpusExplorer.exe"), "", desktop, "CorpusExplorer", workdir);

      if (InMemoryErrorConsole.Errors.Any())
      {
        Console.WriteLine($"Install/Update-script has {InMemoryErrorConsole.Errors.Count()} error(s)");
        foreach (var error in InMemoryErrorConsole.Errors)
        {
          Console.WriteLine("-----");
          Console.WriteLine(error.Value.Message);
          Console.WriteLine(error.Value.StackTrace);
        }
        InMemoryErrorConsole.Save("error.log");
        Console.WriteLine("All errors stored in 'error.log'");
        Console.WriteLine("Press ENTER to close this script");
        Console.ReadLine();
        return;
      }

      Console.WriteLine("Install/Update-script successful! Process will be terminated in 15 seconds...");
      Thread.Sleep(15000);
    }
  }
}