using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Bnc.Extension;
using CorpusExplorer.Sdk.Extern.Xml.Bnc.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Bnc
{
  public class ImporterBnc : AbstractImporterSimple3Steps<bncDoc>
  {
    private string _path;

    protected override bncDoc ImportStep_1_ReadFile(string path)
    {
      _path = path;
      return XmlSerializerHelper.Deserialize<bncDoc>(path);
    }

    protected override void ImportStep_2_ImportMetadata(Guid documentGuid, ref bncDoc data)
    {
      //AddDocumentMetadata(documentGuid, "Titel", ConvertToSingleLineOfText(data.teiHeader?.fileDesc?.titleStmt?.title?.Text));
      AddDocumentMetadata(documentGuid, "IDNO-BNC", data.teiHeader?.fileDesc?.publicationStmt?.idno.FirstOrDefault(x=>x.type == "bnc")?.Value?.Trim());
      AddDocumentMetadata(documentGuid, "IDNO-OLD", data.teiHeader?.fileDesc?.publicationStmt?.idno.FirstOrDefault(x => x.type == "old")?.Value?.Trim());
      
      // Text
      if (data.teiHeader?.fileDesc?.sourceDesc?.Bibl() != null)
      {
        var bibl = data.teiHeader?.fileDesc?.sourceDesc?.Bibl();
        AddDocumentMetadata(documentGuid, "Titel", bibl.title);
        AddDocumentMetadata(documentGuid, "Datum", bibl.imprint?.Date().FirstOrDefault()?.value);

        var editor = bibl.Editor();
        AddDocumentMetadata(documentGuid, "Editor", editor == null ? string.Empty : string.Join(", ", editor));
        var author = bibl.Author();
        AddDocumentMetadata(documentGuid, "Autor", author == null ? string.Empty : string.Join(", ", author));
        var publisher = bibl.imprint?.Publisher();
        AddDocumentMetadata(documentGuid, "Verlag", publisher == null ? string.Empty : string.Join(", ", publisher));
        var places = bibl.imprint?.PubPlace();
        AddDocumentMetadata(documentGuid, "Datum", places == null ? string.Empty : string.Join(", ", places));
      }

      // Recording
      if (data.teiHeader?.fileDesc?.sourceDesc?.RecordingStmt()?.recording != null)
      {
        var rec = data.teiHeader?.fileDesc?.sourceDesc?.RecordingStmt();
        var cnt = 0;
        foreach (var r in rec.recording)
        {
          AddDocumentMetadata(documentGuid, cnt == 0 ? "Datum" : $"Datum ({cnt})", r.date);
          AddDocumentMetadata(documentGuid, cnt == 0 ? "Dauer" : $"Dauer ({cnt})", r.dur);
          AddDocumentMetadata(documentGuid, cnt == 0 ? "ID" : $"ID ({cnt})", r.id);
          AddDocumentMetadata(documentGuid, cnt == 0 ? "Zeit" : $"Zeit ({cnt})", r.time);
          AddDocumentMetadata(documentGuid, cnt == 0 ? "Typ" : $"Typ ({cnt})", r.type);
        }
      }
    }

    protected override void ImportStep_3_ImportContent(Guid documentGuid, ref bncDoc data)
    {
      var xml = new HtmlDocument();
      xml.Load(_path, Encoding.UTF8);

      var sentences = xml.DocumentNode.SelectNodes("//s");
      if (sentences == null || sentences.Count == 0)
        return;

      var docW = new List<string[]>();
      var docL = new List<string[]>();
      var docP = new List<string[]>();
      var docC = new List<string[]>();
      foreach (var sentence in sentences)
      {
        var ws = sentence.Descendants("w");
        if (ws == null || !ws.Any())
          continue;

        var nsentW = new List<string>();
        var nsentL = new List<string>();
        var nsentP = new List<string>();
        var nsentC = new List<string>();

        foreach (var w in ws)
        {
          nsentW.Add(w.InnerText);
          nsentL.Add(w.GetAttributeValue("hw", string.Empty));
          nsentP.Add(w.GetAttributeValue("pos", string.Empty));
          nsentC.Add(w.GetAttributeValue("c5", string.Empty));
        }

        docW.Add(nsentW.ToArray());
        docL.Add(nsentL.ToArray());
        docP.Add(nsentP.ToArray());
        docC.Add(nsentC.ToArray());
      }

      AddDocument("Wort", documentGuid, docW.ToArray());
      AddDocument("Lemma", documentGuid, docL.ToArray());
      AddDocument("POS", documentGuid, docP.ToArray());
      AddDocument("C5", documentGuid, docC.ToArray());
    }
  }
}
