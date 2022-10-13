using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using Telerik.Windows.Zip;

namespace CorpusExplorer.Sdk.Extern.Xml.Txm
{
  public class ExporterTxmZip : AbstractExporter
  {
    public override void Export(IHydra hydra, string zipPath)
    {
      using (var fs = new FileStream(zipPath, FileMode.Create, FileAccess.Write))
      using (var zip = new ZipArchive(fs, ZipArchiveMode.Create, true, null))
      {
        var template = InitTemplate(hydra.LayerDisplaynames);

        int id = 0;
        foreach (var dsel in hydra.DocumentGuids)
        {
          id++;
          try
          {
            var multi =
              hydra.GetReadableMultilayerDocument(dsel)
                   .ToDictionary(x => x.Key,
                                 x => x.Value.Select(y => y.ToArray()).ToArray());

            var first = multi["Wort"];
            multi.Remove("Wort");

            var wid = 0;
            var sentences = new List<s>();
            for (var i = 0; i < first.Length; i++)
            {
              var ws = new List<object>();
              for (var j = 0; j < first[i].Length; j++)
              {
                ws.Add(new w
                {
                  id = $"w_{id:D7}_{++wid}",
                  form = first[i][j],
                  ana = multi.Select(l => new ana { type = $"#{l.Key.ToLower().Replace(" ", "")}", resp = "#txm", Text = l.Value.Length <= i ? string.Empty : l.Value[i].Length <= j ? string.Empty : l.Value[i][j] }).ToArray()
                });
              }

              sentences.Add(new s { Items = ws.ToArray() });
            }

            template.text = new text
            {
              id = id.ToString(),
              p = new[]
              {
              new p
              {
                s = sentences.ToArray()
              }
            }
            };

            var xml = XmlSerializerHelper.Serialize(template, Encoding.UTF8);

            var entry = zip.CreateEntry($"{id:D7}.xml");
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

    private TEI InitTemplate(IEnumerable<string> names)
    {
      return new TEI
      {
        teiHeader = new teiHeader
        {
          encodingDesc = new encodingDesc
          {
            appInfo = new appInfo
            {
              application = new application
              {
                ident = "TreeTagger",
                version = (decimal)3.2,
                resp = "txm",
                commandLine = new commandLine { os = new os { name = "CorpusExplorer" } },
                ab = new ab { type = "annotation", list = names.Select(name => new item { @ref = new @ref { type = "tagset", target = $"#{name.ToLower().Replace(" ", "")}" } }).ToArray() }
              }
            },
            classDecl = names.Select(name => new taxonomy { id = name.ToLower().Replace(" ", ""), bibl = new title() }).ToArray()
          }
        }
      };
    }
  }
}