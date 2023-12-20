#region

using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;

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
      using (var zip = ZipFile.OpenRead(zipFile))
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

    public static string[] GetRelativeZipEntryPath(string zipFile)
    {
      using (var zip = ZipFile.OpenRead(zipFile))
        return zip.Entries.Select(e => e.FullName).ToArray();
    }
  }
}