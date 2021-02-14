#region

using System.IO;
using System.IO.Compression;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  public static class ZipHelper
  {
    public static void Compress(string directory, string zipFile)
    {
      ZipFile.CreateFromDirectory(directory, zipFile);
    }

    public static void Uncompress(string zipFile, string destination)
    {
      var zip = ZipFile.OpenRead(zipFile);
      foreach (var entry in zip.Entries)
      {
        var output = Path.GetFullPath(Path.Combine(destination, entry.FullName));
        if (File.Exists(output))
          continue;
        var dir = Path.GetDirectoryName(output);
        if (!Directory.Exists(dir))
          Directory.CreateDirectory(dir);
        entry.ExtractToFile(output);
      }
    }
  }
}