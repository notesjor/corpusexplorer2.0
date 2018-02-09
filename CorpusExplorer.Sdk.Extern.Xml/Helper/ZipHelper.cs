#region

using ICSharpCode.SharpZipLib.Zip;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Helper
{
  internal static class ZipHelper
  {
    public static void Compress(string directory, string zipFile)
    {
      var zip = new FastZip();
      zip.CreateZip(zipFile, directory, true, null);
    }

    public static void Uncompress(string zipFile, string destination)
    {
      var zip = new FastZip();
      zip.ExtractZip(zipFile, destination, null);
    }
  }
}