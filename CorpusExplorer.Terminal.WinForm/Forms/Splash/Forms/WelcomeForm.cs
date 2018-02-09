#region

using System.IO;
using System.Reflection;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using Telerik.WinControls;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Splash.Forms
{
  /// <summary>
  ///   Class <see cref="WelcomeForm" />
  /// </summary>
  public partial class WelcomeForm : AbstractForm
  {
    /// <summary>
    ///   Prevents a default instance of the <see cref="WelcomeForm" /> class from being created.
    /// </summary>
    public WelcomeForm()
      : base(null)
    {
      InitializeComponent();
      Load += (sender, args) =>
      {
        FormElement.TitleBar.IconPrimitive.Visibility = ElementVisibility.Collapsed;
        FormElement.TitleBar.IconPrimitive.Image = null;
        lbl_version.Text =
          $"({File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToString("2.yyyy.MM.dd")})";
        radWaitingBar1.StartWaiting();
      };
    }

    public string Message { set { radLabel1.Text = value; } }
  }
}