using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
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
      SetProcessDpiAwareness(_Process_DPI_Awareness.Process_System_DPI_Aware);

      CorpusExplorerEcosystem.Initialize();

      var settings = new CefSettings();
      settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";

      Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
      
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
    
    [DllImport("shcore.dll")]
    static extern int SetProcessDpiAwareness(_Process_DPI_Awareness value);

    enum _Process_DPI_Awareness
    {
      Process_DPI_Unaware = 0,
      Process_System_DPI_Aware = 1,
      Process_Per_Monitor_DPI_Aware = 2
    }
  }
}