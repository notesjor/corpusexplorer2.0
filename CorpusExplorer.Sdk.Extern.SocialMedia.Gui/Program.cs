using System;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Forms;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui
{
  internal static class Program
  {
    /// <summary>
    ///   Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      CorpusExplorerEcosystem.Initialize();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      //CefSharpLoader.Initialize();
      Application.Run(new MainForm());
    }
  }
}