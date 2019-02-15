using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcs.Network
{
  public static class NetworkFileInfo
  {
    public static long GetFileSize(string url)
    {
      try
      {
        var req = System.Net.WebRequest.Create(url);
        req.Method = "HEAD";
        using (var resp = req.GetResponse())
          if (long.TryParse(resp.Headers.Get("Content-Length"), out long ContentLength))
            return ContentLength;
      }
      catch
      {
        // ignore
      }

      return -1;
    }
  }
}
