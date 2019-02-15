using System.ComponentModel;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
  [ToolboxItem(true)]
  public partial class WebHtml5LaboratoryVisualisation : WebSimpleUrlVisualisation
  {
#if LINUX
#else
    public WebHtml5LaboratoryVisualisation()
    {
      InitializeComponent();
    }
#endif
  }
}