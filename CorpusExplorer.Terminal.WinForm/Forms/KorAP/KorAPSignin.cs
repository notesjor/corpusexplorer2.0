using CefSharp;
using CefSharp.WinForms;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace CorpusExplorer.Terminal.WinForm.Forms.KorAP
{
  public partial class KorAPSignin : AbstractForm
  {
    private readonly ChromiumWebBrowser _browser;
    private string _state;

    public string State => _state;

    public KorAPSignin()
    {
      InitializeComponent();

      _browser = StaticBrowserHandler.Get(Size);

      DialogResult = DialogResult.Cancel;

      webPanel.Controls.Add(_browser);
    }

    private void KorAPSignin_Load(object sender, EventArgs e)
    {
      string url;
      using (var wc = new WebClient())
        url = wc.DownloadString("https://api.corpusexplorer.de/oauth2/new");

      _browser.LoadUrl(url);
      _state = new Uri(url).Query.Split('&').FirstOrDefault(x => x.StartsWith("state="));
      if (_state == null)
        Close();

      _browser.AddressChanged += Browser_AddressChanged;
    }

    private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
    {
      if (!e.Address.Contains("https://api.corpusexplorer.de/oauth2/korap"))
        return;

      if (this.InvokeRequired)
      {
        DialogResult = DialogResult.OK;
        try
        {
          this.Close();
        }
        catch
        {
          // ignore
        }
      }
    }
  }
}
