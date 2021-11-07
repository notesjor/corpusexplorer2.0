#region

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using CefSharp.DevTools.Page;
using CorpusExplorer.Sdk.View.Html.Html5;
using System.Threading.Tasks;
#if LINUX
#else
using CefSharp;
using CefSharp.WinForms;
#endif
using CorpusExplorer.Terminal.WinForm.Properties;

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
      webBrowser1 = new ChromiumWebBrowser { Size = Size, Dock = DockStyle.Fill };

      Controls.Add(webBrowser1);
    }

    public string MainpageUrl { get; set; }

    public void ExportImage()
    {
      var sfd = new SaveFileDialog { Filter = Resources.FileExtension_JPEG, CheckPathExists = true };
      if (sfd.ShowDialog() == DialogResult.OK)
        ExportImage(sfd.FileName);
    }

    private Task _exportImageTask;

    public void ExportImage(string path)
    {
      _exportImageTask = new Task(async () =>
      {
        using (var devToolsClient = webBrowser1.GetDevToolsClient())
        {
          var task = devToolsClient.Page.CaptureScreenshotAsync(CaptureScreenshotFormat.Jpeg, 100, captureBeyondViewport: true);
          var res = await task;

          File.WriteAllBytes(path, res.Data);
        }
      });
      _exportImageTask.Start();
    }

    public void ExportPdf()
    {
      var sfd = new SaveFileDialog { Filter = Resources.FileExtension_PDF, CheckPathExists = true };
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