using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using DotNetKorAPClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Terminal.WinForm.Forms.KorAP
{
  public class KorapApiImporter : AbstractImporterBase
  {
    protected override void ExecuteCall(string path)
    {
      throw new NotImplementedException();
    }

    public AbstractCorpusAdapter BypassData(IEnumerable<MatchInfo> data)
    {
      foreach (var x in data)
      {
        var guid = Guid.NewGuid();

        base.AddDocumentMetadata(guid, new Dictionary<string, object>
        {
          { "Autor", x.Author },
          { "Titel", x.Title },
          { "Datum", x.Date },
          { "Ort", x.PubPlace },
          { "Korpus", x.Corpus },
          { "Korpus-Teil", x.Document },
          { "Dokument-Nr", x.Text },
          { "Sigle", x.Sigle },
        });

        var layers = new Dictionary<string, List<string>>();
        foreach(var p in x.LayerData)
        {
          foreach (var f in p)
          {
            foreach (var l in f.Value)
            {
              var key = $"{f.Key}_{l.Key}";
              if (!layers.ContainsKey(key))
                layers.Add(key, new List<string>());
              layers[key].Add(l.Value);
            }
          }
        }

        var w = layers["-_-"];
        AddDocument("Wort", guid, new[] { w.ToArray() });

        layers.Remove("-_-");
        foreach (var l in layers)
          AddDocument(FixLayerNames(l.Key), guid, new[] { l.Value.ToArray() });
      }

      var corpus = base.BuildCorpus(false).FirstOrDefault();
      corpus.SetCorpusMetadata("[PROTECTION]", "NOEXPORT");

      return corpus;
    }

    private Dictionary<string, string> _layerNameFixes = new Dictionary<string, string>
    {
      { "tt_l", "Lemma" },
      { "tt_p", "POS" }
    };

    private string FixLayerNames(string key)
    {
      if(_layerNameFixes.ContainsKey(key))
        return _layerNameFixes[key];
      return key;
    }
  }
}
