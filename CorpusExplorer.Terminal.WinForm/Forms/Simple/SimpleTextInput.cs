#region

using System.Drawing;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  public partial class SimpleTextInput : AbstractDialog
  {
    protected SimpleTextInput()
    {
      InitializeComponent();
    }

    public SimpleTextInput(string header, string description, Image image, string nullText)
    {
      InitializeComponent();
      Text = header;
      _headPanel1.HeadPanelTitle = header;
      _headPanel1.HeadPanelDescription = description;
      _headPanel1.HeadPanelImage = image;
      radTextBox1.NullText = nullText;
    }

    public string Result => radTextBox1.Text;
  }
}