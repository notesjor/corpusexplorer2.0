#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf
{
  // ReSharper disable once UnusedMember.Global
  public class DtaScraper : AbstractXmlScraper
  {
    public override string DisplayName => "DTA-TCF-XML";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<DSpin>(file);
      var corpus = model.TextCorpus;
      var tokens = corpus.tokens.ToDictionary(t => t.ID, t => t.Value);
      var stb = new StringBuilder();

      foreach (
        var tids in corpus.sentences.Select(s => s.tokenIDs.Split(Splitter.Space, StringSplitOptions.RemoveEmptyEntries)))
        stb.AppendLine(string.Join(" ", tids.Select(tid => tokens[tid])));

      return new[] {new Dictionary<string, object> {{"Text", stb.ToString()}}};
    }
  }
}