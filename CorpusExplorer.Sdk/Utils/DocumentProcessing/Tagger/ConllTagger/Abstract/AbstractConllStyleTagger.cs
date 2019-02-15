using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.ConllTagger.Abstract
{
  public abstract class AbstractConllStyleTagger : AbstractTagger
  {
    protected readonly Dictionary<string, AbstractLayerState> _layers =
      new Dictionary<string, AbstractLayerState>();

    protected readonly object _parseDocumentLock = new object();

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual string[] TaggerValueSeparator => new[] {"\t"};

    public override void Execute()
    {
      Initialize();

      var meta = ParseMetadata();

      StartTaggingProcess();

      Output.Enqueue(
                     CorpusBuilder.Create(
                                          _layers.Select(x => x.Value),
                                          meta,
                                          new Dictionary<string, object>(),
                                          null));
    }

    protected LayerRangeState AddRangeLayer(string displayname)
    {
      var res = new LayerRangeState(displayname);
      _layers.Add(displayname, res);
      return res;
    }

    protected void AddValueLayer(string displayname, int valueIndex, int minimumLength = 1)
    {
      var res = new LayerValueState(displayname, valueIndex) {MinimumDataLength = minimumLength};
      _layers.Add(displayname, res);
    }

    protected abstract string ExecuteTagger(string text);

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual void Initialize()
    {
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual void ParseDocument(string[] keys, Guid guid, ref string text)
    {
      var sentences = keys.ToDictionary(x => x, x => new List<int>());
      var document = keys.ToDictionary(x => x, x => new List<int[]>());
      var values = keys.ToDictionary(x => x, x => 0);

      var lines = text.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
      foreach (var line in lines)
      {
        // CoNLL kann Kommentare enthalten, die hiermit ausgeblendet werden.
        if (line.StartsWith("#"))
          continue;

        var entries = line.Split(TaggerValueSeparator, StringSplitOptions.RemoveEmptyEntries);
        foreach (var key in keys)
        {
          if (entries.Length == 0)
          {
            document[key].Add(sentences[key].ToArray());
            sentences[key].Clear();
            values[key] = 0;
            continue;
          }

          // CoNLL kann umspannende Tokens enthalten - markiert durch einen Bindestrich zwischen den Indices
          // Bsp.:
          // 3-4 token
          // Diese werden ausgeblendet.
          if (entries[0].Contains("-"))
            continue;

          lock (_parseDocumentLock)
          {
            if (_layers[key].AllowValueChange(entries))
              values[key] = _layers[key].RequestIndex(entries, values[key]);

            if (_layers[key].AllowAnnotation(entries))
              sentences[key].Add(values[key]);
          }
        }
      }

      foreach (var sent in sentences)
        if (sent.Value.Count > 0)
          document[sent.Key].Add(sent.Value.ToArray());

      lock (_parseDocumentLock)
      {
        foreach (var x in document)
          _layers[x.Key].Documents.Add(guid, x.Value.ToArray());
      }
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual string TextPostTaggerCleanup(string text)
    {
      return text;
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual string TextPreTaggerCleanup(string text)
    {
      return text;
    }

    private Dictionary<Guid, Dictionary<string, object>> ParseMetadata()
    {
      var meta = new ConcurrentDictionary<Guid, Dictionary<string, object>>();

      Parallel.ForEach(
                       Input,
                       Configuration.ParallelOptions,
                       sdm =>
                       {
                         var dic = sdm.GetMetaDictionary().ToDictionary(entry => entry.Key, entry => entry.Value);
                         var guid = sdm.Get("GUID", Guid.NewGuid());
                         dic.Add("GUID", guid);
                         meta.TryAdd(guid, dic);
                       });

      return meta.ToDictionary(x => x.Key, x => x.Value);
    }

    private void StartTaggingProcess()
    {
      // Gibt die Layer (Namen) in der korrekten Reihenfolge vor.
      var layerKeys = _layers.Select(x => x.Key).ToArray();

      while (Input.Count > 0)
      {
        var count = Input.Count;
        while (count > 0)
        {
          Parallel.For(
                       0,
                       count,
                       Configuration.ParallelOptions,
                       i =>
                       {
                         try
                         {
                           Dictionary<string, object> doc;
                           if (!Input.TryDequeue(out doc))
                             return;

                           // Tagger
                           var parsedDoc =
                             TextPostTaggerCleanup(ExecuteTagger(TextPreTaggerCleanup(doc["Text"] as string)));
                           ParseDocument(layerKeys, doc.Get("GUID", Guid.NewGuid()), ref parsedDoc);
                         }
                         catch (Exception ex)
                         {
                           // ignore
                         }
                       });
          count = Input.Count;
        }
      }
    }
  }
}