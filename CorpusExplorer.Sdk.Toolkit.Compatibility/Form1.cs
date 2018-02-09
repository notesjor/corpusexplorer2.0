#region

using System;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Sdk.Toolkit.Compatibility
{
  /// <summary>
  ///   The form 1.
  /// </summary>
  public partial class Form1 : RadForm
  {
    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="Form1" /> class.
    /// </summary>
    public Form1()
    {
      InitializeComponent();
    }

    #endregion

    #region Methods

    /// <summary>
    ///   The form 1_ load.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void Form1_Load(object sender, EventArgs e)
    {
      Controler.Init();
    }

    #endregion
  }
}