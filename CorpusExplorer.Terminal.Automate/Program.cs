using System;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem;

namespace CorpusExplorer.Terminal.Automate
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}