using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bcs.IO;
using CefSharp;
using CefSharp.WinForms;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using HtmlAgilityPack;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
  public partial class WebXpathVisualizer : UserControl
  {
    private HtmlAgilityPack.HtmlDocument _documentOriginal;
    private HtmlAgilityPack.HtmlDocument _documentWork;
    private ChromiumWebBrowser _browser;
    private string _url;
    private string _xPath;
    private BoundObject _data;
    private TemporaryFile _file;

    public WebXpathVisualizer()
    {
      InitializeComponent();
      Load += (sender, args) => InitializeBrowser();
      _file = new TemporaryFile(Configuration.TempPath, ".html");
      Disposed += WebXpathVisualizer_Disposed;
    }

    private void WebXpathVisualizer_Disposed(object sender, EventArgs e)
    {
      _file.Dispose();
    }

    public string Url
    {
      get => _url;
      set
      {
        _url = value;
        _documentOriginal = new HtmlAgilityPack.HtmlDocument();

        using (var wc = new WebClient { Encoding = Configuration.Encoding })
          _documentOriginal.LoadHtml(wc.DownloadString(_url));

        // Bereinige
        var links = _documentOriginal.DocumentNode.SelectNodes("//a");
        foreach (var link in links)
        {
          var href = link.GetAttributeValue("href", "");
          link.SetAttributeValue("href", "javascript:void(0)");
          link.SetAttributeValue("link", href);
        }

        var ts = _documentOriginal.DocumentNode.SelectNodes("/html/body//*");
        foreach (var t in ts)
        {
          // scripte von der Bridge ausnehmen.
          if (t.Name == "script")
            continue;
          // Setze Bridge
          t.SetAttributeValue("onclick", $"ce.call('{ t.XPath.Replace("/", "-") }')");
        }

        FileIO.Write(_file.Path, _documentOriginal.DocumentNode.OuterHtml);

        try
        {
          _browser.Load(_file.Path);
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }
      }
    }

    private bool _lock;
    private DateTime _lockTimestamp = DateTime.Now;

    public string XPath
    {
      get => _xPath;
      set
      {
        if (DateTime.Now < _lockTimestamp)
          return;

        if (_lock)
          return;
        _lock = true;

        try
        {
          _xPath = value;
          if (string.IsNullOrEmpty(_xPath))
            return;

          // Klone
          _documentWork = new HtmlAgilityPack.HtmlDocument();
          _documentWork.LoadHtml(_documentOriginal.DocumentNode.OuterHtml);

          SelectedNodesByXPath = _documentWork.DocumentNode.SelectNodes(_xPath);
          if (SelectedNodesByXPath == null)
            return;

          foreach (var node in SelectedNodesByXPath)
          {
            node.SetAttributeValue("style", "border:5px dotted #0000ff;");
          }

          FileIO.Write(_file.Path, _documentWork.DocumentNode.OuterHtml);

          try
          {
            _browser.Load(_file.Path);
          }
          catch (Exception ex)
          {
            InMemoryErrorConsole.Log(ex);
          }

          XPathChanged?.Invoke(null, null);
        }
        catch
        {
          // ignore
        }
        finally
        {
          _lock = false;
          _lockTimestamp = DateTime.Now.AddSeconds(2);
        }
      }
    }

    public HtmlNodeCollection SelectedNodesByXPath { get; set; }

    public event EventHandler XPathChanged;

    private void InitializeBrowser()
    {
      if (_browser != null)
        return;

      BoundObject.XPathChanged += (s, e) => XPath = (string)s;

      _browser = StaticBrowserHandler.Get(Size);
      // _browser.LoadingStateChanged += _browser_LoadingStateChanged;
      try
      {
        _browser.RegisterAsyncJsObject("ce", new BoundObject(), BindingOptions.DefaultBinder);
      }
      catch (Exception ex)
      {
        var t = ex.Message;
      }

      Controls.Add(_browser);
      ResumeLayout(false);
    }
    
    public class BoundObject
    {
      public static event EventHandler XPathChanged;

      //We expect an exception here, so tell VS to ignore
      [DebuggerHidden]
      public void Call(string xpath)
      {
        if (string.IsNullOrEmpty(xpath))
          return;
        XPathChanged(xpath.Replace("-", "/"), null);
      }
    }
  }
}
