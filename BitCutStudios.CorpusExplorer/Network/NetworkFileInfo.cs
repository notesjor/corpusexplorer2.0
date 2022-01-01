#region

using System.Net;

#endregion

namespace Bcs.Network
{
  public static class NetworkFileInfo
  {
    public static long GetFileSize(string url)
    {
      try
      {
        var req = WebRequest.Create(url);
        req.Method = "HEAD";
        using (var resp = req.GetResponse())
          if (long.TryParse(resp.Headers.Get("Content-Length"), out var ContentLength))
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