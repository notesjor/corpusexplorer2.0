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
      byte[] res;

      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      {
        res = new byte[fs.Length];
        fs.Read(res, 0, res.Length);
      }

      return res;
    }

    public static string[] ReadLines(
      string path,
      Encoding encoding = null,
      string separator = "\r\n",
      StringSplitOptions stringSplitOptions = StringSplitOptions.None)
    {
      if (encoding == null)
        encoding = Encoding.UTF8;

      return ReadText(path, encoding).Split(new[] {separator}, stringSplitOptions);
    }

    public static string ReadText(string path, Encoding encoding = null)
    {
      if (encoding == null)
        encoding = Encoding.UTF8;

      return encoding.GetString(ReadBytes(path));
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
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        fs.Write(bytes, 0, bytes.Length);
      }
    }
  }
}