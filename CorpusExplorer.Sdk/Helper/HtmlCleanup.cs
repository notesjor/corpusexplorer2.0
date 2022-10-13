#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  /// <summary>
  ///   Class <see cref="HtmlCleanup" />
  /// </summary>
  public class HtmlCleanup
  {
    /// <summary>
    ///   The <see cref="HtmlCleanup._criticals" />
    /// </summary>
    private readonly Dictionary<string, string> _criticals = new Dictionary<string, string>();

    /// <summary>
    ///   Initializes a new instance of the <see cref="HtmlCleanup" /> class.
    /// </summary>
    public HtmlCleanup()
    {
      _criticals.Add("ß", "&szlig;");
      _criticals.Add("¡", "&iexcl;");
      _criticals.Add("¢", "&cent;");
      _criticals.Add("£", "&pound;");
      _criticals.Add("¤", "&curren;");
      _criticals.Add("¥", "&yen;");
      _criticals.Add("¦", "&brvbar;");
      _criticals.Add("§", "&sect;");
      _criticals.Add("¨", "&uml;");
      _criticals.Add("©", "&copy;");
      _criticals.Add("ª", "&ordf;");
      _criticals.Add("«", "&laquo;");
      _criticals.Add("¬", "&not;");
      _criticals.Add("®", "&reg;");
      _criticals.Add("¯", "&macr;");
      _criticals.Add("°", "&deg;");
      _criticals.Add("±", "&plusmn;");
      _criticals.Add("²", "&sup2;");
      _criticals.Add("³", "&sup3;");
      _criticals.Add("´", "&acute;");
      _criticals.Add("µ", "&micro;");
      _criticals.Add("¶", "&para;");
      _criticals.Add("·", "&middot;");
      _criticals.Add("¸", "&cedil;");
      _criticals.Add("¹", "&sup1;");
      _criticals.Add("º", "&ordm;");
      _criticals.Add("»", "&raquo;");
      _criticals.Add("¼", "&frac14;");
      _criticals.Add("½", "&frac12;");
      _criticals.Add("¾", "&frac34;");
      _criticals.Add("¿", "&iquest;");
      _criticals.Add("À", "&Agrave;");
      _criticals.Add("Á", "&Aacute;");
      _criticals.Add("Â", "&Acirc;");
      _criticals.Add("Ã", "&Atilde;");
      _criticals.Add("Ä", "&Auml;");
      _criticals.Add("Å", "&Aring;");
      _criticals.Add("Æ", "&AElig;");
      _criticals.Add("Ç", "&Ccedil;");
      _criticals.Add("È", "&Egrave;");
      _criticals.Add("É", "&Eacute;");
      _criticals.Add("Ê", "&Ecirc;");
      _criticals.Add("Ë", "&Euml;");
      _criticals.Add("Ì", "&Igrave;");
      _criticals.Add("Í", "&Iacute;");
      _criticals.Add("Î", "&Icirc;");
      _criticals.Add("Ï", "&Iuml;");
      _criticals.Add("Ð", "&ETH;");
      _criticals.Add("Ñ", "&Ntilde;");
      _criticals.Add("Ò", "&Ograve;");
      _criticals.Add("Ó", "&Oacute;");
      _criticals.Add("Ô", "&Ocirc;");
      _criticals.Add("Õ", "&Otilde;");
      _criticals.Add("Ö", "&Ouml;");
      _criticals.Add("×", "&times;");
      _criticals.Add("Ø", "&Oslash;");
      _criticals.Add("Ù", "&Ugrave;");
      _criticals.Add("Ú", "&Uacute;");
      _criticals.Add("Û", "&Ucirc;");
      _criticals.Add("Ü", "&Uuml;");
      _criticals.Add("Ý", "&Yacute;");
      _criticals.Add("Þ", "&THORN;");
      _criticals.Add("à", "&agrave;");
      _criticals.Add("á", "&aacute;");
      _criticals.Add("â", "&acirc;");
      _criticals.Add("ã", "&atilde;");
      _criticals.Add("ä", "&auml;");
      _criticals.Add("å", "&aring;");
      _criticals.Add("æ", "&aelig;");
      _criticals.Add("ç", "&ccedil;");
      _criticals.Add("è", "&egrave;");
      _criticals.Add("é", "&eacute;");
      _criticals.Add("ê", "&ecirc;");
      _criticals.Add("ë", "&euml;");
      _criticals.Add("ì", "&igrave;");
      _criticals.Add("í", "&iacute;");
      _criticals.Add("î", "&icirc;");
      _criticals.Add("ï", "&iuml;");
      _criticals.Add("ð", "&eth;");
      _criticals.Add("ñ", "&ntilde;");
      _criticals.Add("ò", "&ograve;");
      _criticals.Add("ó", "&oacute;");
      _criticals.Add("ô", "&ocirc;");
      _criticals.Add("õ", "&otilde;");
      _criticals.Add("ö", "&ouml;");
      _criticals.Add("÷", "&divide;");
      _criticals.Add("ø", "&oslash;");
      _criticals.Add("ù", "&ugrave;");
      _criticals.Add("ú", "&uacute;");
      _criticals.Add("û", "&ucirc;");
      _criticals.Add("ü", "&uuml;");
      _criticals.Add("ý", "&yacute;");
      _criticals.Add("þ", "&thorn;");
      _criticals.Add("ÿ", "&yuml;");
    }

    /// <summary>
    ///   Bereinigt HTML-Quellcode der von RadRichTextEditor erstellt wurde.
    /// </summary>
    /// <param name="text">
    ///   HTML-Quellcode
    /// </param>
    /// <returns>
    ///   Bereinigter HTML-Quellcode
    /// </returns>
    public static string CleanEditorCode(string text)
    {
      var off = text.IndexOf("</style>", StringComparison.Ordinal);
      var cut = off + 8; // 8 = Length of </style>

      var lines = text.Substring(0, off).Split(Splitter.CRLF, StringSplitOptions.RemoveEmptyEntries);
      var html = text.Substring(cut);

      foreach (var s in lines.Where(s => s.StartsWith(".")))
      {
        var idx = s.IndexOf(' ');
        html = html.Replace($" class=\"{s.Substring(1, idx - 1)}\"", string.Empty);
      }

      return html;
    }

    /// <summary>
    ///   Säubert einen HTML-String von unlesbaren Zeichen
    /// </summary>
    /// <param name="text">
    ///   String
    /// </param>
    /// <returns>
    ///   String (sauber)
    /// </returns>
    public string CleanHtmlCode(string text)
    {
      return string.IsNullOrEmpty(text)
               ? string.Empty
               : _criticals.Aggregate(text, (current, x) => current.Replace(x.Key, x.Value));
    }

    /// <summary>
    ///   Wandelt HTML in Text um (spezialfunktion für LNScrap)
    /// </summary>
    /// <param name="html">
    /// </param>
    /// <returns>
    ///   The <see cref="string" />.
    /// </returns>
    public string LnScrapHtmlToText(string html)
    {
      if (string.IsNullOrEmpty(html))
        return string.Empty;

      html = _criticals.Aggregate(html, (current, c) => current.Replace(c.Value, c.Key));
      html =
        html.Replace("[#x201e]", "&quot;")
            .Replace(",,", "\"")
            .Replace('„', '"')
            .Replace('“', '"')
            .Replace('«', '"')
            .Replace('»', '"')
            .Replace("&quot;", "\"")
            .Replace("&nbsp;", " ")
            .Replace("<SPAN CLASS=\"c7\">", " ")
            .Replace("<SPAN CLASS=\"c11\">", " ")
            .Replace("</SPAN>", " ")
            .Replace("</P>", " ")
            .Replace("<SPAN CLASS=\"c10\">", " ")
            .Replace("<SPAN CLASS=\"c2\">", " ")
            .Replace("<BR>", " ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .Replace("&amp", "&");

      return html;
    }
  }
}