using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui
{
  static class Program
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      //CefSharpLoader.Initialize();
      //Application.Run(new Form1());
    }
  }
}
