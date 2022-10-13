using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Extension;
using CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8
{
  public class ImporterCoraXml08 : AbstractImporterBase
  {
    protected override void ExecuteCall(string path)
    {
      var doc = XmlSerializerHelper.Deserialize<text>(path);
      var dsel = Guid.NewGuid();

      GetMetadata(path, doc, dsel);

      var sWort = new List<string[]>();
      var sLemmaS = new List<string[]>();
      var sLemma = new List<string[]>();
      var sPos = new List<string[]>();
      var sMorph = new List<string[]>();

      var cWort = new List<string>();
      var cLemmaS = new List<string>();
      var cLemma = new List<string>();
      var cPos = new List<string>();
      var cMorph = new List<string>();

      foreach (var token in doc.GetToken())
      {
        foreach (var anno in token.anno)
        {
          cWort.Add(anno.utf);
          cLemmaS.Add(anno.GetSimpleLemmas().FirstOrDefault()?.tag);
          cLemma.Add(anno.GetLemmas().FirstOrDefault()?.tag);
          cPos.Add(anno.GetPos().FirstOrDefault()?.tag);
          cMorph.Add(anno.GetMorphs().FirstOrDefault()?.tag);
        }

        var boundSent = token.anno.LastOrDefault()?.GetBoundSent().FirstOrDefault()?.tag;
        if (!string.IsNullOrEmpty(boundSent))
        {
          sWort.Add(cWort.ToArray());
          sLemmaS.Add(cLemmaS.ToArray());
          sLemma.Add(cLemma.ToArray());
          sPos.Add(cPos.ToArray());
          sMorph.Add(cMorph.ToArray());

          cWort.Clear();
          cLemmaS.Clear();
          cLemma.Clear();
          cPos.Clear();
          cMorph.Clear();
        }
      }

      if (cWort.Count != 0)
      {
        sWort.Add(cWort.ToArray());
        sLemmaS.Add(cLemmaS.ToArray());
        sLemma.Add(cLemma.ToArray());
        sPos.Add(cPos.ToArray());
        sMorph.Add(cMorph.ToArray());
      }

      AddDocument("Wort", dsel, sWort.ToArray());
      AddDocument("Lemma (S)", dsel, sLemmaS.ToArray());
      AddDocument("Lemma", dsel, sLemma.ToArray());
      AddDocument("POS", dsel, sPos.ToArray());
      AddDocument("MORPH", dsel, sMorph.ToArray());
    }

    private void GetMetadata(string path, text doc, Guid dsel)
    {
      var meta = new Dictionary<string, object>
      {
        {"Dateiname", Path.GetFileName(path)},
        {"ID", doc.id},
        {"CHname", doc.coraheader?.name},
        {"CHsigle", doc.coraheader?.sigle},
      };

      var header = doc.header;
      if (header != null)
      {
        var lines = header.Split(Splitter.LineBreaks, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
          var idx = line.IndexOf(':');
          if (idx == -1)
            continue;

          var key = line.Substring(0, idx);
          if (key == "text")
            key = "Titel";

          var val = line.Substring(idx + 1);

          if (!meta.ContainsKey(key))
            meta.Add(key, val);
        }
      }

      AddDocumentMetadata(dsel, meta);
    }
  }
}
