using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using PostSharp.Patterns.Threading;

namespace CorpusExplorer.Terminal.WinForm.Forms.WebCrawler
{
  public partial class XpathBrowser : AbstractForm
  {
    private WebXpathVisualizer _xpath;

    public XpathBrowser()
    {
      InitializeComponent();
      _xpath = new WebXpathVisualizer
      {
        Size = Size,
        Location = new Point(0, 0),
        Dock = DockStyle.Fill
      };
      _xpath.XPathChanged += _xpath_XPathChanged;
      panel_webbrowser.Controls.Add(_xpath);
    }

    private void _xpath_XPathChanged(object sender, EventArgs e)
    {
      radTextBox5.Invoke((MethodInvoker)delegate { radTextBox5.Text = _xpath.XPath; });
    }

    private void radButton1_Click(object sender, EventArgs e)
    {
      _xpath.Url = radTextBox3.Text;
    }

    private void radButton2_Click(object sender, EventArgs e)
    {
      _xpath.XPath = radTextBox5.Text;
    }

    private bool _xpathChanged = true;

    private void radTextBox5_TextChanged(object sender, EventArgs e)
    {
      if (!_xpathChanged)
        return;

      _xpathChanged = false;
      radDesktopAlert1.Show();
    }
  }
}
