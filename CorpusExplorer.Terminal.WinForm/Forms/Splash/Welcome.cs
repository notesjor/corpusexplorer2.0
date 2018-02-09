using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Terminal.WinForm.Forms.Splash.Forms;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Forms.Splash
{
  public static class Welcome
  {
    //The type of form to be displayed as the splash screen.
    private static WelcomeForm splashForm;

    private static void CloseFormInternal()
    {
      splashForm.Close();
      splashForm = null;
    }

    public static void SplashClose()
    {
      try
      {
        InMemoryErrorConsole.ActionStop();
        splashForm.Invoke(new CloseDelegate(CloseFormInternal));
      }
      catch
      {
        // ignore
      }
    }

    public static void SplashShow()
    {
      if (splashForm != null)
        return;

      InMemoryErrorConsole.ActionStart("START APPLICATION");
      
      Task.Factory.StartNew(
        () =>
        {
          splashForm = new WelcomeForm
          {
            Message = Resources.DerCorpusExplorerWirdGeladenBitteWarten
          };
          splashForm.ShowDialog();
        });
    }

    //Delegate for cross thread call to close
    private delegate void CloseDelegate();
  }
}