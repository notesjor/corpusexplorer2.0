#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Bcs.Crawler.Interface;
using HtmlAgilityPack;

#endregion

namespace Bcs.Crawler
{
  // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
  /// <summary>
  ///   Class HtmlCrawler
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class HtmlCrawler : ICrawler
  {
    /// <summary>
    ///   The atribut marker
    /// </summary>
    [XmlIgnore]
    [NonSerialized]
    private const string AtributMarker = "/@";

    /// <summary>
    ///   The _criticals
    /// </summary>
    [XmlIgnore]
    [NonSerialized]
    private Dictionary<string, string> _criticals;

    /// <summary>
    ///   The _multi node separator
    /// </summary>
    [XmlAttribute("separator")]
    [NonSerialized]
    private string _multiNodeSeparator = "|";

    /// <summary>
    ///   Initializes a new instance of the <see cref="HtmlCrawler" /> class.
    /// </summary>
    public HtmlCrawler()
    {
      UrlLimmit = null;
    }

    /// <summary>
    ///   Trenner um mehrfach Ergebnisse eines XPath zu trennen.
    /// </summary>
    /// <value>The multi node separator.</value>
    [XmlIgnore]
    public string MultiNodeSeparator { get { return _multiNodeSeparator; } set { _multiNodeSeparator = value; } }

    /// <summary>
    ///   Parameter/Mapping
    /// </summary>
    /// <value>The parameters.</value>
    [XmlArray]
    public Dictionary<string, string> Parameters { get; set; }

    /// <summary>
    ///   Das UrlLimmit begrenzt diesen Crawler auf einen bestimmten URL-Bereich.
    ///   Die übergebene Url MUSS auf dieses Muster passen (mit dieser Url beginnen).
    /// </summary>
    /// <value>The URL limmit.</value>
    [XmlAttribute("limmitUrl")]
    public string UrlLimmit { get; set; }

    // ReSharper disable once MemberCanBePrivate.Global

    /// <summary>
    ///   Crawle die Url
    /// </summary>
    /// <returns>Gemappte Daten</returns>
    public Dictionary<string, object>[] Crawl()
    {
      if (!string.IsNullOrEmpty(UrlLimmit) &&
          !Url.StartsWith(UrlLimmit))
        return null;

      if ((Parameters == null) ||
          (Parameters.Count == 0))
        // ReSharper disable once NotResolvedInText
        throw new ArgumentNullException("Parameters");

      if (string.IsNullOrEmpty(Url))
        // ReSharper disable once NotResolvedInText
        throw new ArgumentNullException("Url");

      var web = new HtmlWeb();
      var doc = web.Load(Url);

      return CrawlCall(doc);
    }

    /// <summary>
    ///   Die zu crawlende URL
    /// </summary>
    /// <value>The URL.</value>
    [XmlAttribute("url")]
    public string Url { get; set; }

    /// <summary>
    ///   Crawls the specified URL.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url">The URL.</param>
    /// <param name="paramters">The paramters.</param>
    /// <param name="multiNodeSeparator">The multi node separator.</param>
    /// <returns>Dictionary{System.StringSystem.String}[][].</returns>
    public static Dictionary<string, object>[] Crawl<T>(
      string url,
      Dictionary<string, string> paramters,
      string multiNodeSeparator = "|") where T : HtmlCrawler, new()
    {
      var crawler = new T {Url = url, Parameters = paramters, MultiNodeSeparator = multiNodeSeparator};
      return crawler.Crawl();
    }

    /// <summary>
    ///   Crawlt das übergebene HTML-Dokument (URL wird ignoriert)
    /// </summary>
    /// <param name="html">HTML</param>
    /// <returns>Gemappte Daten</returns>
    public Dictionary<string, object>[] Crawl(string html)
    {
      if (!string.IsNullOrEmpty(UrlLimmit) &&
          !Url.StartsWith(UrlLimmit))
        return null;

      if ((Parameters == null) ||
          (Parameters.Count == 0))
        // ReSharper disable once NotResolvedInText
        throw new ArgumentNullException("Parameters");

      var doc = new HtmlDocument();
      doc.LoadHtml(html);

      return CrawlCall(doc);
    }

    private Dictionary<string, object>[] CrawlCall(HtmlDocument doc)
    {
      // Erezuge Stringbuilder
      var stbs = new Dictionary<string, StringBuilder>();
      foreach (var parameter in Parameters.Where(parameter => !stbs.ContainsKey(parameter.Value)))
        stbs.Add(parameter.Value, new StringBuilder());

      // Befülle Stringbuilder per XPath.InnerText
      foreach (var parameter in Parameters)
      {
        if (stbs[parameter.Value].Length > 0)
          stbs[parameter.Value].Append(" ");

        var hnode = doc.DocumentNode.SelectNodes(parameter.Key);
        if ((hnode == null) ||
            (hnode.Count == 0))
          continue;
        var nodes = hnode.ToArray();

        for (var i = 0; i < nodes.Length; i++)
        {
          stbs[parameter.Value].Append(
            parameter.Key.Contains(AtributMarker)
              ? nodes[i].GetAttributeValue(
                parameter.Key.Substring(
                           parameter.Key.IndexOf(
                                      AtributMarker,
                                      StringComparison
                                        .Ordinal) +
                           AtributMarker.Length),
                string.Empty)
              : HtmlCleanup(nodes[i].InnerText));

          // separiert mehrere Nodes
          if (i < nodes.Length - 1)
            stbs[parameter.Value].Append(_multiNodeSeparator);
        }
      }

      var resItem = StbsToMetadata(stbs);
      resItem.Add("Url", Url);

      // Baue Ausgabe
      var res = new[] {resItem};

      return HtmlCleanupChannel(HtmlSplitChannel(res));
    }

    /// <summary>
    ///   HTMLs the cleanup.
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <returns>System.String.</returns>
    private string HtmlCleanup(string html)
    {
      html =
        html.Replace("\t", " ")
            .Replace("\r", " ")
            .Replace("\n", " ")
            .Replace("&nbsp;", " ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .Replace("  ", " ");

      if (_criticals == null)
        InitializeCriticals();

      return _criticals.Aggregate(html, (current, c) => current.Replace(c.Key, c.Value));
    }

    /// <summary>
    ///   Sollte überschriebe werden, wenn eine andere Bereingung gewünscht ist als alle Werte (res) durch HtmlCleanup zu
    ///   leiten.
    /// </summary>
    /// <param name="res">Daten</param>
    /// <returns>Daten</returns>
    /// <example>
    ///   foreach (var r in res)
    ///   {
    ///   var keys = r.Keys;
    ///   foreach (var key in keys)
    ///   {
    ///   r[key] = HtmlCleanup(r[key]);
    ///   }
    ///   }
    ///   return res;
    /// </example>
    protected virtual Dictionary<string, object>[] HtmlCleanupChannel(Dictionary<string, object>[] res)
    {
      foreach (var r in res)
      {
        var keys = r.Keys.ToArray();
        foreach (var key in keys)
          r[key] = HtmlCleanup(r[key].ToString());
      }
      return res;
    }

    /// <summary>
    ///   Sollte überschrieben werden, wenn es sich um ein HTML-Dokument handelt das mehrere Beiträge enthält.
    /// </summary>
    /// <param name="res">Daten</param>
    /// <returns>Daten</returns>
    protected virtual Dictionary<string, object>[] HtmlSplitChannel(Dictionary<string, object>[] res)
    {
      return res;
    }

    private void InitializeCriticals()
    {
      _criticals = new Dictionary<string, string>
      {
        {"&quot;", "\""},
        {"&#34;", "\""},
        {"&amp;", "&"},
        {"&#38;", "&"},
        {"&lt;", "<"},
        {"&#60;", "<"},
        {"&gt;", ">"},
        {"&#62;", ">"},
        {"&nbsp;", ""},
        {"&#160;", ""},
        {"&iexcl;", "¡"},
        {"&#161;", "¡"},
        {"&cent;", "¢"},
        {"&#162;", "¢"},
        {"&pound;", "£"},
        {"&#163;", "£"},
        {"&curren;", "¤"},
        {"&#164;", "¤"},
        {"&yen;", "¥"},
        {"&#165;", "¥"},
        {"&brvbar;", "¦"},
        {"&#166;", "¦"},
        {"&sect;", "§"},
        {"&#167;", "§"},
        {"&uml;", "¨"},
        {"&#168;", "¨"},
        {"&copy;", "©"},
        {"&#169;", "©"},
        {"&ordf;", "ª"},
        {"&#170;", "ª"},
        {"&laquo;", "«"},
        {"&#171;", "«"},
        {"&not;", "¬"},
        {"&#172;", "¬"},
        {"&shy;", "­"},
        {"&#173;", "­"},
        {"&reg;", "®"},
        {"&#174;", "®"},
        {"&macr;", "¯"},
        {"&#175;", "¯"},
        {"&deg;", "°"},
        {"&#176;", "°"},
        {"&plusmn;", "±"},
        {"&#177;", "±"},
        {"&sup2;", "²"},
        {"&#178;", "²"},
        {"&sup3;", "³"},
        {"&#179;", "³"},
        {"&acute;", "´"},
        {"&#180;", "´"},
        {"&micro;", "µ"},
        {"&#181;", "µ"},
        {"&para;", "¶"},
        {"&#182;", "¶"},
        {"&middot;", "·"},
        {"&#183;", "·"},
        {"&cedil;", "¸"},
        {"&#184;", "¸"},
        {"&sup1;", "¹"},
        {"&#185;", "¹"},
        {"&ordm;", "º"},
        {"&#186;", "º"},
        {"&raquo;", "»"},
        {"&#187;", "»"},
        {"&frac14;", "¼"},
        {"&#188;", "¼"},
        {"&frac12;", "½"},
        {"&#189;", "½"},
        {"&frac34;", "¾"},
        {"&#190;", "¾"},
        {"&iquest;", "¿"},
        {"&#191;", "¿"},
        {"&Agrave;", "À"},
        {"&#192;", "À"},
        {"&Aacute;", "Á"},
        {"&#193;", "Á"},
        {"&Acirc;", "Â"},
        {"&#194;", "Â"},
        {"&Atilde;", "Ã"},
        {"&#195;", "Ã"},
        {"&Auml;", "Ä"},
        {"&#196;", "Ä"},
        {"&Aring;", "Å"},
        {"&#197;", "Å"},
        {"&AElig;", "Æ"},
        {"&#198;", "Æ"},
        {"&Ccedil;", "Ç"},
        {"&#199;", "Ç"},
        {"&Egrave;", "È"},
        {"&#200;", "È"},
        {"&Eacute;", "É"},
        {"&#201;", "É"},
        {"&Ecirc;", "Ê"},
        {"&#202;", "Ê"},
        {"&Euml;", "Ë"},
        {"&#203;", "Ë"},
        {"&Igrave;", "Ì"},
        {"&#204;", "Ì"},
        {"&Iacute;", "Í"},
        {"&#205;", "Í"},
        {"&Icirc;", "Î"},
        {"&#206;", "Î"},
        {"&Iuml;", "Ï"},
        {"&#207;", "Ï"},
        {"&ETH;", "Ð"},
        {"&#208;", "Ð"},
        {"&Ntilde;", "Ñ"},
        {"&#209;", "Ñ"},
        {"&Ograve;", "Ò"},
        {"&#210;", "Ò"},
        {"&Oacute;", "Ó"},
        {"&#211;", "Ó"},
        {"&Ocirc;", "Ô"},
        {"&#212;", "Ô"},
        {"&Otilde;", "Õ"},
        {"&#213;", "Õ"},
        {"&Ouml;", "Ö"},
        {"&#214;", "Ö"},
        {"&times;", "×"},
        {"&#215;", "×"},
        {"&Oslash;", "Ø"},
        {"&#216;", "Ø"},
        {"&Ugrave;", "Ù"},
        {"&#217;", "Ù"},
        {"&Uacute;", "Ú"},
        {"&#218;", "Ú"},
        {"&Ucirc;", "Û"},
        {"&#219;", "Û"},
        {"&Uuml;", "Ü"},
        {"&#220;", "Ü"},
        {"&Yacute;", "Ý"},
        {"&#221;", "Ý"},
        {"&THORN;", "Þ"},
        {"&#222;", "Þ"},
        {"&szlig;", "ß"},
        {"&#223;", "ß"},
        {"&agrave;", "à"},
        {"&#224;", "à"},
        {"&aacute;", "á"},
        {"&#225;", "á"},
        {"&acirc;", "â"},
        {"&#226;", "â"},
        {"&atilde;", "ã"},
        {"&#227;", "ã"},
        {"&auml;", "ä"},
        {"&#228;", "ä"},
        {"&aring;", "å"},
        {"&#229;", "å"},
        {"&aelig;", "æ"},
        {"&#230;", "æ"},
        {"&ccedil;", "ç"},
        {"&#231;", "ç"},
        {"&egrave;", "è"},
        {"&#232;", "è"},
        {"&eacute;", "é"},
        {"&#233;", "é"},
        {"&ecirc;", "ê"},
        {"&#234;", "ê"},
        {"&euml;", "ë"},
        {"&#235;", "ë"},
        {"&igrave;", "ì"},
        {"&#236;", "ì"},
        {"&iacute;", "í"},
        {"&#237;", "í"},
        {"&icirc;", "î"},
        {"&#238;", "î"},
        {"&iuml;", "ï"},
        {"&#239;", "ï"},
        {"&eth;", "ð"},
        {"&#240;", "ð"},
        {"&ntilde;", "ñ"},
        {"&#241;", "ñ"},
        {"&ograve;", "ò"},
        {"&#242;", "ò"},
        {"&oacute;", "ó"},
        {"&#243;", "ó"},
        {"&ocirc;", "ô"},
        {"&#244;", "ô"},
        {"&otilde;", "õ"},
        {"&#245;", "õ"},
        {"&ouml;", "ö"},
        {"&#246;", "ö"},
        {"&divide;", "÷"},
        {"&#247;", "÷"},
        {"&oslash;", "ø"},
        {"&#248;", "ø"},
        {"&ugrave;", "ù"},
        {"&#249;", "ù"},
        {"&uacute;", "ú"},
        {"&#250;", "ú"},
        {"&ucirc;", "û"},
        {"&#251;", "û"},
        {"&uuml;", "ü"},
        {"&#252;", "ü"},
        {"&yacute;", "ý"},
        {"&#253;", "ý"},
        {"&thorn;", "þ"},
        {"&#254;", "þ"},
        {"&yuml;", "ÿ"},
        {"&#255;", "ÿ"},
        {"&bull;", "•"},
        {"&#8226;", "•"},
        {"&trade;", "™"},
        {"&#8482;", "™"},
        {"&euro;", "€"},
        {"&#8364;", "€"},
        {"&OElig;", "Œ"},
        {"&#338;", "Œ"},
        {"&oelig;", "œ"},
        {"&#339;", "œ"},
        {"&Scaron;", "Š"},
        {"&#352;", "Š"},
        {"&scaron;", "š"},
        {"&#353;", "š"},
        {"&Yuml;", "Ÿ"},
        {"&#376;", "Ÿ"},
        {"&fnof;", "ƒ"},
        {"&#402;", "ƒ"},
        {"&ndash;", "–"},
        {"&#8211;", "–"},
        {"&mdash;", "—"},
        {"&#8212;", "—"},
        {"&lsquo;", "‘"},
        {"&#8216;", "‘"},
        {"&rsquo;", "’"},
        {"&#8217;", "’"},
        {"&sbqu;", "‚"},
        {"&ldquo;", "“"},
        {"&#8220;", "“"},
        {"&rdquo;", "”"},
        {"&#8221;", "”"},
        {"&bdquo;", "„"},
        {"&#8222;", "„"},
        {"&dagger;", "†"},
        {"&#8224;", "†"},
        {"&Dagger;", "‡"},
        {"&#8225;", "‡"},
        {"&hellip;", "…"},
        {"&#8230;", "…"},
        {"&permil;", "‰"},
        {"&#8240;", "‰"},
        {"&lsaquo;", "‹"},
        {"&#8249;", "‹"},
        {"&rsaquo;", "›"},
        {"&#8250;", "›"},
        {"&circ;", "ˆ"},
        {"&#710;", "ˆ"},
        {"&tilde;", "˜"},
        {"&#732;", "˜"}
      };
    }

    /// <summary>
    ///   STBSs to metadata.
    /// </summary>
    /// <param name="stbs">The STBS.</param>
    /// <returns>Dictionary{System.StringSystem.String}.</returns>
    private Dictionary<string, object> StbsToMetadata(Dictionary<string, StringBuilder> stbs)
    {
      return stbs.ToDictionary(stb => stb.Key, stb => (object) stb.Value.ToString());
    }
  }
}