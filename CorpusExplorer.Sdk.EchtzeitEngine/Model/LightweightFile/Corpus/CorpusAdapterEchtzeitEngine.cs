using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Corpus.Model;
using CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Layer;
using CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Layer.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Corpus
{
  public class CorpusAdapterEchtzeitEngine : AbstractCorpusAdapter
  {
    private readonly EchtzeitCorpus _corpus;
    private readonly Dictionary<Guid, LayerAdapterEchtzeitEngine> _layers;

    private CorpusAdapterEchtzeitEngine()
    {
    }

    private CorpusAdapterEchtzeitEngine(EchtzeitCorpus corpus)
    {
      _corpus = corpus;
      _layers = _corpus.Layers.ToDictionary(x => x.Guid, LayerAdapterEchtzeitEngine.Create);
    }

    public override IEnumerable<Concept> Concepts => null;

    public override string CorpusDisplayname
    {
      get => _corpus.Displayname;
      set => _corpus.Displayname = value;
    }

    public override Guid CorpusGuid => _corpus.Guid;

    public override IEnumerable<Guid> DocumentGuids
    {
      get { yield return _corpus.Guid; }
    }

    public override IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata
      => new Dictionary<Guid, Dictionary<string, object>> {{_corpus.Guid, _corpus.Metadata}};

    public override Guid FirstDocument => _corpus.Guid;
    public override IEnumerable<string> LayerDisplaynames => _layers.Select(x => x.Value.Displayname);

    public override IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames
      => _layers.ToDictionary(x => x.Value.Guid, x => x.Value.Displayname);

    public override IEnumerable<Guid> LayerGuids => _layers.Select(x => x.Key);

    public override IEnumerable<AbstractLayerAdapter> Layers => _layers.Values;

    public override IEnumerable<string> LayerUniqueDisplaynames
      => new HashSet<string>(_layers.Select(x => x.Value.Displayname));

    public override bool UseCompression => false;

    public override void AddConcept(Concept concept)
    {
    }

    public override void AddLayer(AbstractLayerAdapter layer)
    {
      if (!(layer is LayerAdapterEchtzeitEngine))
        throw new TypeLoadException("Der layer muss vom Typ LayerAdapterEchtzeitEngine sein.");
      var lalf = (LayerAdapterEchtzeitEngine) layer;
      _layers.Add(lalf.Guid, lalf);
    }

    public override bool ContainsDocument(Guid documentGuid)
    {
      return documentGuid == _corpus.Guid;
    }

    public override bool ContainsLayer(Guid layerGuid)
    {
      return _layers.Any(x => x.Value.Guid == layerGuid);
    }

    public override bool ContainsLayer(string layerDisplayname)
    {
      return _layers.Any(x => x.Value.Displayname == layerDisplayname);
    }

    public static CorpusAdapterEchtzeitEngine Create(
      string displayName,
      Dictionary<string, object> documentMetadata,
      Guid corpusGuid)
    {
      var res = new CorpusAdapterEchtzeitEngine(
        new EchtzeitCorpus
        {
          Displayname = displayName,
          Metadata = documentMetadata,
          Guid = corpusGuid,
          Layers = new List<EchtzeitLayer>()
        });
      return res;
    }

    public static AbstractCorpusAdapter Create(string path)
    {
      return new CorpusAdapterEchtzeitEngine(Serializer.Deserialize<EchtzeitCorpus>(path)) {CorpusPath = path};
    }

    public override IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example)
    {
      return example.Any(x => !_corpus.Metadata.ContainsKey(x.Key) || !_corpus.Metadata[x.Key].Equals(x.Value))
        ? new Guid[0]
        : new[] {_corpus.Guid};
    }

    public override AbstractCorpusBuilder GetCorpusBuilder()
    {
      return new CorpusBuilderLightweightSingleFile();
    }

    public override IEnumerable<KeyValuePair<string, object>> GetCorpusMetadata()
    {
      return _corpus.Metadata;
    }

    public override int GetDocumentLengthInSentences(Guid documentGuid)
    {
      return documentGuid == _corpus.Guid ? _layers.FirstOrDefault().Value._layer.Document.Length : 0;
    }

    public override int GetDocumentLengthInWords(Guid documentGuid)
    {
      return documentGuid == _corpus.Guid ? _layers.FirstOrDefault().Value._layer.Document.Sum(s => s.Length) : 0;
    }

    public override Dictionary<string, object> GetDocumentMetadata(Guid documentGuid)
    {
      return documentGuid == _corpus.Guid ? _corpus.Metadata : null;
    }

    public override Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype()
    {
      return _corpus.Metadata.ToDictionary(x => x.Key, x => new HashSet<object> {x.Value});
    }

    public override IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties()
    {
      return _corpus.Metadata.Keys;
    }

    public override IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
    {
      return _corpus.Metadata.ContainsKey(property) ? new[] {_corpus.Metadata[property]} : null;
    }

    public override AbstractLayerAdapter GetLayer(Guid layerGuid)
    {
      return _layers.ContainsKey(layerGuid) ? _layers[layerGuid] : null;
    }

    public override AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname)
    {
      return documentGuid != _corpus.Guid
        ? null
        : (from l in _layers where l.Value.Displayname == layerDisplayname select l.Value).FirstOrDefault();
    }

    public override IEnumerable<AbstractLayerAdapter> GetLayers(string displayname)
    {
      return from x in _layers where x.Value.Displayname == displayname select x.Value;
    }

    public override IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid)
    {
      return documentGuid != _corpus.Guid ? null : (from x in _layers select x.Value);
    }

    public override IEnumerable<string> GetLayerValues(string layerDisplayname)
    {
      var res = new HashSet<string>();
      foreach (var l in _layers)
      {
        if (l.Value.Displayname != layerDisplayname)
          continue;
        foreach (var x in l.Value._layer.Dictionary)
          res.Add(x.Value);
      }

      return res;
    }

    public override IEnumerable<string> GetLayerValues(Guid layerGuid)
    {
      var res = new HashSet<string>();
      foreach (var l in _layers)
      {
        if (l.Value.Guid != layerGuid)
          continue;
        foreach (var x in l.Value._layer.Dictionary)
          res.Add(x.Value);
      }

      return res;
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname)
    {
      return GetLayerOfDocument(documentGuid, layerDisplayname).GetReadableDocumentByGuid(documentGuid);
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid)
    {
      return GetLayer(layerGuid).GetReadableDocumentByGuid(documentGuid);
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop)
    {
      return GetLayerOfDocument(documentGuid, layerDisplayname)
        .GetReadableDocumentSnippetByGuid(documentGuid, start, stop);
    }

    public override Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(
      Guid documentGuid)
    {
      return documentGuid != _corpus.Guid
        ? null
        : _layers.ToDictionary(
          layer => layer.Value.Displayname,
          layer => layer.Value.GetReadableDocumentByGuid(documentGuid));
    }

    public override void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy)
    {
      var layer =
        _layers.FirstOrDefault(x => x.Value.Displayname == layerDisplaynameOriginal).Value.Copy() as
          LayerAdapterEchtzeitEngine;
      _layers.Add(layer.Guid, layer);
    }

    public override void LayerDelete(string layerDisplayname)
    {
      var layers = _layers.ToArray();
      foreach (var layer in layers)
        if (layer.Value.Displayname == layerDisplayname)
          _layers.Remove(layer.Key);
    }

    public override void LayerNew(string layerDisplayname)
    {
      if (ContainsLayer(layerDisplayname))
        return;

      var layer = (from x in _layers where x.Value.Displayname == "Wort" select x.Value).FirstOrDefault()
                  ?? (from x in _layers select x.Value).FirstOrDefault();
      if (layer == null)
        return;

      var doc = new int[layer._layer.Document.Length][];
      for (var i = 0; i < layer._layer.Document.Length; i++)
      for (var j = 0; j < layer._layer.Document[i].Length; j++)
        doc[i][j] = -1;

      var nlayer = new EchtzeitLayer
      {
        Dictionary = new CeDictionary(new Dictionary<string, int>()),
        Guid = Guid.NewGuid(),
        Displayname = layerDisplayname,
        DocumentGuid = _corpus.Guid,
        Document = doc
      };
      _layers.Add(nlayer.Guid, LayerAdapterEchtzeitEngine.Create(nlayer));
    }

    public override void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      foreach (var layer in _layers)
        if (layer.Value.Displayname == layerDisplaynameOld)
          layer.Value.Displayname = layerDisplaynameNew;
    }

    public override bool RemoveConcept(Concept concept)
    {
      return false;
    }

    public override void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata)
    {
      if (!newMetadata.ContainsKey(_corpus.Guid))
        return;
    }

    public override void Save(string path = null, bool useCompression = true)
    {
      _corpus.Layers = _layers.Select(l => l.Value._layer).ToList();
      Serializer.Serialize(_corpus, path, useCompression);
    }

    public override void SetCorpusMetadata(string key, object value)
    {
      if (_corpus.Metadata.ContainsKey(key))
        _corpus.Metadata[key] = value;
      else
        _corpus.Metadata.Add(key, value);
    }

    public override bool SetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      return GetLayer(layerGuid).SetDocumentLayerValueMaskBySwitch(documentGuid, sentenceIndex, wordIndex, layerValue);
    }

    public override bool SetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      return GetLayerOfDocument(documentGuid, layerDisplayname)
        .SetDocumentLayerValueMaskBySwitch(documentGuid, sentenceIndex, wordIndex, layerValue);
    }

    public override void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata)
    {
      if (_corpus.Guid != documentGuid)
        return;
      _corpus.Metadata = metadata;
    }

    public override void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      if (_corpus.Metadata.ContainsKey(metadataKey))
        return;

      _corpus.Metadata.Add(metadataKey, Activator.CreateInstance(type));
    }
  }
}