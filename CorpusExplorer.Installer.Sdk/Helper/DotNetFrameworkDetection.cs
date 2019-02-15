using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CorpusExplorer.Installer.Sdk.Helper
{
  public static class DotNetFrameworkDetection
  {
    public static int[] GetLatestDotNetVersion()
    {
      var files = FindMsBuild();
      var res = new[] {0, 0, 0, 0};

      foreach (var file in files)
        try
        {
          var version = FileVersionInfo.GetVersionInfo(file);
          if (version.FileMajorPart > res[0])
          {
            res = new[] {version.FileMajorPart, version.FileMinorPart, version.FileBuildPart, version.FilePrivatePart};
            continue;
          }

          if (version.FileMajorPart < res[0])
            continue;
          if (version.FileMinorPart > res[1])
          {
            res = new[] {version.FileMajorPart, version.FileMinorPart, version.FileBuildPart, version.FilePrivatePart};
            continue;
          }

          if (version.FileMinorPart < res[1])
            continue;
          if (version.FileBuildPart > res[2])
          {
            res = new[] {version.FileMajorPart, version.FileMinorPart, version.FileBuildPart, version.FilePrivatePart};
            continue;
          }

          if (version.FileBuildPart < res[2])
            continue;
          if (version.FilePrivatePart > res[3])
            res = new[] {version.FileMajorPart, version.FileMinorPart, version.FileBuildPart, version.FilePrivatePart};
        }
        catch
        {
          // ignore
        }

      return res;
    }

    private static IEnumerable<string> FindMsBuild()
    {
      var res = new List<string>();
      try
      {
        if (Directory.Exists(@"C:\Windows\Microsoft.NET\Framework\"))
          res.AddRange(Directory.GetFiles(@"C:\Windows\Microsoft.NET\Framework\", "MSBuild.exe",
                                          SearchOption.AllDirectories));
      }
      catch
      {
        // ignore
      }

      try
      {
        if (Directory.Exists(@"C:\Windows\Microsoft.NET\Framework64"))
          res.AddRange(Directory.GetFiles(@"C:\Windows\Microsoft.NET\Framework64", "MSBuild.exe",
                                          SearchOption.AllDirectories));
      }
      catch
      {
        // ignore
      }

      return res;
    }
  }
}