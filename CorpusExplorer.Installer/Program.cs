#region

using System;
using CorpusExplorer.Installer.Sdk;

#endregion

namespace CorpusExplorer.Installer
{
  internal static class Program
  {
    /// <summary>
    ///   Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    private static void Main(params string[] args)
    {
      CorpusExplorerBootstraper.Launch("http://www.bitcutstudios.com/products/corpusexplorer/standard.manifest", args);
    }
  }
}