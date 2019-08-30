using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Helper
{
  public static class XamlHighDpiExceptionHelper
  {
    public static void Ensure(Action action)
    {
      try
      {
        action();
      }
      catch (System.Windows.Markup.XamlParseException)
      {
        try
        {
          var configPath = Path.Combine(Configuration.AppPath, "CorpusExplorer.exe.config");
          var patchPath = Path.Combine(Configuration.AppPath, "app.config.patch");

          if (!File.Exists(patchPath) || File.Exists(configPath + ".old"))
            return;

          File.Move(configPath, configPath + ".old");
          File.Move(patchPath, configPath);
        }
        catch
        {
          // ignore
        }
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }
  }
}
