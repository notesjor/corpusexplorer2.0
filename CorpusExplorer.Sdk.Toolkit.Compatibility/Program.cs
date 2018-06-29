#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Toolkit.Compatibility
{
  /// <summary>
  ///   The program.
  /// </summary>
  internal class Program
  {
    #region Methods

    /// <summary>
    ///   The main.
    /// </summary>
    /// <param name="args">
    ///   The args.
    /// </param>
    [STAThread]
    private static void Main(string[] args)
    {
      Controler.Init();

      if (!Controler.NeedConversion) return;

      //Controler.Upgrade(@"C:\Users\Jan\Documents\CorpusExplorer\Meine Korpora\CorpusExplorerNEXT\");
      //Controler.Upgrade(@"C:\Users\Jan\Documents\CorpusExplorer\Meine Korpora\Präpositionen II\");

      var form = new Form1();
      form.ShowDialog();
    }

    #endregion
  }
}