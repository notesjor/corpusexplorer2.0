#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

// ReSharper disable All

#endregion

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation
{
  public class CorpusMerger
  {
    private List<Concept> _concepts;
    private Dictionary<string, LayerValueState> _layers;
    private Dictionary<string, object> _metaCorpus;
    private Dictionary<Guid, Dictionary<string, object>> _metaDocs;

    public CorpusMerger()
    {
      Clear();
    }

    public AbstractCorpusBuilder CorpusBuilder { get; set; } = new CorpusBuilderWriteDirect();

    public ConcurrentQueue<AbstractCorpusAdapter> Output { get; set; } = new ConcurrentQueue<AbstractCorpusAdapter>();

    public void Clear()
    {
      if (_concepts != null)
        _concepts.Clear();
      if (_metaCorpus != null)
        _metaCorpus.Clear();
      if (_metaDocs != null)
        _metaDocs.Clear();
      if (_layers != null)
        _layers.Clear();

      _concepts = new List<Concept>();
      _metaCorpus = new Dictionary<string, object>();
      _metaDocs = new Dictionary<Guid, Dictionary<string, object>>();
      _layers = new Dictionary<string, LayerValueState>();
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

    public void Input(AbstractCorpusAdapter corpus)
    {
      // concepts
      if (corpus.Concepts != null && corpus.Concepts.Count() > 0)
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
        if (_layers.ContainsKey(layer.Displayname))
          Parallel.ForEach(
                           layer.DocumentGuids,
                           Configuration.ParallelOptions,
                           dsel =>
                           {
                             _layers[layer.Displayname]
                              .AddCompleteDocument(
                                                   dsel,
                                                   layer.GetReadableDocumentByGuid(dsel)
                                                        .Select(s => s.ToArray())
                                                        .ToArray());
                           });
        else
          _layers.Add(layer.Displayname, layer.ToLayerState());
    }

    public static AbstractCorpusAdapter Merge(
      IEnumerable<AbstractCorpusAdapter> corpora,
      AbstractCorpusBuilder builder = null)
    {
      var merger = new CorpusMerger();
      merger.CorpusBuilder = builder ?? new CorpusBuilderWriteDirect();
      foreach (var corpus in corpora)
      {
        merger.Input(corpus);
      }

      merger.Execute();
      return merger.Output.FirstOrDefault();
    }
  }
}