using System.Collections.Generic;
using System.IO;

namespace CorpusExplorer.Sdk.Helper
{
  public static class PathHelper
  {
    private static char[] Chars;

    public static string EnsureFileName(this string path, char replaceWith = '_')
    {
      InitCharArray();
      var res = string.Join(replaceWith.ToString(), path.Split(Chars));
      if (res.Length > 4 && res[1] == replaceWith)
        res = $"{res[0]}:{res.Substring(2)}";
      return res;
    }

    public static string ForceFileExtension(this string filename, string extension)
    {
      if (extension.StartsWith("*"))
        extension = extension.Substring(1);
      if (extension.StartsWith("."))
        extension = extension.Substring(1);

      if (string.IsNullOrEmpty(filename))
        return "default." + extension;

      var path = Path.GetDirectoryName(filename) ?? "";
      filename = Path.GetFileNameWithoutExtension(filename);
      return Path.Combine(path, $"{filename}.{extension}");
    }

    public static string ForceFileToDirectory(this string filename)
    {
      var name = Path.GetFileNameWithoutExtension(filename);
      var dir = Path.GetDirectoryName(filename);
      if (File.Exists(filename))
        File.Delete(filename);

      return dir != null ? Path.Combine(dir, name) : string.Empty;
    }

    public static bool IsDirectory(this string path)
    {
      try
      {
        return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
      }
      catch
      {
        return false;
      }
    }

    public static bool IsFile(this string path)
    {
      try
      {
        return !IsDirectory(path);
      }
      catch
      {
        return false;
      }
    }

    private static void InitCharArray()
    {
      if (Chars != null)
        return;

      var list = new List<char>(Path.GetInvalidFileNameChars());
      list.Remove('/');
      list.Remove('\\');
      Chars = list.ToArray();
    }
  }
}