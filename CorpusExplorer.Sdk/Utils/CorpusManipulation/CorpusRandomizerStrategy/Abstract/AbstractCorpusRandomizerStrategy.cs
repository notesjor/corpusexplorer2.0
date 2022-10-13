using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy.Abstract
{
  public abstract class AbstractCorpusRandomizerStrategy
  {
    private List<Concept> _concepts = new List<Concept>();
    private Dictionary<string, object> _metaCorpus = new Dictionary<string, object>();
    private Dictionary<Guid, Dictionary<string, object>> _metaDocs = new Dictionary<Guid, Dictionary<string, object>>();
    private Dictionary<string, LayerValueState> _layers = new Dictionary<string, LayerValueState>();

    public void Input(AbstractCorpusAdapter corpus)
    {
      // concepts
      if (corpus.Concepts != null && corpus.Concepts.Any())
        _concepts.AddRange(corpus.Concepts);

      // metaCorpus
      var cmeta = corpus.GetCorpusMetadata();
      if (cmeta != null)
        foreach (var meta in cmeta)
          if (!_metaCorpus.ContainsKey(meta.Key))
            _metaCorpus.Add(meta.Key, meta.Value);
      
      // metaDocs
      var dmeta = corpus.DocumentMetadata;
      if (dmeta != null)
        foreach (var meta in dmeta)
          if (!_metaDocs.ContainsKey(meta.Key))
            _metaDocs.Add(meta.Key, meta.Value);

      // layers
      foreach (var layer in corpus.Layers)
      {
        if (!_layers.ContainsKey(layer.Displayname))
          _layers.Add(layer.Displayname, layer.ToLayerState(clearDictionary: true, noDocuments: true));

        Parallel.ForEach(
          corpus.DocumentGuids,
          Configuration.ParallelOptions,
          dsel =>
          {
            _layers[layer.Displayname]
              .AddCompleteDocument(
                dsel, RandomizeDocument(layer.GetReadableDocumentByGuid(dsel)));
          });
      }
    }

    public void Execute()
    {
      Output =
        new ConcurrentQueue<AbstractCorpusAdapter>(
          CorpusBuilder.Create(
            _layers.Select(x => x.Value),
            _metaDocs,
            _metaCorpus,
            _concepts));
    }

    public AbstractCorpusBuilder CorpusBuilder { get; set; } = new CorpusBuilderWriteDirect();

    public ConcurrentQueue<AbstractCorpusAdapter> Output { get; set; } = new ConcurrentQueue<AbstractCorpusAdapter>();

    protected abstract string[][] RandomizeDocument(IEnumerable<IEnumerable<string>> doc);
  }
}
