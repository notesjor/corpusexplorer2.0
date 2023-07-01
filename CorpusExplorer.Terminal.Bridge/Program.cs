using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace CorpusExplorer.Terminal.Bridge
{
  internal static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Process.Start(new ProcessStartInfo
      {
        FileName = "CorpusExplorer.exe",
        Arguments = "--bridge",
        UseShellExecute = false,
      }).WaitForExit();
    }
  }
}