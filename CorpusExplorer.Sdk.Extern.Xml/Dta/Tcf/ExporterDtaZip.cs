#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using Telerik.Windows.Zip;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf
{
  public class ExporterDtaZip : AbstractExporter
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

    public override void Export(IHydra hydra, string zipPath)
    { 
      using (var fs = new FileStream(zipPath, FileMode.Create, FileAccess.Write))
      using (var zip = ZipArchive.Create(fs))
      {
        foreach (var guid in hydra.DocumentGuids)
        {
          try
          {
            var xml = XmlSerializerHelper.Serialize(GetDSpin(hydra, guid), Encoding.UTF8);
            var entry = zip.CreateEntry($"{guid:N}.tcf.xml");
            using (var writer = new StreamWriter(entry.Open(), Encoding.UTF8))
              writer.Write(xml);
          }
          catch
          {
            // ignore
          }
        }
      }
    }

    private DSpin GetDSpin(IHydra hydra, Guid guid)
    {
      var meta = hydra.GetDocumentMetadata(guid);

      var from = meta != null && meta.ContainsKey(MetanameAuthor)
        ? meta[MetanameAuthor].ToString()
        : UnknownPropertyValue;
      var datum = meta != null && meta.ContainsKey(MetanameDate)
        ? meta[MetanameDate] is DateTime
          ? ((DateTime)meta[MetanameDate]).ToString("yyyy-MM-dd")
          : meta[MetanameDate].ToString()
        : UnknownDateValue;

      var docW = hydra.GetReadableDocument(guid, LayernameWord).Select(x => x.ToArray()).ToArray();
      // Die folgenden Layer sind optional
      var docL = hydra.GetReadableDocument(guid, LayernameLemma)?.Select(x => x.ToArray()).ToArray();
      var docP = hydra.GetReadableDocument(guid, LayernamePos)?.Select(x => x.ToArray()).ToArray();
      var docO = hydra.GetReadableDocument(guid, "Orthografie")?.Select(x => x.ToArray()).ToArray();

      var text = new StringBuilder();
      var tokens = new List<TextCorpusToken>();
      var lemmas = new List<TextCorpusLemma>();
      var tags = new List<TextCorpusPOStagsTag>();
      var sents = new List<TextCorpusSentence>();
      var orthos = new List<TextCorpusCorrection>();

      var id = 1;

      for (var j = 0; j < docW.Length; j++)
      {
        var sent = new StringBuilder();
        for (var k = 0; k < docW[j].Length; k++)
        {
          var iD = "t" + id++;
          sent.AppendFormat(" {0}", iD);
          tokens.Add(new TextCorpusToken { ID = iD, Value = docW[j][k] });
          if (docL != null)
            lemmas.Add(new TextCorpusLemma { tokenIDs = iD, Value = docL[j][k] });
          if (docP != null)
            tags.Add(new TextCorpusPOStagsTag { tokenIDs = iD, Value = docP[j][k] });
          if (docO != null)
            orthos.Add(new TextCorpusCorrection { tokenIDs = iD, Value = docO[j][k], operation = "replace" });

          if (docW[j][k].Length > 1)
            text.Append(" ");
          text.Append(docW[j][k]);
        }

        sents.Add(new TextCorpusSentence { tokenIDs = sent.ToString().Trim(), ID = "s" + j });
      }

      return new DSpin
      {
        MetaData = new MetaData
        {
          source = new MetaDataSource
          {
            CMD = new CMD
            {
              Header = new CMDHeader
              {
                MdCreator = "CorpusExplorer",
                MdProfile = $"corpusexplorer.de:guid:{guid.ToString("N")}",
                MdCollectionDisplayName = "CorpusExplorer.de",
                MdCreationDate = DateTime.Now,
                MdSelfLink = "http://www.corpusExplorer.de"
              },
              CMDVersion = 1.1m,
              Components = new CMDComponents
              {
                teiHeader = new CMDComponentsTeiHeader
                {
                  encodingDesc = new CMDComponentsTeiHeaderEncodingDesc
                  {
                    editorialDecl = new CMDComponentsTeiHeaderEncodingDescEditorialDecl { p = "" }
                  },
                  fileDesc = new CMDComponentsTeiHeaderFileDesc
                  {
                    titleStmt = new CMDComponentsTeiHeaderFileDescTitleStmt
                    {
                      author =
                        new CMDComponentsTeiHeaderFileDescTitleStmtAuthor
                        {
                          persName = new CMDComponentsTeiHeaderFileDescTitleStmtAuthorPersName { surname = from }
                        }
                    }
                  }
                }
              }
            }
          }
        },
        version = (decimal)2.0,
        TextCorpus =
          new TextCorpus
          {
            lang = CorpusLanguage,
            tokens = tokens.ToArray(),
            lemmas = docL == null ? null : lemmas.ToArray(),
            orthography = docO == null ? null : orthos.ToArray(),
            POStags = docP == null ? null : new TextCorpusPOStags { tag = tags.ToArray(), tagset = CorpusTagset },
            sentences = sents.ToArray()
          }
      };
    }
  }
}