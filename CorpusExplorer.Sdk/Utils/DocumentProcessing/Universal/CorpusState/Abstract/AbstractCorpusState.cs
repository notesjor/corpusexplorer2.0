using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.Delegate;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.LayerState;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.LayerState.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.CorpusState.Abstract
{
  public abstract class AbstractCorpusState : AbstractDocumentProcessingStep<AbstractCorpusAdapter>
  {
    private readonly Dictionary<string, AbstractLayerState> _layers =
      new Dictionary<string, AbstractLayerState>();
    
    public CorpusBuildDelegate BuildDelegate { get; set; } = PredefinedCorpusBuildDelegates.BuildSingleFileCorpus;

    public override AbstractCorpusAdapter Execute()
    {
      if (!IsReady)
        return null;

      Initialize();

      return BuildDelegate(CorpusName, _layers, ExecuteCall());
    }

    protected abstract Dictionary<Guid, Dictionary<string, object>> ExecuteCall();

    protected abstract void Initialize();

    public string CorpusName { get; set; }

    protected LayerRangeState AddRangeLayer(string displayname)
    {
      var res = new LayerRangeState(displayname);
      _layers.Add(displayname, res);
      return res;
    }

    protected void AddValueLayer(string displayname, int valueIndex, int minimumLength = 1)
    {
      var res = new LayerValueState(displayname, valueIndex) { MinimumDataLength = minimumLength };
      _layers.Add(displayname, res);
    }

    protected abstract bool IsEndOfSentence(string[] data);

    protected void ParseDocument(Guid guid, ref string text)
    {
      var sentences = _layers.ToDictionary(x => x.Key, x => new List<int>());
      var document = _layers.ToDictionary(x => x.Key, x => new List<int[]>());
      var values = _layers.ToDictionary(x => x.Key, x => 0);
      var layers = _layers.Select(x => x.Key).ToArray();

      // Pickt exakt ein Token / Wert heraus
      var tokens = ParseDocument_GetTokens(text);
      foreach (var token in tokens)
      {
        // Isoliert alle Werte 
        var data = ParseDocument_GetAllTokenValues(token);
        foreach (var layer in layers)
        {
          if (_layers[layer].AllowValueChange(data))
            values[layer] = _layers[layer].RequestIndex(data, values[layer]);

          if (_layers[layer].AllowAnnotation(data))
            sentences[layer].Add(values[layer]);

          // ReSharper disable once InvertIf
          if (IsEndOfSentence(data))
          {
            document[layer].Add(sentences[layer].ToArray());
            sentences[layer].Clear();
            values[layer] = 0;
          }
        }
      }

      foreach (var s in sentences)
        document[s.Key].Add(s.Value.ToArray());

      foreach (var x in document)
        _layers[x.Key].Documents.Add(guid, x.Value.ToArray());
    }

    protected abstract string[] ParseDocument_GetAllTokenValues(string token);

    protected abstract IEnumerable<string> ParseDocument_GetTokens(string text);
  }
}
