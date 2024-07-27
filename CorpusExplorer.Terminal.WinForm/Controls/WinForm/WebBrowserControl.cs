using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class WebBrowserControl : AbstractUserControl, IUiBrowser
  {
    private string _url;
    private AbstractUiBrowser _browser = null;

    private AbstractUiBrowser Browser
    {
      get
      {
        if(_browser == null)
        {
          var useChrome = Configuration.UseChrome;
#if LINUX
      useChrome = false;
#endif

          _browser = useChrome ? (AbstractUiBrowser)new UiUseChrome() : new UiUseSystemWebbrowser();

          Controls.Add(_browser.GetControl(Size));
        }

        return _browser;
      }
    }

    public WebBrowserControl()
    {
      InitializeComponent();
    }

    public void ExportImage()
      => Browser.ExportImage();

    public void ExportPdf()
      => Browser.ExportPdf();

    public void Print()
      => Browser.Print();

    public void ShowFile(string path)
      => Browser.ShowFile(path);

    public void ShowHtml(string html)
      => Browser.ShowHtml(html);

    public void ExportHtml()
      => Browser.ExportHtml();
  }
}
