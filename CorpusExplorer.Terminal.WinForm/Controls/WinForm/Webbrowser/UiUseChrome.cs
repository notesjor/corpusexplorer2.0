using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.DevTools.Page;
using CefSharp.WinForms;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
  public class UiUseChrome : AbstractUiBrowser
  {
    private ChromiumWebBrowser _browser = null;

    public UiUseChrome()
    {
      StaticBrowserHandler.Initialize();
    }

    public override Control GetControl(Size size)
    {
      _browser = StaticBrowserHandler.Get(size);
      return _browser;
    }

    public override void ExportImage()
    {
      var sfd = new SaveFileDialog { Filter = Resources.FileExtension_JPEG, CheckPathExists = true };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exportTask = new Task(async () =>
      {
        using (var devToolsClient = _browser.GetDevToolsClient())
        {
          var task = devToolsClient.Page.CaptureScreenshotAsync(CaptureScreenshotFormat.Jpeg, 100, captureBeyondViewport: true);
          var res = await task;

          File.WriteAllBytes(sfd.FileName, res.Data);
        }
      });
      exportTask.Start();
      exportTask.Wait();
    }

    public override void ExportPdf()
    {
      var sfd = new SaveFileDialog { Filter = Resources.FileExtension_PDF, CheckPathExists = true };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exportTask = _browser.PrintToPdfAsync(sfd.FileName);
      exportTask.Start();
      exportTask.Wait();
    }

    public override void Print() 
      => _browser.Print();

    protected override void ShowFileCall(string path) 
      => _browser.Load(path);
  }
}
