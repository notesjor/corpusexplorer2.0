#region

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Bcs.Crawler.Helper
{
  public static class CrawlerDictionaryExtension
  {
    public static string ComputeHash(this Dictionary<string, string> document)
    {
      string hash;
      var bytes = GetBytes(document);

      using (var md5 = MD5.Create())
      {
        hash = Convert.ToBase64String(md5.ComputeHash(bytes));
      }

      hash += "|";

      using (var sha1 = SHA1.Create())
      {
        hash += Convert.ToBase64String(sha1.ComputeHash(bytes));
      }

      return hash;
    }

    private static byte[] GetBytes(Dictionary<string, string> document)
    {
      var stb = new StringBuilder();
      foreach (var entry in document)
        stb.AppendFormat("{0}={1};", entry.Key, entry.Value);
      return Encoding.UTF8.GetBytes(stb.ToString());
    }
  }
}