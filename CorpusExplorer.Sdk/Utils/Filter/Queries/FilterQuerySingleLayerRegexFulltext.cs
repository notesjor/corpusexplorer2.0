using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
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
    ///   Gets or sets the layer displayname.
    /// </summary>
    [XmlAttribute("layer")]
    public string LayerDisplayname { get; set; }

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

    protected override bool ValidateCall(string document)
    {
      return new Regex(RegexQuery).IsMatch(document);
    }

    /// <summary>
    ///   Gets or sets the layer queries.
    /// </summary>
    public string RegexQuery { get; set; }

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

    public override string Verbal =>
      $"Alle Dokumente (Volltext) auf die der RegEx \"{RegexQuery}\" in Layer {LayerDisplayname} zutrifft.";

  }
}