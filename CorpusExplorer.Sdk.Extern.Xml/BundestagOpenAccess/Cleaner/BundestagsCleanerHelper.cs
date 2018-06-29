using System.Text;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Cleaner
{
  public static class BundestagsCleanerHelper
  {
    public static string Clean(this string text)
    {
      var stb = new StringBuilder(text);

      // Beseitigung von Layout (Inhaltsverzeichnis) z. B.: . . . . . . A 797 > . A 797
      int len;
      do
      {
        len = stb.Length;
        stb = stb.Replace(". .", ".");
      } while (stb.Length != len);

      // Beseitigung von manuell gesetzten Zeilenumbrüchen.
      stb = stb.Replace("-\r\n\r\n", "")
        .Replace("-\r\r", "")
        .Replace("-\n\n", "")
        .Replace("-\r\n", "")
        .Replace("-\r", "")
        .Replace("-\n", "");
      return stb.ToString();
    }
  }
}