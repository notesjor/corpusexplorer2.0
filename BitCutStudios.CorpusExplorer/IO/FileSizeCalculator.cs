#region

using System;
using System.IO;

#endregion

namespace Bcs.IO
{
  // ReSharper disable once UnusedMember.Global
  public static class FileSizeCalculator
  {
    /// <summary>
    ///   String der die Größe der Datei lesbar für den Nutzer angiebt
    /// </summary>
    /// <param name="file">Datei</param>
    /// <returns>
    ///   SizeString
    /// </returns>
    // ReSharper disable once UnusedMember.Global
    public static string GetSizeString(string file)
    {
      return GetSizeString(GetFileSize(file));
    }

    /// <summary>
    ///   Gibt die Dateigröße zurück.
    /// </summary>
    /// <param name="file">Datei</param>
    /// <returns>
    ///   Dateigröße
    /// </returns>
    private static long GetFileSize(string file)
    {
      return new FileInfo(file).Length;
    }

    /// <summary>
    ///   Wandelt den Long-Wert der die Größe der Datei angiebt in eine für den
    ///   Nutzer lesbare Version um
    /// </summary>
    /// <param name="size">Dateigröße (systembedingt als long)</param>
    /// <returns>
    ///   SizeString
    /// </returns>
    private static string GetSizeString(long size)
    {
      string[] suffix = {"B", "KB", "MB", "GB", "TB", "PB", "EB"};

      var i = 0;
      double calc = size;
      for (; i < suffix.Length; i++)
      {
        if (calc < 1024)
          break;
        calc /= 1024;
      }

      return $"{Math.Round(calc, 2):00.00} {suffix[i]}";
    }
  }
}