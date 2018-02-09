using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;

namespace CorpusExplorer.Terminal.WinForm.Forms.Interfaces
{
  public interface IMainForm
  {
    AbstractView CurrentView { get; set; }
  }
}