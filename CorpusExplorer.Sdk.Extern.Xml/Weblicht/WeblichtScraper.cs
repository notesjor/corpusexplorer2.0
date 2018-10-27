#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht.Serializer;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht
{
  // ReSharper disable once UnusedMember.Global
  public class WeblichtScraper : AbstractGenericXmlSerializerFormatScraper<DSpin>
  {
    public override string DisplayName => "Weblicht-XML";

    protected override AbstractGenericSerializer<DSpin> Serializer => new WeblichtSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, DSpin model)
    {
      var corpus = model.TextCorpus;
      var tokens = corpus.tokens.ToDictionary(t => t.ID, t => t.Text);
      var stb = new StringBuilder();

      foreach (
        var tids in corpus.sentences.Select(s => s.tokenIDs.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)))
        stb.AppendLine(string.Join(" ", tids.Select(tid => tokens[tid])));

      return new[] {new Dictionary<string, object> {{"Text", stb.ToString()}}};
    }
  }
}