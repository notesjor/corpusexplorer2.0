namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser
{
  public interface IUiBrowser
  {
    void ExportImage();
    void ExportPdf();
    void Print();
    void ShowFile(string path);
    void ShowHtml(string html);
    void ExportHtml();
  }
}