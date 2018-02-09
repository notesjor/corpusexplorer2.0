#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

#endregion

namespace CorpusExplorer.Core.DocumentProcessing.Scraper.Html
{
  public sealed class LexisNexisScraper : AbstractScraper
  {
    /// <summary>
    ///   Snippet: Zeilenbeginn Autor
    /// </summary>
    private const string StRau =
      "<BR><DIV CLASS=\"c4\"><P CLASS=\"c5\"><SPAN CLASS=\"c7\">AUTOR: </SPAN><SPAN CLASS=\"c2\">";

    /// <summary>
    ///   Snippet: Zeilenbeginn Datum
    /// </summary>
    private const string StRdt =
      "<BR><DIV CLASS=\"c4\"><P CLASS=\"c5\"><SPAN CLASS=\"c7\">UPDATE: </SPAN><SPAN CLASS=\"c2\">";

    /// <summary>
    ///   Snippet: Zeilenende (allgemein)
    /// </summary>
    private const string StRen = "</SPAN></P>";

    /// <summary>
    ///   Snippet: Zeilenbeginn Erste Textzeile
    /// </summary>
    private const string StRfl = "<BR><DIV CLASS=\"c4\"><P CLASS=\"c8\"><SPAN CLASS=\"c2\">";

    /// <summary>
    ///   Snippet: Ignoriere Weblink-Zeilen
    /// </summary>
    private const string StRignU1 = "<P CLASS=\"c8\"><SPAN CLASS=\"c2\">Weblink: ";

    /// <summary>
    ///   Snippete: Ignoriere URL-Zeilen
    /// </summary>
    private const string StRignU2 =
      "<BR><DIV CLASS=\"c4\"><P CLASS=\"c5\"><SPAN CLASS=\"c7\">URL: </SPAN><SPAN CLASS=\"c2\">";

    /// <summary>
    ///   Snippet: Zeilenbeginn Zweite und weitere Textzeile
    /// </summary>
    private const string StRnl = "<P CLASS=\"c8\"><SPAN CLASS=\"c2\">";

    /// <summary>
    ///   Snippet: Zeilenbeginn Listenbpunkt (sortierte Liste) - Teil 1
    ///   (Nummernpunkt)
    /// </summary>
    private const string StRol1 = "<P CLASS=\"c8\"><SPAN CLASS=\"c7\">";

    /// <summary>
    ///   Snippet: Zeilenbeginn Listenbpunkt (sortierte Liste) - Teil 1 (Text)
    /// </summary>
    private const string StRol2 = "</SPAN><SPAN CLASS=\"c2\">";

    /// <summary>
    ///   Snippet: Publikation
    /// </summary>
    private const string StRpu =
      "<BR><DIV CLASS=\"c4\"><P CLASS=\"c5\"><SPAN CLASS=\"c7\">PUBLICATION-TYPE: </SPAN><SPAN CLASS=\"c2\">";

    /// <summary>
    ///   Snippet: Zeilenbeginn Rubrik
    /// </summary>
    private const string StRrb =
      "<BR><DIV CLASS=\"c4\"><P CLASS=\"c5\"><SPAN CLASS=\"c7\">RUBRIK: </SPAN><SPAN CLASS=\"c2\">";

    /// <summary>
    ///   Snippet: Zeilenbeginn Titel
    /// </summary>
    private const string StRti = "<BR><DIV CLASS=\"c4\"><P CLASS=\"c5\"><SPAN CLASS=\"c6\">";

    /// <summary>
    ///   Snippet: Zeilenbeginn Listenbpunkt (unsortierte Liste)
    /// </summary>
    private const string StRul = "<DIV CLASS=\"c14\"><P CLASS=\"c5\"><SPAN CLASS=\"c2\">         ";

    /// <summary>
    ///   Snippet: Zeilenbeginn Zeitung/Magazin
    /// </summary>
    private const string StRze = "<BR><DIV CLASS=\"c0\"><BR><P CLASS=\"c1\"><IMG SRC=";

    /// <summary>
    ///   Snippet: Zeilenseparator Zeitung/Magazin
    /// </summary>
    private const string StRzz = "<SPAN CLASS=\"c2\">";

    public override string DisplayName => "LexisNexis™-HTML";

