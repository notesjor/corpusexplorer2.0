using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Helper
{
  using System.IO;

  public static class DirectoryCopyHelper
  {
    public static void CopyRekursiv(string sourceDirName, string destDirName, bool copySubDirs = true)
    {
      var dir = new DirectoryInfo(sourceDirName);
      if (!dir.Exists)
      {
        throw new DirectoryNotFoundException("Source Directory not exsists or not found "+sourceDirName);
      }
      var dirs = dir.GetDirectories();

      if (!Directory.Exists(destDirName)) Directory.CreateDirectory(destDirName);

      var files = dir.GetFiles();
      foreach (var file in files)
      {
        file.CopyTo(Path.Combine(destDirName, file.Name), true);
      }

      if (!copySubDirs)
      {
        return;
      }

      foreach (var subdir in dirs)
      {
        CopyRekursiv(subdir.FullName, Path.Combine(destDirName, subdir.Name), copySubDirs);
      }
    }
  }
}
