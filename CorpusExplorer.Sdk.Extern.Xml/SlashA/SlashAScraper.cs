#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.SlashA.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.SlashA
{
  // ReSharper disable once UnusedMember.Global
  public class SlashAScraper : AbstractXmlScraper
  {
    public override string DisplayName => "Slash/A-XML";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<DSpin>(file);
      return new[] {new Dictionary<string, object> {{"Text", model.TextCorpus.text}}};
    }
  }
}