    /// <summary>
    ///   Checks the line end.
    /// </summary>
    /// <param name="str">
    ///   The STR.
    /// </param>
    /// <returns>
    ///   System.String.
    /// </returns>
    private static string CheckLineEnd(string str)
    {
      return str.EndsWith(".") || str.EndsWith("!") || str.EndsWith("?") || str.EndsWith("\"") || str.EndsWith(":")
             || str.EndsWith(";") || str.EndsWith(",") || str.EndsWith("-")
               ? str
               : str + ".";
    }

    /// <summary>
    ///   Ermittles the CSS klasse.
    /// </summary>
    /// <param name="lines">
    ///   The lines.
    /// </param>
    /// <returns>
    ///   System.String[][].
    /// </returns>
    private static string[] ErmittleCssKlasse(string[] lines)
    {
      var fline = new List<string>(lines);

      var c0 = FindCss(fline, "{ text-align: center; }", 0);
      var c1 = FindCss(fline, "{ text-align: center; margin-top: 0em; margin-bottom: 0em; }", 1);
      var c2 = FindCss(
        fline,
        "{ font-family: 'Times New Roman'; font-size: 10pt; font-style: normal; font-weight: normal; color: #000000; text-decoration: none; }",
        2);
      var c3 = FindCss(fline, "{ text-align: center; margin-left: 13%; margin-right: 13%; }", 3);
      var c4 = FindCss(fline, "{ text-align: left; }", 4);
      var c5 = FindCss(fline, "{ text-align: left; margin-top: 0em; margin-bottom: 0em; }", 5);
      var c6 = FindCss(
        fline,
        "{ font-family: 'Times New Roman'; font-size: 14pt; font-style: normal; font-weight: bold; color: #000000; text-decoration: none; }",
        6);
      var c7 = FindCss(
        fline,
        "{ font-family: 'Times New Roman'; font-size: 10pt; font-style: normal; font-weight: bold; color: #000000; text-decoration: none; }",
        7);
      var c8 = FindCss(fline, "{ text-align: left; margin-top: 1em; margin-bottom: 0em; }", 8);
      var c9 = FindCss(fline, "{ page-break-before: always; }", 9);
      var c10 = FindCss(
        fline,
        "{ font-family: 'Times New Roman'; font-size: 10pt; font-style: italic; font-weight: normal; color: #000000; text-decoration: none; }",
        10);
      var c11 = FindCss(
        fline,
        "{ font-family: 'Times New Roman'; font-size: 10pt; font-style: italic; font-weight: bold; color: #000000; text-decoration: none; }",
        11);

      for (var i = 0; i < lines.Length; i++)
        lines[i] =
          lines[i].Replace(c0, "\"c0\"")
                  .Replace(c1, "\"c1\"")
                  .Replace(c2, "\"c2\"")
                  .Replace(c3, "\"c3\"")
                  .Replace(c4, "\"c4\"")
                  .Replace(c5, "\"c5\"")
                  .Replace(c6, "\"c6\"")
                  .Replace(c7, "\"c7\"")
                  .Replace(c8, "\"c8\"")
                  .Replace(c9, "\"c9\"")
                  .Replace(c10, "\"c10\"")
                  .Replace(c11, "\"c11\"");

      return lines;
    }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();
      var lines = File.ReadAllLines(file);

      StringBuilder stb = null;
      var metaDatum = DateTime.MinValue;
      string metaAutor = null;
      string metaRubrik = null;
      string metaZeitung = null;
      string metaPublikation = null;
      string metaTitel = null;

      lines = ErmittleCssKlasse(lines);

