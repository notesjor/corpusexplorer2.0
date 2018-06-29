#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht.Serializer;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht
{
  public class ExporterWeblicht : AbstractExporter
  {
    public string CorpusLanguage { get; set; } = "de";
    public string CorpusTagset { get; set; } = "STTS";
    public string LayernameLemma { get; set; } = "Lemma";
    public string LayernamePos { get; set; } = "POS";

    public string LayernameWord { get; set; } = "Wort";
    public string MetanameAuthor { get; set; } = "Autor";
    public string MetanameDate { get; set; } = "Datum";
    public string UnknownDateValue { get; set; } = "0001-01-01";
    public string UnknownPropertyValue { get; set; } = "Unbekannt";

    public override void Export(IHydra hydra, string path)
    {
      path = path.Replace(".xml", "");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      var xml = new WeblichtSerializer();
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
      var docW = hydra.GetReadableDocument(guid, LayernameWord).Select(x => x.ToArray()).ToArray();
      // Die folgenden Layer sind optional
      var docL = hydra.GetReadableDocument(guid, LayernameLemma)?.Select(x => x.ToArray()).ToArray();
      var docP = hydra.GetReadableDocument(guid, LayernamePos)?.Select(x => x.ToArray()).ToArray();
      var docN = hydra.GetReadableDocument(guid, "NER")?.Select(x => x.ToArray()).ToArray();
      var docO = hydra.GetReadableDocument(guid, "Orthografie")?.Select(x => x.ToArray()).ToArray();

      var text = new StringBuilder();
      var tokens = new List<TextCorpusToken>();
      var lemmas = new List<TextCorpusLemma>();
      var tags = new List<TextCorpusPOStagsTag>();
      var sents = new List<TextCorpusSentence>();
      var ners = new List<TextCorpusNamedEntitiesEntity>();
      var orthos = new List<TextCorpusCorrection>();

      var id = 1;

      var lId = 1;

      for (var j = 0; j < docW.Length; j++)
      {
        var sent = new StringBuilder();
        for (var k = 0; k < docW[j].Length; k++)
        {
          var iD = "t" + id++;
          sent.AppendFormat(" {0}", iD);
          tokens.Add(new TextCorpusToken {ID = iD, Value = docW[j][k]});
          if (docL != null)
            lemmas.Add(new TextCorpusLemma {ID = "" + lId++, tokenIDs = iD, Value = docL[j][k]});
          if (docP != null)
            tags.Add(new TextCorpusPOStagsTag {tokenIDs = iD, Value = docP[j][k]});
          if (docN != null)
            ners.Add(new TextCorpusNamedEntitiesEntity {tokenIDs = iD, @class = docN[j][k]});
          if (docO != null)
            orthos.Add(new TextCorpusCorrection {tokenIDs = iD, Value = docO[j][k], operation = "replace"});

          if (docW[j][k].Length > 1)
            text.Append(" ");
          text.Append(docW[j][k]);
        }

        sents.Add(new TextCorpusSentence {tokenIDs = sent.ToString().Trim(), ID = "s" + j});
      }

      return new DSpin
      {
        MetaData =
          new MetaData
          {
            source = "CorpusExplorer"
          },
        version = (decimal) 2.0,
        TextCorpus =
          new TextCorpus
          {
            lang = CorpusLanguage,
            tokens = tokens.ToArray(),
            lemmas = docL == null ? null : lemmas.ToArray(),
            orthography = docO == null ? null : orthos.ToArray(),
            POStags = docP == null ? null : new TextCorpusPOStags {tag = tags.ToArray(), tagset = CorpusTagset},
            namedEntities =
              docN == null ? null : new TextCorpusNamedEntities {type = "CoNLL2002", entity = ners.ToArray()},
            sentences = sents.ToArray()
          }
      };
    }
  }
}