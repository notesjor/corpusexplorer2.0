using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma._6._0
{
  public class ExporterCatma : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      var catma = hydra.Layers.ToDictionary(layer => layer.Displayname, layer => layer.Values.ToDictionary(v => v, v => Guid.NewGuid()));
      var dt = $"{DateTime.Now:yyyy-MM-ddTHH:mm:ss}.000+0000";

      Parallel.ForEach(hydra.DocumentGuids, Configuration.ParallelOptions, dsel =>
      {
        try
        {
          var layer = hydra.GetReadableMultilayerDocument(dsel)
                          ?.ToDictionary(x => x.Key,
                                         x => x.Value.Select(y => y.ToArray()).ToArray());
          if (layer == null)
            return;

          var meta = hydra.GetDocumentMetadata(dsel) ?? new Dictionary<string, object>();
          var word = layer["Wort"];
          layer.Remove("Wort");

          var xml = new TEI
          {
            teiHeader = new teiHeader
            {
              fileDesc = new fileDesc
              {
                titleStmt =
                  new titleStmt
                  {
                    title = meta.ContainsKey("Titel") ? meta["Titel"]?.ToString() : dsel.ToString("N"),
                    author = "CorpusExplorer v2.0"
                  },
                publicationStmt = new publicationStmt { publisher = "CorpusExplorer v2.0" },
                sourceDesc = new sourceDesc
                {
                  p = meta.ContainsKey("Titel") ? meta["Titel"]?.ToString() : dsel.ToString("N"),
                  ab = new ab
                  {
                    Items = new object[]
                    {
                      new fs {id = "CATMA_TECH_DESC", f = new[] {new f {name = "version", @string = "4"}}}
                    }
                  }
                }
              },
              encodingDesc = new encodingDesc()
            }
          };

          xml.teiHeader.encodingDesc.fsdDecl =
            (from key in layer.Keys
             let hashset = new HashSet<string>(layer[key].SelectMany(s => s))
             select new fsdDecl
             {
               id = $"CATMA_{Guid.NewGuid():D}".ToUpper(),
               n = $"{key} {dt}",
               fsDecl = (from x in hashset
                         let id = $"CATMA_{catma[key][x]}".ToUpper()
                         select new fsDecl
                         {
                           fsDescr = x,
                           n = dt,
                           type = id,
                           id = id,
                           fDecl = new[]
                           {
                             new fDecl
                             {
                               id = $"CATMA_{Guid.NewGuid():D}".ToUpper(), name = "catma_markupauthor",
                               vRange = new vRange {vColl = new[] {"CorpusExplorer"}}
                             },
                             new fDecl
                             {
                               id = $"CATMA_{Guid.NewGuid():D}".ToUpper(), name = "catma_displaycolor",
                               vRange = new vRange {vColl = new[] {"-11381262"}}
                             },
                           }
                         }).ToArray()
             }).ToArray();

          var pos = 0;
          var fss = new List<fs>();
          var seg = new List<seg>();
          var spc = Configuration.Encoding.GetBytes(" ");

          using (var fs = new FileStream(Path.Combine(path, $"{dsel:D}.txt"), FileMode.Create, FileAccess.Write))
          {
            for (var i = 0; i < word.Length; i++)
            {
              for (var j = 0; j < word[i].Length; j++)
              {
                var anaBase = $"CATMA_{Guid.NewGuid():D}".ToUpper();
                var last = pos;
                var token = word[i][j];
                pos += token.Length;

                var buffer = Configuration.Encoding.GetBytes(token);
                fs.Write(buffer, 0, buffer.Length);
                seg.Add(new seg
                {
                  ana = $"#{anaBase}",
                  ptr = new ptr
                  {
                    type = "inclusion",
                    target = $"catma://CATMA_{dsel.ToString("D").ToUpper()}#char={last},{pos}"
                  }
                });

                foreach (var l in layer)
                {
                  fss.Add(new fs
                  {
                    id = anaBase,
                    type = $"CATMA_{catma[l.Key][l.Value[i][j]]:D}".ToUpper(),
                    f = new[]
                    {
                      new f { name = "catma_markupauthor", @string = "CorpusExplorer" },
                      new f { name = "catma_displaycolor", @string = "-11381262" },
                      new f { name = l.Key, @string = l.Value[i][j] },
                    }
                  });
                }

                fs.Write(spc, 0, spc.Length);
                pos++;
              }
            }
          }

          xml.text = new text
          {
            body = new body
            {
              ab = new ab
              {
                type = "catma",
                Items = seg.Select(x => (object)x).ToArray()
              }
            },
            fs = fss.ToArray()
          };

          Serializer.SerializeXmlWithDotNet(xml, Path.Combine(path, $"{dsel:D}.xml"));
        }
        catch
        {
          // ignore
        }
      });
    }
  }
}
