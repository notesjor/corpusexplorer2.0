using System;
using System.Collections.Generic;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.RawText;
using CorpusExplorer.Sdk.Utils.ReMapper;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Speedy
{
  public class ImporterSpeedy : AbstractImporter
  {
    public AbstractCorpusBuilder CorpusBuilder { get; set; } = new CorpusBuilderWriteDirect();

    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      var model = JsonConvert.DeserializeObject<Model.Speedy>(FileIO.ReadText(importFilePath));
      if (model == null || string.IsNullOrEmpty(model.Text))
        return null;

      var tagger = new RawTextTagger();
      tagger.Input.Enqueue(new Dictionary<string, object> {{"Text", model.Text}});
      tagger.Execute();

      if (!tagger.Output.TryDequeue(out var corpus))
        return null;

      var dsel = corpus.DocumentGuids.First();
      var layer = corpus.GetLayers("Wort").First();
      var doc = layer[dsel];

      var idxs = new ReMapperStandoff().ExtractAlignment(model.Text, doc, layer).ToArray();
      var nLayers = new HashSet<string>(model.Properties.Select(x => x.Type)); // Eindeutige Layer-Namen
      var addLayers = new List<AbstractLayerState>(new[] {layer.ToLayerState()});
      var dmeta = new Dictionary<string, object> {{"Datei", importFilePath}};

      foreach (var n in nLayers)
      {
        var aLayer = layer.ToLayerState(n, addLayers.Count + 1, true, true);
        var fDoc = aLayer.Documents.First();
        var aDoc = fDoc.Value.Select(x => x.Select(_ => "-null-").ToArray()).ToArray(); // Erzeuge leeres Dokument - Muss ggf. auch im Exporter geändert werden.

        foreach (var a in model.Properties.Where(x => x.Type == n))
        {
          if (a.EndIndex == -1)
          {
            if (a.StartIndex == -1 && !dmeta.ContainsKey(a.Type)) // MEtadaten - Kein Start/End-Tag
              dmeta.Add(a.Type, a.Value); // Erfasst nur Metadaten - keine Fußnoten
            continue;
          }

          var pos = (from x in idxs where x.Item4 >= a.StartIndex && x.Item3 <= a.EndIndex select x).ToArray();
          if (pos.Length == 0)
            continue;

          foreach (var x in pos)
            aDoc[x.Item1][x.Item2] = a.Value ?? "";
        }

        aLayer.ChangeCompleteDocument(fDoc.Key, aDoc);
        addLayers.Add(aLayer);
      }

      return CorpusBuilder.Create(addLayers,
                                  new Dictionary<Guid, Dictionary<string, object>>
                                    {{dsel, dmeta}},
                                  new Dictionary<string, object>(), null);
    }
  }
}