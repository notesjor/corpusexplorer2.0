#region

using System.Collections.Generic;
using System.ComponentModel;
using CorpusExplorer.Sdk.View.Html.Html5;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
  [ToolboxItem(true)]
  public partial class WebHtml5Visualisation : WebSimpleUrlVisualisation
  {
    private Html5Builder _html;

    public WebHtml5Visualisation()
    {
      InitializeComponent();
      _html = new Html5Builder();
    }

    public Dictionary<string, string> TemplateVars { get; set; } = new Dictionary<string, string>();

    public override void GoToMainpage()
    {
      if(_html == null)
        _html = new Html5Builder();

      _html.Execute(MainpageUrl, TemplateVars);
      MainpageUrl = _html.WebserverIndexUrl;
      base.GoToMainpage();
    }
  }
}