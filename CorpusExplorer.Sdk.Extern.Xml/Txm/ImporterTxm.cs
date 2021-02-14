using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Extension;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Txm
{
  public class ImporterTxm : AbstractImporterSimple3Steps<TEI>
  {
    protected override TEI ImportStep_1_ReadFile(string path)
    {
      return XmlSerializerHelper.Deserialize<TEI>(path);
    }

    protected override void ImportStep_2_ImportMetadata(Guid documentGuid, ref TEI data)
    {
      // Keine Metadaten
    }

    protected override void ImportStep_3_ImportContent(Guid documentGuid, ref TEI data)
    {
      var txtW = new List<string[]>();
      var txtL = new List<string[]>();
      var txtP = new List<string[]>();

      var senW = new List<string>();
      var senL = new List<string>();
      var senP = new List<string>();

      foreach (p p in data.text.p)
        foreach (var s in p.s)
        {
          foreach (var w in s.GetW())
          {
            senW.Add(w.form);
            senL.Add(w.ana.FirstOrDefault(x => x.type.EndsWith("lemma"))?.Text);
            senP.Add(w.ana.FirstOrDefault(x => x.type.EndsWith("pos"))?.Text);
          }

          txtW.Add(senW.ToArray());
          txtL.Add(senL.ToArray());
          txtP.Add(senP.ToArray());

          senW.Clear();
          senL.Clear();
          senP.Clear();
        }

      AddDocument("Wort", documentGuid, txtW.ToArray());
      AddDocument("Lemma", documentGuid, txtL.ToArray());
      AddDocument("POS", documentGuid, txtP.ToArray());
    }
  }
}