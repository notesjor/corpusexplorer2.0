using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.CloneDetection
{
  public partial class CloneDetectionAlgorithm : AbstractDialog
  {
    public CloneDetectionAlgorithm()
    {
      InitializeComponent();
    }

    public int SelectedOption => radRadioButton1.IsChecked ? 1 : radRadioButton2.IsChecked ? 2 : 3;
  }
}