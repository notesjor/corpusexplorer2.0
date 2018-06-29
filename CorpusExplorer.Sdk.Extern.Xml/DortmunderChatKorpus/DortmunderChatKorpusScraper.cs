#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Model;
using CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Serializer;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus
{
  public sealed class DortmunderChatKorpusScraper : AbstractGenericXmlSerializerFormatScraper<logfile>
  {
    public override string DisplayName => "Dortmunder Chat Korpus";

    protected override AbstractGenericSerializer<logfile> Serializer => new DortmunderChatKorpusSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, logfile model)
    {
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