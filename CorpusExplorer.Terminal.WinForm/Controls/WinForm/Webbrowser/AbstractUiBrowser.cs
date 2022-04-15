using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CorpusExplorer.Sdk.View.Html;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
  public abstract class AbstractUiBrowser : IUiBrowser
  {
    private string _path;
    public abstract Control GetControl(Size size);
    public bool AddDefaultDependency { get; set; } = true;

    public abstract void ExportImage();

    public abstract void ExportPdf();

    public abstract void Print();

    protected abstract void ShowFileCall(string path);

    public void ShowFile(string path)
    {
      _path = path;
      ShowFileCall(path);
    }

    public void ShowHtml(string html)
      => ShowFile(EasyWebBuilder
                 .Create()
                 .AddDependency(AddDefaultDependency ? "d3skeleton" : null)
                 .SetIndexByString(html)
                 .Finalize());

    public void ExportHtml()
    {
      var sfd = new SaveFileDialog { Filter = Resources.FileExtension_HTML, CheckPathExists = true };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      File.Copy(_path, sfd.FileName);
    }
  }
}