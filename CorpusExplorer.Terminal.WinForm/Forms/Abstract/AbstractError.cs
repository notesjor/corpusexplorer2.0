#region

using System;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Abstract
{
  /// <summary>
  ///   The abstract error.
  /// </summary>
  public partial class AbstractError : AbstractDialog
  {
    /// <summary>
    ///   The _funny.
    /// </summary>
    private readonly string[] _funny =
    {
      "Ach du Schreck...",
      "Au weia...",
      "Oh Nein...",
      "Wer war das...?",
      "Autsch!",
      "Rette sich wer kann...",
      "Sowas aber auch..."
    };

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractError" /> class.
    /// </summary>
    public AbstractError(Project project) : base(project)
    {
      InitializeComponent();

      var rnd = new Random();
      lbl_funnyHeader.Text = _funny[rnd.Next(0, _funny.Length - 1)];
    }

    protected AbstractError() : this(null)
    {
    }
  }
}