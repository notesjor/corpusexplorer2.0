#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.SlashA.Model;
using CorpusExplorer.Sdk.Extern.Xml.SlashA.Serializer;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.SlashA
{
  public class ExporterSlashA : AbstractExporter
  {
    public string CorpusEntitiesType { get; set; } = "openNLP";

    public string CorpusLanguage { get; set; } = "de";
    public string CorpusTagset { get; set; } = "STTS";
    public string LayernameLemma { get; set; } = "Lemma";
    public string LayernamePos { get; set; } = "POS";

    public string LayernameWord { get; set; } = "Wort";
    public string MetanameAuthor { get; set; } = "Autor";
    public string MetanameDate { get; set; } = "Datum";
    public string MetanamePublishingLocation { get; set; } = "Zeitung";
    public string MetanameReciver { get; set; } = "Empfänger";
    public string UnknownDateValue { get; set; } = "0001-01-01";
    public string UnknownPropertyValue { get; set; } = "Unbekannt";

    public override void Export(IHydra hydra, string path)
    {
      var xml = new SlashASerializer();
      var i = 0;

      foreach (var guid in hydra.DocumentGuids)
        try
        {
          xml.Serialize(GetDSpin(hydra, guid, i++), Path.Combine(path, guid + ".xml"));
        }
        catch
        {
        }
    }

    private DSpin GetDSpin(IHydra hydra, Guid guid, int i)
    {
      var meta = hydra.GetDocumentMetadata(guid);

      var from = meta != null && meta.ContainsKey(MetanameAuthor)
        ? meta[MetanameAuthor].ToString()
        : UnknownPropertyValue;
      var datum = meta != null && meta.ContainsKey(MetanameDate)
        ? meta[MetanameDate] is DateTime
          ? ((DateTime) meta[MetanameDate]).ToString("yyyy-MM-dd")
          : meta[MetanameDate].ToString()
        : UnknownDateValue;
      var to = meta != null && meta.ContainsKey(MetanamePublishingLocation)
        ? meta[MetanamePublishingLocation].ToString()
        : meta != null && meta.ContainsKey(MetanameReciver)
          ? meta[MetanameReciver].ToString()
          : UnknownPropertyValue;

      var docW = hydra.GetReadableDocument(guid, LayernameWord).Select(x => x.ToArray()).ToArray();
      var docL = hydra.GetReadableDocument(guid, LayernameLemma).Select(x => x.ToArray()).ToArray();
      var docP = hydra.GetReadableDocument(guid, LayernamePos).Select(x => x.ToArray()).ToArray();

      var text = new StringBuilder();
      var tokens = new List<token>();
      var lemmas = new List<lemma>();
      var tags = new List<tag>();
      var sents = new List<sentence>();

      var id = 1;
      for (var j = 0; j < docW.Length; j++)
      {
        var sent = new StringBuilder();
        for (var k = 0; k < docW[j].Length; k++)
        {
          var iD = "t_" + id++;
          sent.AppendFormat(" {0}", iD);
          tokens.Add(new token {ID = iD, Text = new[] {docW[j][k]}});
          lemmas.Add(new lemma {tokenIDs = iD, Text = new[] {docL[j][k]}});
          tags.Add(new tag {tokenIDs = iD, Text = new[] {docP[j][k]}});
          if (docW[j][k].Length > 1)
            text.Append(" ");
          text.Append(docW[j][k]);
        }

        sents.Add(new sentence {tokenIDs = sent.ToString().Trim()});
      }

      return new DSpin
      {
        MetaData =
          new MetaData
          {
            vistola = new vistola
            {
              correspondence = new correspondence {from = from, to = to},
              dates =
                new dates
                {
                  date =
                    new date
                    {
                      calculated = new calculated {date = datum},
                      rough = new rough {date = datum},
                      written = new written {date = datum},
                      window = new window {sdate = datum, edate = datum}
                    }
                },
              editor = new editor {initials = ""},
              number = new number {letter = i.ToString(), volume = "v1"},
              postmark = new postmark {date = datum}
            }
          },
        version = (decimal) 2.0,
        TextCorpus =
          new TextCorpus
          {
            lang = CorpusLanguage,
            text = text.ToString().Trim(),
            tokens = tokens.ToArray(),
            lemmas = lemmas.ToArray(),
            namedEntities = new namedEntities {type = CorpusEntitiesType, entity = new entity[0]},
            POStags =
              new POStags
              {
                tagset = CorpusTagset,
                tag = tags.ToArray()
              },
            sentences = sents.ToArray()
          }
      };
    }
  }
}