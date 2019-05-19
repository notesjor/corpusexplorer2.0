using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Bcs.IO;
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
        Welcome.SplashClose();

        try
        {
          var configPath = Path.Combine(Configuration.AppPath, "CorpusExplorer.exe.config");
          var patchPath = Path.Combine(Configuration.AppPath, "app.config.patch");

          if (!File.Exists(patchPath))
            return;

          File.Move(configPath, configPath + ".old");
          File.Move(patchPath, configPath);

          MessageBox.Show("Ein veralteter Grafikkartentreiber ist Grund für einen schweren Fehler im CorpusExplorer.\nAber keine Panik - so lösen Sie das Problem:\n\n1. Der CorpusExplorer wird beim nächsten Programmstart versuchen, das Problem selbstständig zu umgehen.\n2. Bitte aktualisieren Sie ihren Grafikkartentreiber.\n3. Besteht das Problem weiter, kontaktieren Sie den Entwickler.",
                          "Keine Panik!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        catch (Exception ex)
        {
          MessageBox.Show("Ein veralteter Grafikkartentreiber ist Grund für einen schweren Fehler im CorpusExplorer.\nAber keine Panik - so lösen Sie das Problem:\n1. Bitte aktualisieren Sie ihren Grafikkartentreiber.\n2. Starten Sie den CorpusExplorer erneut.\n3. Besteht das Problem weiter, kontaktieren Sie den Entwickler.",
                          "Keine Panik!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        Process.GetCurrentProcess().Kill();
      }
    }
  }
}
