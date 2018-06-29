#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Serializer;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017
{
  public class ExporterDta2017 : AbstractExporter
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
      path = path.Replace(".tcf.xml", "");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      var xml = new Dta2017Serializer();
      var i = 0;

      foreach (var guid in hydra.DocumentGuids)
        try
        {
          xml.Serialize(GetDSpin(hydra, guid, i++), Path.Combine(path, guid + ".tcf.xml"));
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

      var docW = hydra.GetReadableDocument(guid, LayernameWord).Select(x => x.ToArray()).ToArray();
      // Die folgenden Layer sind optional
      var docL = hydra.GetReadableDocument(guid, LayernameLemma)?.Select(x => x.ToArray()).ToArray();
      var docP = hydra.GetReadableDocument(guid, LayernamePos)?.Select(x => x.ToArray()).ToArray();
      var docO = hydra.GetReadableDocument(guid, "Orthografie")?.Select(x => x.ToArray()).ToArray();

      var text = new StringBuilder();
      var tokens = new List<token>();
      var lemmas = new List<lemma>();
      var tags = new List<tag>();
      var sents = new List<sentence>();
      var orthos = new List<correction>();

      var id = 1;

      for (var j = 0; j < docW.Length; j++)
      {
        var sent = new StringBuilder();
        for (var k = 0; k < docW[j].Length; k++)
        {
          var iD = "t" + id++;
          sent.AppendFormat(" {0}", iD);
          tokens.Add(new token {ID = iD, Text = new[] {docW[j][k]}});
          if (docL != null)
            lemmas.Add(new lemma {tokenIDs = iD, Text = new[] {docL[j][k]}});
          if (docP != null)
            tags.Add(new tag {tokenIDs = iD, Text = new[] {docP[j][k]}});
          if (docO != null)
            orthos.Add(new correction {tokenIDs = iD, Text = new[] {docO[j][k]}, operation = "replace"});

          if (docW[j][k].Length > 1)
            text.Append(" ");
          text.Append(docW[j][k]);
        }

        sents.Add(new sentence {tokenIDs = sent.ToString().Trim(), ID = "s" + j});
      }

      return new DSpin
      {
        MetaData = new source
        {
          source1 = new CMD
          {
            CMD1 = new CMD1
            {
              Header = new Header
              {
                MdCreator = "CorpusExplorer",
                MdProfile = $"corpusexplorer.de:guid:{guid.ToString("N")}",
                MdCollectionDisplayName = "CorpusExplorer.de",
                MdCreationDate = DateTime.Now.ToString(),
                MdSelfLink = "http://www.corpusExplorer.de"
              },
              CMDVersion = "1.2",
              Components = new teiHeader
              {
                teiHeader1 = new teiHeader1
                {
                  encodingDesc = new editorialDecl
                  {
                    editorialDecl1 = new[] {""}
                  },
                  fileDesc = new fileDesc
                  {
                    titleStmt = new titleStmt
                    {
                      author =
                        new author
                        {
                          persName = new persName {addName = from}
                        }
                    }
                  }
                }
              }
            }
          }
        },
        version = "0.4",
        TextCorpus =
          new TextCorpus
          {
            lang = CorpusLanguage,
            tokens = tokens.ToArray(),
            lemmas = docL == null ? null : lemmas.ToArray(),
            orthography = docO == null ? null : orthos.ToArray(),
            POStags = docP == null ? null : new POStags {tag = tags.ToArray(), tagset = CorpusTagset},
            sentences = sents.ToArray()
          }
      };
    }
  }
}