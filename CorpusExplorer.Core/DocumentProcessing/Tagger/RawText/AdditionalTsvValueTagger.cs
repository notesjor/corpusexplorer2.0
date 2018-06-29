using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Core.DocumentProcessing.Tagger.RawText
{
  public class AdditionalTsvValueTagger : AbstractAdditionalTagger
  {
    private string _layer;
    private Dictionary<string, string> _values;
    public override string DisplayName => "Zusätzlicher TSV-Werttabellen Tagger";

    public string LayerDisplayname { get; set; } = "TSV-Tagger";
    public string LineSeparator { get; set; } = "\r\n";
    public string ValueSeparator { get; set; } = "\t";

    protected override void Cleanup()
    {
    }

    protected override IEnumerable<AbstractLayerState> ExecuteCall(ref AbstractCorpusAdapter corpus)
    {
      // Annotiere
      var oldLayer = corpus.GetLayers(_layer).FirstOrDefault();
      if (oldLayer == null)
        return null;

      if (string.IsNullOrEmpty(LayerDisplayname))
        LayerDisplayname = Path.GetFileNameWithoutExtension(ModelPath);

      var layerState = new LayerValueState(LayerDisplayname, 0);

      foreach (var dsel in oldLayer.DocumentGuids)
      {
        var doc = oldLayer[dsel];
        var ndoc = new string[doc.Length][];
        for (var i = 0; i < doc.Length; i++)
        {
          ndoc[i] = new string[doc[i].Length];
          for (var j = 0; j < doc[i].Length; j++)
          {
            var key = oldLayer[doc[i][j]];
            ndoc[i][j] = _values.ContainsKey(key) ? _values[key] : string.Empty;
          }
        }

        layerState.AddCompleteDocument(dsel, ndoc);
      }

      return new[] {layerState};
    }

    protected override void Initialize()
    {
      var lines = File.ReadAllLines(ModelPath, Configuration.Encoding);

      // Rufe Kopfdaten ab
      var head =
        lines[0].Split(new[] {ValueSeparator}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
      if (head.Length != 2)
        return;

      // Erste Spalte ist der Layer, der durchsucht werden soll (muss im Input-Korpus vorhanden sein).
      _layer = head[0];

      // Ermittel Werte
      _values = new Dictionary<string, string>();
      for (var i = 1; i < lines.Length; i++)
      {
        var items =
          lines[i].Split(new[] {ValueSeparator}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
        if (!_values.ContainsKey(items[0]))
          _values.Add(items[0], items[1]);
      }
    }
  }
}