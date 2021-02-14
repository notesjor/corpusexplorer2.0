using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.CoraXml._1._0.Extension;
using CorpusExplorer.Sdk.Extern.Xml.CoraXml._1._0.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._1._0
{
  public class ImporterCoraXml10 : AbstractImporterBase
  {
    protected override void ExecuteCall(string path)
    {
      var doc = XmlSerializerHelper.Deserialize<text>(path);
      var dsel = Guid.NewGuid();

      GetMetadata(path, doc, dsel);
      
      var sWort = new List<string[]>();
      var sNorm = new List<string[]>();
      var sLemma = new List<string[]>();
      var sPos = new List<string[]>();
      var sInfl = new List<string[]>();
      var sInflClass = new List<string[]>();

      var cWort = new List<string>();
      var cNorm = new List<string>();
      var cLemma = new List<string>();
      var cPos = new List<string>();
      var cInfl = new List<string>();
      var cInflClass = new List<string>();

      foreach (var token in doc.GetToken())
      {
        if (token.type == "punc")
        {
          cWort.Add(token.tok_anno.First().utf);
          cNorm.Add(token.tok_anno.First().utf);
          cLemma.Add(token.tok_anno.First().utf);
          cPos.Add(token.tok_anno.First().utf);
          cInfl.Add(token.tok_anno.First().utf);
          cInflClass.Add(token.tok_anno.First().utf);

          sWort.Add(cWort.ToArray());
          sNorm.Add(cNorm.ToArray());
          sLemma.Add(cLemma.ToArray());
          sPos.Add(cPos.ToArray());
          sInfl.Add(cInfl.ToArray());
          sInflClass.Add(cInflClass.ToArray());

          cWort.Clear();
          cNorm.Clear();
          cLemma.Clear();
          cPos.Clear();
          cInfl.Clear();
          cInflClass.Clear();

          continue;
        }

        foreach (var anno in token.tok_anno)
        {
          cWort.Add(anno.utf);
          cNorm.Add(anno.norm?.tag);
          cLemma.Add(anno.lemma?.tag);
          cPos.Add(anno.pos?.tag);
          cInfl.Add(anno.infl?.tag);
          cInflClass.Add(anno.inflClass?.tag);
        }
      }

      if (cWort.Count != 0)
      {
        sWort.Add(cWort.ToArray());
        sNorm.Add(cNorm.ToArray());
        sLemma.Add(cLemma.ToArray());
        sPos.Add(cPos.ToArray());
        sInfl.Add(cInfl.ToArray());
        sInflClass.Add(cInflClass.ToArray());
      }

      AddDocument("Wort", dsel, sWort.ToArray());
      AddDocument("Norm", dsel, sNorm.ToArray());
      AddDocument("Lemma", dsel, sLemma.ToArray());
      AddDocument("POS", dsel, sPos.ToArray());
      AddDocument("INFL", dsel, sInfl.ToArray());
      AddDocument("INFL-CLASS", dsel, sInflClass.ToArray());
    }

    private void GetMetadata(string path, text doc, Guid dsel)
    {
      var meta = new Dictionary<string, object>
      {
        {"Dateiname", Path.GetFileName(path)}, {"ID", doc.id}
      };

      var header = doc.GetHeader().FirstOrDefault();
      if (header != null)
      {
        meta.Add("Titel", header.text);
        meta.Add("Thema", header.topic);
        meta.Add("Genre", header.genre);
        meta.Add("Referenz 1", header.reference);
        meta.Add("Referenz 2", header.referencesecondary);
        meta.Add("Bibliothek", header.library);
        meta.Add("Bibliothek Index", header.libraryshelfmark);
        meta.Add("URL", header.online);
        meta.Add("Medium", header.medium);
        meta.Add("Sprache", header.language);
        meta.Add("Sprache (Typ)", header.languagetype);
        meta.Add("Sprache (Region)", header.languageregion);
        meta.Add("Sprache (Unterregion)", header.languagearea);
        meta.Add("Zeit", header.time);
        meta.Add("Datum", header.date);
        meta.Add("Ort", header.textplace);
        meta.Add("Autor", header.textauthor);
        meta.Add("Quelle", header.textsource);
        meta.Add("Edition", header.edition);
        meta.Add("Korpus", header.corpus);
      }

      AddDocumentMetadata(dsel, meta);
    }
  }
}