      foreach (
        var line in lines.Select(t => t.Replace("<BR >", "<BR>").Replace("\" >", "\">")).Where(line => line != "</DIV>")
      )
      {
        if (stb == null)
        {
          if (line == "<DOCFULL> -->")
            stb = new StringBuilder();
          continue;
        }

        if (line.StartsWith(StRignU1) ||
            line.StartsWith(StRignU2))
          continue;

        if (line.StartsWith(StRze))
        {
          metaZeitung =
            line.Substring(line.IndexOf(StRzz, StringComparison.Ordinal))
                .Replace(StRzz, string.Empty)
                .Replace(StRen, string.Empty);
          continue;
        }

        if (line.StartsWith(StRdt))
        {
          metaDatum = DateTimeHelper.Parse(line.Replace(StRdt, string.Empty).Replace(StRen, string.Empty), true);
          continue;
        }

        if (line.StartsWith(StRau))
        {
          metaAutor = line.Replace(StRau, string.Empty).Replace(StRen, string.Empty).ToLower();
          var splA = metaAutor.Split(' ');
          metaAutor =
            splA.Where(s => !string.IsNullOrEmpty(s) && s.Length > 1)
                .Aggregate(string.Empty, (current, s) => current + s.Substring(0, 1).ToUpper() + s.Substring(1) + " ")
                .Trim();
          continue;
        }

        if (line.StartsWith(StRrb))
        {
          metaRubrik = line.Replace(StRrb, string.Empty).Replace(StRen, string.Empty).Split(';')[0];
          continue;
        }

        if (line.StartsWith(StRpu))
        {
          metaPublikation = line.Replace(StRpu, string.Empty).Replace(StRen, string.Empty);
          continue;
        }

        if (line.StartsWith(StRti))
        {
          metaTitel = line.Replace(StRti, string.Empty).Replace(StRen, string.Empty);
          continue;
        }

        if (line.StartsWith(StRfl))
        {
          stb.Append(CheckLineEnd(line.Replace(StRfl, string.Empty).Replace(StRen, string.Empty).Trim()) + " ");
          continue;
        }

        if (line.StartsWith(StRnl))
        {
          stb.Append(CheckLineEnd(line.Replace(StRnl, string.Empty).Replace(StRen, string.Empty).Trim()) + " ");
          continue;
        }

        if (line.StartsWith(StRul))
        {
          stb.Append(
            "\r\n-" + CheckLineEnd(line.Replace(StRul, string.Empty).Replace(StRen, string.Empty).Trim()) + " ");
          continue;
        }

        if (line.Contains(StRol1) &&
            line.Contains(StRol2))
        {
          var fi = line.IndexOf(StRol1, StringComparison.Ordinal);
          var li = line.IndexOf(StRol2, StringComparison.Ordinal);
          var num = line.Substring(fi, li - fi).Replace(StRol1, string.Empty);
          var txt = line.Substring(li).Replace(StRol2, string.Empty);

          stb.Append("\r\n" + num + " " + txt + "\r\n");
          continue;
        }

        if (line != "</DOCFULL>")
          continue;

        var text = stb.ToString();

        res.Add(
          new Dictionary<string, object>
          {
            {"Text", text},
            {"Titel", SafeTitel(metaTitel, text)},
            {"Autor", metaAutor},
            {"Rubrik", metaRubrik},
            {"Publikation", metaPublikation},
            {"Zeitung", metaZeitung},
            {"Datum", metaDatum}
          });

        stb = null;
        metaDatum = DateTime.MinValue;
        metaAutor = null;
        metaRubrik = null;
        metaZeitung = null;
        metaPublikation = null;
        metaTitel = null;
      }

      return res.ToArray();
    }

    /// <summary>
    ///   Finds the CSS.
    /// </summary>
    /// <param name="fline">
    ///   The fline.
    /// </param>
    /// <param name="query">
    ///   The query.
    /// </param>
    /// <param name="defaultValue">
    ///   The default value.
    /// </param>
    /// <returns>
    ///   System.String.
    /// </returns>
    private static string FindCss(List<string> fline, string query, int defaultValue)
    {
      try
      {
        return "\"" + fline.Find(x => x.Contains(query)).Substring(1, 3) + "\"";
      }
      catch
      {
        return $"\"c{defaultValue}\"";
      }
    }

    /// <summary>
    ///   Safes the titel.
    /// </summary>
    /// <param name="titel">
    ///   The titel.
    /// </param>
    /// <param name="text">
    ///   The text.
    /// </param>
    /// <returns>
    ///   System.String.
    /// </returns>
    private static string SafeTitel(string titel, string text)
    {
      if (!string.IsNullOrEmpty(titel))
        return titel;

      byte[] md5;
      using (var hash = MD5.Create())
      {
        md5 = hash.ComputeHash(Configuration.Encoding.GetBytes(text));
      }

      return md5.Aggregate(string.Empty, (current, b) => current + b.ToString("X2"));
    }
  }
}