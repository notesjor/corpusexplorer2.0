using System.Threading.Tasks;
using CorpusExplorer.Terminal.WinForm.Forms.Splash.Forms;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Forms.Splash
{
  public static class Welcome
  {
#if LINUX
#else
    //The type of form to be displayed as the splash screen.
    private static WelcomeForm splashForm;
#endif

    public static void SplashClose()
    {
#if LINUX
#else
      try
      {
        splashForm.Invoke(new CloseDelegate(CloseFormInternal));
      }
      catch
      {
        // ignore
      }
#endif
    }

    public static void SplashShow()
    {
#if LINUX
#else
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
#endif
    }

    private static void CloseFormInternal()
    {
#if LINUX
#else
      splashForm.Close();
      splashForm = null;
#endif
    }

    //Delegate for cross thread call to close
    private delegate void CloseDelegate();
  }
}