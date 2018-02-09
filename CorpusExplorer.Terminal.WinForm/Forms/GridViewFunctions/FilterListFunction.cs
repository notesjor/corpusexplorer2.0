using System;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.GridViewFunctions
{
  public partial class FilterListFunction : AbstractDialog
  {
    public FilterListFunction() { InitializeComponent(); }

    public string[] Result { get; set; }

    public bool ResultSelectAll { get; set; }

    private void FilterListFunction_ButtonOkClick(object sender, EventArgs e)
    {
      Result = radTextBox1.Lines;
      ResultSelectAll = drop_case.SelectedIndex == 0;
    }

    private void FilterListFunction_Load(object sender, EventArgs e) { drop_case.SelectedIndex = 0; }
  }
}