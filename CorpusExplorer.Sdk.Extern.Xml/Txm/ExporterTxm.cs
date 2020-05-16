using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Model;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Serializer;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Txm
{
  public class ExporterTxm : AbstractExporter
  {
    private TEI _template;
    private object _templateLock = new object();
    private int _docCount = 0;
    private object _docCountLock = new object();
    private TxmSerializer _serialier = new TxmSerializer();

    public override void Export(IHydra hydra, string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      lock (_templateLock)
        if (_template == null)
          InitTemplate(hydra.LayerDisplaynames);

      int id;
      foreach (var dsel in hydra.DocumentGuids)
      {
        lock (_docCountLock)
          id = _docCount++;

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
          for (int j = 0; j < first[i].Length; j++)
          {
            ws.Add(new w
            {
              id = $"w_{id}_{++wid}",
              form = first[i][j],
              ana = multi.Select(l => new ana { type = $"#{l.Key.ToLower().Replace(" ", "")}", resp = "#txm", Text = l.Value.Length <= i ? string.Empty : l.Value[i].Length <= j ? string.Empty : l.Value[i][j] }).ToArray()
            });
          }

          sentences.Add(new s { Items = ws.ToArray() });
        }

        lock (_templateLock)
        {
          var tei = _template;
          tei.text = new text
          {
            id = id.ToString(),
            p = new p[]
            {
              new p
              {
                s = sentences.ToArray()
              }
            }
          };
          _serialier.Serialize(tei, Path.Combine(path, $"{id:D5}.xml"));
        }
      }
    }

    private void InitTemplate(IEnumerable<string> names)
    {
      _template = new TEI
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