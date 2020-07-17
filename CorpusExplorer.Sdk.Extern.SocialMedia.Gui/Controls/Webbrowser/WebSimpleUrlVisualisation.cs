#region

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Webbrowser;
#if LINUX
#else
using CefSharp;
using CefSharp.WinForms;
using CorpusExplorer.Sdk.View.Html.Html5;

#endif

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
  [ToolboxItem(false)]
  public partial class WebSimpleUrlVisualisation : UserControl
  {
#if LINUX
    public WebSimpleUrlVisualisation(){}

    public string MainpageUrl { get; set; }

    public void ExportHtml(){}
    public void ExportImage(){}
    public void ExportPdf(){}
    public void Print(){}
    public void GoToMainpage(){}
#else
    private ChromiumWebBrowser webBrowser1;

    public WebSimpleUrlVisualisation()
    {
      InitializeComponent();
    }

    public string MainpageUrl { get; set; }

    /*
    public void ExportHtml()
    {
      var sfd = new SaveFileDialog {Filter = Resources.FileExtension_HTML, CheckPathExists = true};
      if (sfd.ShowDialog() == DialogResult.OK)
        ExportHtml(sfd.FileName);
    }

    public void ExportHtml(string path)
    {
      InitializeBrowser();
      var dir = Path.Combine(Path.GetDirectoryName(path), "assets");
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);
      webBrowser1.Browser.SaveWebPage(path, dir, SavePageType.COMPLETE_HTML);
    }
    */

    public void ExportImage()
    {
      var sfd = new SaveFileDialog {Filter = "PNG-Bild (*.png)|*.png", CheckPathExists = true};
      if (sfd.ShowDialog() == DialogResult.OK)
        ExportImage(sfd.FileName);
    }

    public void ExportImage(string path)
    {
      InitializeBrowser();
      var bitmap = new Bitmap(webBrowser1.Width, webBrowser1.Height);
      webBrowser1.DrawToBitmap(bitmap, new Rectangle(new Point(0, 0), webBrowser1.Size));
      bitmap.Save(path, ImageFormat.Png);
    }

    public void ExportPdf()
    {
      var sfd = new SaveFileDialog {Filter = "PDF-Dokument (*.pdf)|*.pdf", CheckPathExists = true};
      if (sfd.ShowDialog() == DialogResult.OK)
        ExportPdf(sfd.FileName);
    }

    public virtual void GoToMainpage()
    {
      InitializeBrowser();

      webBrowser1.Load(MainpageUrl);
    }

    public void LoadHtml(string html)
    {
      InitializeBrowser();
      webBrowser1.Load(Html5Builder.QuickHtmlPage(html));
    }

    public void Print()
    {
      InitializeBrowser();
      webBrowser1.Print();
    }

    private void ExportPdf(string path)
    {
      InitializeBrowser();
      webBrowser1.PrintToPdfAsync(path);
    }

    private void InitializeBrowser()
    {
      if (webBrowser1 != null)
        return;

      SuspendLayout();
      webBrowser1 = StaticBrowserHandler.Get(Size);
      Controls.Add(webBrowser1);
      ResumeLayout(false);
    }
#endif
  }
}