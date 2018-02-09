using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.CloneDetection
{
  public partial class CloneDetectionAlgorithm : AbstractDialog
  {
    public CloneDetectionAlgorithm() { InitializeComponent(); }

    public bool UseSpeedDetection { get { return radRadioButton1.CheckState == CheckState.Checked; } }
  }
}