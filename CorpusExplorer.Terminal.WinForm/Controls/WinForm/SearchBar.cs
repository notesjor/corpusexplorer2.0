#region

using System;
using System.ComponentModel;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class SearchBar : AbstractUserControl
  {
    public SearchBar() { InitializeComponent(); }

    public string InputText { get { return radTextBox1.Text; } set { radTextBox1.Text = value; } }

    public string NullText { get { return radTextBox1.NullText; } set { radTextBox1.NullText = value; } }

    public event EventHandler ClickSearchButton;

    private void radButton1_Click(object sender, EventArgs e)
    {
      ClickSearchButton?.Invoke(sender, e);
    }
  }
}