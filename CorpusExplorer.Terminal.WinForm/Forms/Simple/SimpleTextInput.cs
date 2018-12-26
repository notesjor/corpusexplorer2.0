#region

using System.Drawing;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  public partial class SimpleTextInput : AbstractDialog
  {
    public SimpleTextInput(string header, string description, Image image, string nullText)
    {
      InitializeComponent();
      Text = header;
      ihdPanel1.IHDHeader = header;
      ihdPanel1.IHDDescription = description;
      ihdPanel1.IHDImage = image;
      radTextBox1.NullText = nullText;
    }

    public string Result => radTextBox1.Text;
  }
}