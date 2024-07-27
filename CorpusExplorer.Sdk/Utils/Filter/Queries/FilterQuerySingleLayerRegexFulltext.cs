using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerRegexFulltext : AbstractFilterQuerySingleLayerFulltext
  {
    private string _regexQuery;
    private Regex _regex;

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
    public string RegexQuery
    {
      get => _regexQuery; set
      {
        _regexQuery = value;
        _regex = new Regex(_regexQuery, RegexOptions.Compiled);
      }
    }

    public override string Verbal =>
      $"Alle Dokumente (Volltext) auf die der RegEx \"{RegexQuery}\" in Layer {LayerDisplayname} zutrifft.";

    protected override IEnumerable<int> GetSentencesCall(IEnumerable<string> sentences)
    {
      var res = new List<int>();
      var arr = sentences.ToArray();
      for (var i = 0; i < arr.Length; i++)
        if (_regex.IsMatch(arr[i]))
          res.Add(i);

      return res;
    }

    protected override bool ValidateCall(string document)
    {
      return _regex.IsMatch(document);
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