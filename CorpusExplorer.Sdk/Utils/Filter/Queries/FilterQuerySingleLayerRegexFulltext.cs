using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerRegexFulltext : AbstractFilterQuerySingleLayerFulltext
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractFilterQuerySingleLayer" /> class.
    /// </summary>
    public FilterQuerySingleLayerRegexFulltext()
    {
      LayerDisplayname = "Wort";
      RegexQuery = "";
    }

    /// <summary>
    ///   Gets or sets the layer queries.
    /// </summary>
    public string RegexQuery { get; set; }

    public override string Verbal =>
      $"Alle Dokumente (Volltext) auf die der RegEx \"{RegexQuery}\" in Layer {LayerDisplayname} zutrifft.";

    protected override int GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, string sentence)
    {
      var matches = new Regex(RegexQuery).Matches(sentence);
      if (matches.Count == 0)
        return -1;

      var str = sentence.Substring(0, matches[0].Index).Trim();
      return string.IsNullOrWhiteSpace(str)
                ? 0
                : str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    protected override IEnumerable<int> GetSentencesCall(IEnumerable<string> sentences)
    {
      var regex = new Regex(RegexQuery);

      var res = new List<int>();
      var arr = sentences.ToArray();
      for (var i = 0; i < arr.Length; i++)
        if (regex.IsMatch(arr[i]))
          res.Add(i);

      return res;
    }

    protected override IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, string sentence)
    {
      var matches = new Regex(RegexQuery).Matches(sentence);
      if (matches.Count == 0)
        return null;

      var res = new List<int>();
      foreach (Match match in matches)
      {
        var str = sentence.Substring(0, match.Index).Trim();
        res.Add(string.IsNullOrWhiteSpace(str)
                  ? 0
                  : str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length);
      }

      return res;
    }

    protected override bool ValidateCall(string document)
    {
      return new Regex(RegexQuery).IsMatch(document);
    }

    public override object Clone()
    {
      return new FilterQuerySingleLayerRegexFulltext
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        RegexQuery = RegexQuery,
        OrFilterQueries = OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }
  }
}