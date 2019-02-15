#region

using System;
using System.IO;
using System.Text;

#endregion

namespace Bcs.IO
{
  // ReSharper disable once InconsistentNaming
  public static class FileIO
  {
    public static byte[] ReadBytes(string path)
    {
      try
      {
        byte[] res;

        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
          res = new byte[fs.Length];
          fs.Read(res, 0, res.Length);
        }

        return res;
      }
      catch
      {
        return null;
      }
    }

    public static string[] ReadLines(
      string path,
      Encoding encoding = null,
      string[] delimiters = null,
      StringSplitOptions stringSplitOptions = StringSplitOptions.None)
    {
      if (encoding == null)
        encoding = Encoding.UTF8;
      if (delimiters == null)
        delimiters = new[] {"\r\n", "\r", "\n"};

      return ReadText(path, encoding).Split(delimiters, stringSplitOptions);
    }

    public static string ReadText(string path, Encoding encoding = null)
    {
      try
      {
        if (encoding == null)
          encoding = Encoding.UTF8;

        return encoding.GetString(ReadBytes(path));
      }
      catch
      {
        return null;
      }
    }

    public static void Write(string path, string text, Encoding encoding = null)
    {
      if (encoding == null)
        encoding = Encoding.UTF8;

      Write(path, encoding.GetBytes(text));
    }

    public static void Write(string path, string[] lines, Encoding encoding = null, string separator = "\r\n")
    {
      Write(path, string.Join(separator, lines), encoding);
    }

    internal static void Write(string path, byte[] bytes)
    {
      try
      {
        if (!Directory.Exists(Path.GetDirectoryName(path)))
          Directory.CreateDirectory(Path.GetDirectoryName(path));
      }
      catch
      {
        // ignore
      }

      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        fs.Write(bytes, 0, bytes.Length);
      }
    }
  }
}