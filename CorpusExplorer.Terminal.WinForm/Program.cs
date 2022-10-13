#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Terminal.WinForm.Forms.Dashboard;
using CorpusExplorer.Terminal.WinForm.Forms.Error;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
using Telerik.WinControls;

#endregion

namespace CorpusExplorer.Terminal.WinForm
{
  /// <summary>
  ///   The program.
  /// </summary>
  internal static class Program
  {
    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      InMemoryErrorConsole.Log(e.Exception);

      var form = new ErrorConsole();
      form.ShowDialog();

      InMemoryErrorConsole.Clear();
    }

    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(params string[] args)
    {
      SetProcessDpiAwareness(_Process_DPI_Awareness.Process_System_DPI_Aware);
      RadControl.EnableRadAutoScale = false;

      ChangeLanguage(args);

      Application.EnableVisualStyles();
      try
      {
        Application.SetCompatibleTextRenderingDefault(false);
      }
      catch
      {
        // ignore
      }
      Application.ThreadException += Application_ThreadException;

      if (AppQuickMode(args))
        return;

      Welcome.SplashShow();

      try
      {
        Application.Run(new Dashboard(args));
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);

        var form = new ErrorConsole();
        form.ShowDialog();
      }

      try
      {
        InMemoryErrorConsole.Clear();
      }
      catch
      {
        // ignore
      }
    }

    private static bool AppQuickMode(string[] args)
    {
      if (args == null || args.Length == 0)
        return false;

      switch (args[0])
      {
        case "help":
        case "-h":
        case "/?":
        case "--help":
          QuickMode.DisplayHelp();
          return true;
        case "--anno":
          if (args.Length == 1)
          {
            QuickMode.Annotate(QuickMode.Initialize(), true, false);
            return true;
          }
          if (args.Length > 2)
          {
            QuickMode.Annotate(QuickMode.Initialize(), args[1], QuickMode.GetFilesHelper(args), true, false);
            return true;
          }
          return false;
        case "--conv":
          if (args.Length == 1)
          {
            QuickMode.Convert(QuickMode.Initialize(), false);
            return true;
          }

          if (args.Length > 2)
          {
            QuickMode.Convert(QuickMode.Initialize(), args[1], QuickMode.GetFilesHelper(args), false);
            return true;
          }
          return false;
        case "--reset":
        case "--sreset":
          QuickMode.SoftReset();
          return true;
        case "--hreset":
          QuickMode.HardReset();
          return true;
      }

      return false;
    }

    private static void ChangeLanguage(string[] args)
    {
      if (args == null)
        return;

      foreach (var arg in args)
      {
        if (!arg.StartsWith("--lang:"))
          continue;

        var lang = arg.Replace("--lang:", "");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
        Application.CurrentCulture = new CultureInfo(lang);
      }
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