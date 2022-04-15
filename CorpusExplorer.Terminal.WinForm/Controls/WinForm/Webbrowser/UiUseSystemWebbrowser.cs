using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
  public class UiUseSystemWebbrowser : AbstractUiBrowser
  {
    private readonly UseSystemWebbrowser _fake;

    public UiUseSystemWebbrowser()
    {
      _fake = new UseSystemWebbrowser { Dock = DockStyle.Fill };
    }

    public override Control GetControl(Size size)
    {
      _fake.Size = size;
      return _fake;
    }

    public override void ExportImage()
    {
      ErrorMessage();
    }

    public override void ExportPdf()
    {
      ErrorMessage();
    }

    public override void Print()
    {
      ErrorMessage();
    }

    private void ErrorMessage()
    {
      MessageBox.Show("Bitte nutzen Sie die Export-Funktion des systemeigenen Web-Browsers.");
    }

    protected override void ShowFileCall(string path)
    {
      Process.Start(path);
    }
  }
}