using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
#if LINUX
#else
using CefSharp;
using CefSharp.WinForms;
#endif
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
#if LINUX
#else
  public static class StaticBrowserHandler
  {
    private static readonly List<ChromiumWebBrowser> _browser = new List<ChromiumWebBrowser>();
    private static bool _initialized;

    public static void Clear()
    {
      foreach (var browser in _browser)
        browser.Dispose();
      _browser.Clear();
      Cef.Shutdown();
    }

    public static ChromiumWebBrowser Get(Size size)
    {
      Initialize();
      var res = new ChromiumWebBrowser
      {
        Dock = DockStyle.Fill,
        Size = size,
        Location = new Point(0, 0),
        Name = $"webBrowser{_browser.Count + 1}",
        TabIndex = 0,
        /*BrowserSettings = new BrowserSettings
        {
          // WebSecurity = CefState.Disabled,
          //FileAccessFromFileUrls = CefState.Enabled,
          //UniversalAccessFromFileUrls = CefState.Enabled, 
          
        }*/
      };
      _browser.Add(res);
      return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Initialize()
    {
      if (_initialized)
        return;

      var settings = new CefSettings
      {
        BrowserSubprocessPath = Path.Combine(Configuration.AppPath, "CefSharp.BrowserSubprocess.exe"),
      };
      settings.CefCommandLineArgs.Add("enable-media-stream", "1");

      //CefSharpSettings.LegacyJavascriptBindingEnabled = true;
      CefSharpSettings.SubprocessExitIfParentProcessClosed = true;

      Cef.Initialize(settings, false, browserProcessHandler: null);

      _initialized = true;
    }
  }
#endif
}