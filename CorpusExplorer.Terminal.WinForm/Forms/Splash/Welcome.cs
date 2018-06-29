using System.Threading.Tasks;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Terminal.WinForm.Forms.Splash.Forms;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Forms.Splash
{
  public static class Welcome
  {
    //The type of form to be displayed as the splash screen.
    private static WelcomeForm splashForm;

    public static void SplashClose()
    {
      try
      {
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

    private static void CloseFormInternal()
    {
      splashForm.Close();
      splashForm = null;
    }

    //Delegate for cross thread call to close
    private delegate void CloseDelegate();
  }
}