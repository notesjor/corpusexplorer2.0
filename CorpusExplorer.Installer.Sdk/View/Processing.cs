#region

using System;
using System.Threading;
using System.Windows.Forms;
using CorpusExplorer.Installer.Sdk.Properties;

#endregion

namespace CorpusExplorer.Installer.Sdk.View
{
  internal sealed partial class Processing : Form
  {
    /// <summary>
    ///   The locker.
    /// </summary>
    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    private static object _locker = new object();

    /// <summary>
    ///   The _splash form.
    /// </summary>
    private static Processing _splashForm;

    /// <summary>
    ///   The _splash thread.
    /// </summary>
    private static Thread _splashThread;

    /// <summary>
    ///   The wait please.
    /// </summary>
    private static bool _waitPlease = true;

    private Processing()
    {
      InitializeComponent();
      DialogResult = DialogResult.None;
    }

    /// <summary>
    ///   Gets or sets the message.
    /// </summary>
    private string Message
    {
      set
      {
        if (string.IsNullOrEmpty(value))
          value = Resources.PleaseWait;

        label3.Text = value;
      }
    }

    /// <summary>
    ///   The splash close.
    /// </summary>
    /// <param name="message">
    ///   The message.
    /// </param>
    /// <param name="itWasrinvoked">
    ///   The it wasrinvoked.
    /// </param>
    internal static void SplashClose(string message, bool itWasrinvoked = false)
    {
      var launched = false;
      while (!launched &&
             !itWasrinvoked)
        lock (_locker)
        {
          if (!_waitPlease)
            launched = true;
        }

      if (_splashForm == null ||
          _splashThread == null)
        return;

      if (_splashForm.InvokeRequired)
      {
        SplashHandler handle = SplashClose;
        _splashForm.Invoke(handle, message, true);
        return;
      }

      if (!string.IsNullOrEmpty(message))
        _splashForm.Message = message;

      _splashForm.Close();
      _splashForm = null;
      _splashThread = null;
    }

    /// <summary>
    ///   The splash message.
    /// </summary>
    /// <param name="message">
    ///   The message.
    /// </param>
    /// <param name="itWasrinvoked">
    ///   The it wasrinvoked.
    /// </param>
    internal static void SplashMessage(string message, bool itWasrinvoked = false)
    {
      var launched = false;
      while (!launched &&
             !itWasrinvoked)
        lock (_locker)
        {
          if (!_waitPlease)
            launched = true;
        }

      if (_splashForm == null ||
          _splashThread == null)
        return;

      if (_splashForm.InvokeRequired)
      {
        SplashHandler handle = SplashMessage;
        _splashForm.Invoke(handle, message, true);
        return;
      }

      _splashForm.Message = message;
    }

    /// <summary>
    ///   The splash show.
    /// </summary>
    internal static void SplashShow()
    {
      if (_splashForm != null)
        return;

      _splashThread = new Thread(ShowSplashThreadCall) {IsBackground = true};
      _splashThread.SetApartmentState(ApartmentState.STA);
      _splashThread.Start();
    }

    private void Processing_Load(object sender, EventArgs e)
    {
      timer1.Start();
    }

    /// <summary>
    ///   The show splash thread call.
    /// </summary>
    private static void ShowSplashThreadCall()
    {
      if (_splashForm == null)
        _splashForm = new Processing();

      _splashForm.TopMost = true;
      _splashForm.Show();

      lock (_locker)
      {
        _waitPlease = false;
      }

      Application.Run(_splashForm);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      var value = progressBar1.Value + 1;
      if (value > progressBar1.Maximum)
        value = progressBar1.Minimum;
      progressBar1.Value = value;
    }

    /// <summary>
    ///   The splash handler.
    /// </summary>
    /// <param name="message">
    ///   The message.
    /// </param>
    /// <param name="itWasRinvoked">
    ///   The it was rinvoked.
    /// </param>
    private delegate void SplashHandler(string message, bool itWasRinvoked);
  }
}