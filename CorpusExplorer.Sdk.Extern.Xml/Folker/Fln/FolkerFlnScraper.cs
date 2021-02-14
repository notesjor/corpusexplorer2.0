using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln
{
  public class FolkerFlnScraper : AbstractXmlScraper
  {
    public override string DisplayName => "FOLKER-FLN";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<folkertranscription>(file);

      var idx = 1;

      return model.contribution.Select(contribution => new Dictionary<string, object>
                   {
                     {"Index", idx++},
                     {"Sprecher*in", contribution.speakerreference},
                     {"Sprecher*in (DGD)", contribution.speakerdgdid},
                     {"ID", contribution.id},
                     {"Text", GetText(contribution.Items)}
                   });
    }

    private string GetText(object[] items)
    {
      var tokens = new List<string>();
      foreach (var item in items)
      {
        if (item is w w)
          tokens.Add(string.Join(" ", w.Text).Trim());
      }

      return string.Join(" ", tokens);
    }
  }
}
