#region

using System.ComponentModel;
using System.Text;
using System.Web;
using CorpusExplorer.Sdk.Ecosystem.Model;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
  [ToolboxItem(true)]
  public partial class WebGetVisualisation : WebRequestVisualisation
  {
    public WebGetVisualisation() { InitializeComponent(); }

    public override void GoToMainpage()
    {
      var stb = new StringBuilder(MainpageUrl);
      stb.Append("?");

      foreach (var parameter in Parameters)
        stb.Append(
          $"{HttpUtility.UrlEncode(parameter.Key, Configuration.Encoding)}={HttpUtility.UrlEncode(parameter.Value, Configuration.Encoding)}&");

      MainpageUrl = stb.ToString();
      base.GoToMainpage();
    }
  }
}