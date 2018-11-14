using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CefSharp.WinForms;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui
{
  public static class CefSharpLoader
  {
    /*
    public static void Initialize()
    {
      AppDomain.CurrentDomain.AssemblyResolve += Resolver;

      var settings = new CefSettings();

      // Set BrowserSubProcessPath based on app bitness at runtime
      settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                    Environment.Is64BitProcess ? "x64" : "x86",
                                                    "CefSharp.BrowserSubprocess.exe");

      // Make sure you set performDependencyCheck false
      Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
    }

    private static Assembly Resolver(object sender, ResolveEventArgs args)
    {
      /*
      if (!args.Name.StartsWith("CefSharp"))
        return null;

      var assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
      var archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                          Environment.Is64BitProcess ? "x64" : "x86",
                                          assemblyName);

      return File.Exists(archSpecificPath)
               ? Assembly.LoadFile(archSpecificPath)
               : null;
      */
    //}
  }
}
