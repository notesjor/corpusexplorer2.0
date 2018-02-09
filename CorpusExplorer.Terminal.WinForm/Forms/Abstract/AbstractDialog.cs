using CorpusExplorer.Terminal.WinForm.Properties;

#region

using System;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Abstract
{
  /// <summary>
  ///   The abstract dialog.
  /// </summary>
  public partial class AbstractDialog : AbstractForm
  {
    protected AbstractDialog() : this(null) { }

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractDialog" /> class.
    /// </summary>
    public AbstractDialog(Project project) : base(project) { InitializeComponent(); }

    /// <summary>
    ///   Gets or sets a value indicating whether display abort.
    /// </summary>
    public bool DisplayAbort { get { return btn_abort.Visible; } set { btn_abort.Visible = value; } }

    public string Error { get; set; }

    /// <summary>
    ///   The btn_abort_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      OnAbortClick();
      Close();
    }

    /// <summary>
    ///   The btn_ok_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_ok_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(Error))
      {
        MessageBox.Show(
          Error,
          Resources.Dialog_ErrorHint,
          MessageBoxButtons.OK,
          MessageBoxIcon.Information);
        return;
      }

      DialogResult = DialogResult.OK;
      OnOkClick();
      Close();
    }

    /// <summary>
    ///   The button abort click.
    /// </summary>
    public event EventHandler ButtonAbortClick;

    /// <summary>
    ///   The button ok click.
    /// </summary>
    public event EventHandler ButtonOkClick;

    /// <summary>
    ///   The on abort click.
    /// </summary>
    private void OnAbortClick()
    {
      ButtonAbortClick?.Invoke(this, null);
    }

    /// <summary>
    ///   The on ok click.
    /// </summary>
    private void OnOkClick()
    {
      ButtonOkClick?.Invoke(this, null);
    }
  }
}