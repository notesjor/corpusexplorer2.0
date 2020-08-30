using System;
using System.Drawing;

namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  public partial class SimpleTextInputValidation : SimpleTextInput
  {
    private Func<string, string> _validation;

    protected SimpleTextInputValidation()
    {
      InitializeComponent();
    }

    public SimpleTextInputValidation(string header, string description, Image image, string nullText, Func<string, string> validation) : base(header, description, image, nullText)
    {
      InitializeComponent();
      _validation = validation;
      radTextBox1_TextChanged(null,null);
    }

    private void radTextBox1_TextChanged(object sender, EventArgs e) 
      => warnBox1.Display(_validation(radTextBox1.Text));
  }
}
