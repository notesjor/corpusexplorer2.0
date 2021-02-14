using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln
{
  public class ImporterFolkerFln : AbstractImporterBase
  {
    protected override void ExecuteCall(string path)
    {
      var model = XmlSerializerHelper.Deserialize<folkertranscription>(path);

      var idx = 1;
      foreach (var contribution in model.contribution)
      {
        var guid = Guid.NewGuid();
        var meta = new Dictionary<string, object>
        {
          {"Index", idx++},
          {"Sprecher*in", contribution.speakerreference},
          {"Sprecher*in (DGD)", contribution.speakerdgdid},
          {"ID", contribution.id}
        };
        AddDocumentMetadata(guid, meta);

        var w = new List<string>();
        var l = new List<string>();
        var p = new List<string>();
        var n = new List<string>();
        foreach (var item in contribution.Items)
        {
          if (!(item is w i))
            continue;

          w.Add(string.Join(" ", i.Text).Trim());
          l.Add(i.lemma);
          p.Add(i.pos);
          n.Add(i.n);
        }

        AddDocument("Wort", guid, new[] { w.ToArray() });
        AddDocument("Lemma", guid, new[] { l.ToArray() });
        AddDocument("POS", guid, new[] { p.ToArray() });
        AddDocument("Norm", guid, new[] { n.ToArray() });
      }
    }
  }
}
