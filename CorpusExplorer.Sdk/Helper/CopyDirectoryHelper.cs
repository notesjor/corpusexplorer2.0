using CorpusExplorer.Sdk.Properties;

#region

using System.IO;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  public class CopyDirectoryHelper
  {
    public static void Copy(string sourceDirName, string destDirName, bool copySubDirs)
    {
      // Get the subdirectories for the specified directory.
      var dir = new DirectoryInfo(sourceDirName);
      var dirs = dir.GetDirectories();

      if (!dir.Exists)
        throw new DirectoryNotFoundException(Resources.DirectoryNotFound + sourceDirName);

      // If the destination directory doesn't exist, create it.
      if (!Directory.Exists(destDirName))
        Directory.CreateDirectory(destDirName);

      // Get the files in the directory and copy them to the new location.
      foreach (var file in dir.GetFiles())
      {
        var temppath = Path.Combine(destDirName, file.Name);
        file.CopyTo(temppath, false);
      }

      // If copying subdirectories, copy them and their contents to new location.
      if (!copySubDirs)
        return;

      foreach (var subdir in dirs)
      {
        var temppath = Path.Combine(destDirName, subdir.Name);
        Copy(subdir.FullName, temppath, true);
      }
    }
  }
}