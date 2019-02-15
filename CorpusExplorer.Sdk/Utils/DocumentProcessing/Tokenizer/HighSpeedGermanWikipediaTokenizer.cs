#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer
{
  public sealed class HighSpeedGermanWikipediaTokenizer : AbstractTokenizer
  {
    /// <summary>
    ///   Darf nur 3-Zeichen lange strings enthalten
    /// </summary>
    private readonly HashSet<string> _check = new HashSet<string> {"htt", "url", "://"};

    private readonly Dictionary<string, string> _dicPre = new Dictionary<string, string>
    {
      {".", " ."},
      {",", " ,"},
      {"!", " !"},
      {"?", " ?"},
      {";", " ;"},
      {":", " :"},
      {"http :", "http:"},
      {"url= :", "url=:"},
      {"url= http", "url=http"},
      {"(", "( "},
      {"[", "[ "},
      {"{", "{ "},
      {")", " )"},
      {"]", " ]"},
      {"}", " }"},
      {">", "> "},
      {"<", " <"},
      {"''", "\""},
      {",,", "\""},
      {"\"", " \" "},
      {"\r\n", " "},
      {"\n\r", " "},
      {"\t", " "},
      {"\r", " "},
      {"\n", " "}
    };

    public override string DisplayName => "HighSpeed German-Tokenizer (Wikipedia-Edition)";

    public override string Language
    {
      get => "Deutsch";
      set { }
    }

    public override string Execute(string input)
    {
      // Ersetze alle Zeichenketten die in _dicPre definiert sind (suche nach Key, ersetze mit Value) und teile dann die Worte anhand der Leerzeichen auf.
      var lines =
        _dicPre.Aggregate(input, (current, entry) => current.Replace(entry.Key, entry.Value)).Split(
                                                                                                    new[] {" "},
                                                                                                    StringSplitOptions
                                                                                                     .RemoveEmptyEntries);
      var res = new List<string>();

      for (var i = 0; i < lines.Length; i++)
      {
        var line = lines[i];

        if (string.IsNullOrEmpty(line))
          continue;
        if (line[0]     == '?' &&
            line.Length > 1)
          continue;

        if (line.Length > MaxLineLength)
          line = MaxLineLimmitPattern;
        else if (line[0] == '.')
          if (i > 0 &&
              (lines[i - 1].Length == 1 || lines[i - 1].Contains(".") || lines[i - 1].Contains("://")))
          {
            line = res[res.Count - 1] + line;
            res.RemoveAt(res.Count - 1);
            if (!line.Contains("://")            &&
                res.Count > 1                    &&
                res[res.Count - 1].EndsWith(".") &&
                !res[res.Count - 1].Contains("://"))
            {
              line = res[res.Count - 1] + line;
              res.RemoveAt(res.Count - 1);
            }
          }

        res.Add(line);
      }

      for (var i = 0; i < res.Count; i++)
        if (res[i].Length > 3 &&
            _check.Contains(res[i].Substring(0, 3)))
          res[i] = "[.!.]";

      return string.Join("\r\n", res);
    }

    // ReSharper disable MemberCanBePrivate.Global
    public int MaxLineLength
    {
      get;
      // ReSharper disable once UnusedMember.Global
      set;
    } = 150;

    public string MaxLineLimmitPattern
    {
      get;
      // ReSharper disable once UnusedMember.Global
      set;
    } = "[.!.]";

    // ReSharper restore MemberCanBePrivate.Global
  }
}