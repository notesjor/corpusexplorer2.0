#region

using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Terminal.WinForm.Forms.Dashboard;
using CorpusExplorer.Terminal.WinForm.Forms.Error;
using CorpusExplorer.Terminal.WinForm.Forms.Insight;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;

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
      if (InMemoryErrorConsole.ShowErrorConsoleOnAppCrash)
      {
        var form = new ErrorConsole();
        form.ShowDialog();
      }

      InMemoryErrorConsole.Clear();
    }

    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(params string[] args)
    {
      AppDomain.CurrentDomain.AssemblyResolve += Resolver;
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
      Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
      Application.CurrentCulture = new CultureInfo("de-DE");
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.ThreadException += Application_ThreadException;

      try
      {
        if (InsightController.AskForPermission)
        {
          var insightForm = new ApplicationInsight();
          insightForm.ShowDialog();
        }
      }
      catch
      {
        // ignore
      }

      Welcome.SplashShow();

      try
      {
        Application.Run(new Dashboard(args));
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        if (InMemoryErrorConsole.ShowErrorConsoleOnAppCrash)
        {
          var form = new ErrorConsole();
          form.ShowDialog();
        }
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

    // Will attempt to load missing assembly from either x86 or x64 subdir
    private static Assembly Resolver(object sender, ResolveEventArgs args)
    {
      if (!args.Name.StartsWith("CefSharp"))
        return null;

      var assemblyName = args.Name.Split(new[] {','}, 2)[0] + ".dll";
      var archSpecificPath = Path.Combine(Configuration.AppPath,
        Environment.Is64BitProcess ? "x64" : "x86",
        assemblyName);

      return File.Exists(archSpecificPath)
        ? Assembly.LoadFile(archSpecificPath)
        : null;
    }
  }
}