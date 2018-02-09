using System.IO;
using System.Linq;

namespace CorpusExplorer.Sdk.Helper
{
  public static class PathHelper
  {
    private static readonly char[] Chars = {'\\', '/', ':', '*', '?', '"', '<', '>', '|'};

    public static string EnsureFileName(this string filename, char replaceWith = '_')
    {
      filename = Chars.Aggregate(filename, (current, c) => current.Replace(c, replaceWith));

      if (filename.Length < 64)
        return filename;

      var orig = Path.GetFileNameWithoutExtension(filename);
      if (orig.Length > 60)
        filename = orig.Substring(0, 60) + filename.Replace(orig, "");

      return filename;
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

      return dir != null && name != null ? Path.Combine(dir, name) : string.Empty;
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
  }
}