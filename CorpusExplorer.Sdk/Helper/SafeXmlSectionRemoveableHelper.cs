using System;

namespace CorpusExplorer.Sdk.Helper
{
  // ReSharper disable once UnusedMember.Global
  public static class SafeXmlSectionRemoveableHelper
  {
    /// <summary>
    ///   Entfernt sicher einen kompletten XML-Tag aus einem Fließtext.
    /// </summary>
    /// <param name="text">Text der bereinigt werden soll.</param>
    /// <param name="tagName">Name des Tags (ohne klammern)</param>
    /// <returns>Bereinigter Text</returns>
    // ReSharper disable once UnusedMember.Global
    public static string RemoveHtmlSection(string text, string tagName)
    {
      var stag = $"<{tagName}>";
      var etag = $"</{tagName}>";
      var length = etag.Length;

      while (text.Contains(stag))
      {
        var a = text.IndexOf(stag, StringComparison.Ordinal);
        var b = text.IndexOf(etag, StringComparison.Ordinal);

        if (b > a) // Normalfall
        {
          text = text.Substring(0, a) + text.Substring(b + length);
        }
        else if (b == -1) // Wenn nur noch end-tags
        {
          text = text.Replace(stag, "");
          break;
        }
        else // Wenn doppelte end-tags (verhindert unendlich Rekursion)
        {
          text = text.Substring(0, b) + text.Substring(b + length);
        }
      }

      return text;
    }
  }
}