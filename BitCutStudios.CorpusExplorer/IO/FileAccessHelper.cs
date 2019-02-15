using System;
using System.IO;
using System.Threading;

namespace Bcs.IO
{
  public static class FileAccessHelper
  {
    public static void WaitForFileAccess(string path, int timeout = 200)
    {
      SpinWait.SpinUntil(() => IsFileReady(path));
    }

    public static bool IsFileReady(string path)
    {
      try
      {
        if (!File.Exists(path)) return true;
        using (var fs = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
        }

        ;
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}