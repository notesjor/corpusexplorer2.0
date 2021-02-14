#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus
{
  public sealed class DortmunderChatKorpusScraper : AbstractXmlScraper
  {
    public override string DisplayName => "Dortmunder Chat Korpus";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<logfile>(file);
      return
        model.body.Select(
          message =>
            new Dictionary<string, object>
            {
              {"Farbe", message.color},
              {"Autor", message.creator},
              {"Id", message.id},
              {"Datum 1", message.timestamp},
              {"Datum 2", message.timestamp1},
              {"Typ", message.type},
              {"Modus", message.messageHead.mode},
              {"Nickname", message.messageHead.nickname},
              {"Text", string.Join(" ", message.messageBody.Text)}
            });
    }
  }
}