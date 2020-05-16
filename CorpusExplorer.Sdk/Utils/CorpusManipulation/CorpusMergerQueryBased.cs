using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation
{
  public class CorpusMergerQueryBased
  {
    private List<Concept> _concepts;
    private Dictionary<string, LayerValueState> _layers;
    private Dictionary<string, object> _metaCorpus;
    private Dictionary<Guid, Dictionary<string, object>> _metaDocs;

    public CorpusMergerQueryBased()
    {
      Clear();
    }

    public AbstractCorpusBuilder CorpusBuilder { get; set; } = new CorpusBuilderWriteDirect();

    public AbstractFilterQuery[] FilterQueries { get; set; }

    public ConcurrentQueue<AbstractCorpusAdapter> Output { get; set; } = new ConcurrentQueue<AbstractCorpusAdapter>();

    public void Clear()
    {
      _concepts?.Clear();
      _metaCorpus?.Clear();
      _metaDocs?.Clear();
      _layers?.Clear();

      _concepts = new List<Concept>();
      _metaCorpus = new Dictionary<string, object>();
      _metaDocs = new Dictionary<Guid, Dictionary<string, object>>();
      _layers = new Dictionary<string, LayerValueState>();

      CurrentCountDocuments = 0;
      CurrentCountToken = 0;

      GC.Collect();
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

    public int CurrentCountToken { get; set; } = 0;
    public int CurrentCountDocuments { get; set; } = 0;

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

      // selection
      var selection = corpus.ToSelection().CreateTemporary(FilterQueries);
      CurrentCountToken += selection.CountToken;
      CurrentCountDocuments += selection.CountDocuments;
      
      // metaDocs
      var dmeta = selection.DocumentMetadata;
      if (dmeta != null)
        foreach (var meta in dmeta)
          if (!_metaDocs.ContainsKey(meta.Key))
            _metaDocs.Add(meta.Key, meta.Value);

      // layers
      foreach (var layer in selection.Layers)
      {
        if (!_layers.ContainsKey(layer.Displayname))
          _layers.Add(layer.Displayname, layer.ToLayerState(clearDictionary: true, noDocuments: true));

        Parallel.ForEach(
                         selection.DocumentGuids,
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
      }
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