using System;
using System.Linq;
using System.Runtime.InteropServices;
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
      SetProcessDpiAwareness(_Process_DPI_Awareness.Process_System_DPI_Aware);

      CorpusExplorerEcosystem.Initialize();

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