using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class WebBrowserControl : AbstractUserControl, IUiBrowser
  {
    private string _url;
    private AbstractUiBrowser _browser;

    public WebBrowserControl()
    {
      InitializeComponent();

      var useChrome = Configuration.UseChrome;
#if LINUX
      useChrome = false;
#endif

      _browser = useChrome ? (AbstractUiBrowser)new UiUseChrome() : new UiUseSystemWebbrowser();

      Controls.Add(_browser.GetControl(Size));
    }

    public void ExportImage()
      => _browser.ExportImage();

    public void ExportPdf()
      => _browser.ExportPdf();

    public void Print()
      => _browser.Print();

    public void ShowFile(string path)
      => _browser.ShowFile(path);

    public void ShowHtml(string html)
      => _browser.ShowHtml(html);

    public void ExportHtml()
      => _browser.ExportHtml();
  }
}
