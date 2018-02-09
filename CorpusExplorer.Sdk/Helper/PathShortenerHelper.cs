using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Helper
{
  public static class PathShortenerHelper
  {
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern int GetShortPathName(
      [MarshalAs(UnmanagedType.LPTStr)]
      string path,
      [MarshalAs(UnmanagedType.LPTStr)]
      StringBuilder shortPath,
      int shortPathLength
    );

    public static string ShortPath(this string path)
    {
      var res = new StringBuilder(255);
      GetShortPathName(path, res, res.Capacity);
      return res.ToString();
    }
  }
}
