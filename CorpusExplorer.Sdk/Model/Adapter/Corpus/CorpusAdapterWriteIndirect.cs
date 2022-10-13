using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace CorpusExplorer.Sdk.Model.Adapter.Corpus
{
  public class CorpusAdapterWriteIndirect : AbstractCorpusAdapter
  {
    private string _displayname = string.Empty;
    private Dictionary<Guid, Dictionary<string, object>> _documentMetadata;
    private Guid _guid;
    private List<LayerAdapterWriteIndirect> _layers;
    private Dictionary<string, object> _metadata;

    private CorpusAdapterWriteIndirect()
    {
    }

    public override IEnumerable<Concept> Concepts => null; // ToDo: CorpusAdapterWriteDirect unterstützt keine Concepts

    public override string CorpusDisplayname
    {
      get => _displayname;
      set => _displayname = value;
    }

    public override Guid CorpusGuid => _guid;
    public override IEnumerable<Guid> DocumentGuids => _documentMetadata.Select(x => x.Key);
    public override IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata => _documentMetadata;
    public override Guid FirstDocument => _documentMetadata.FirstOrDefault().Key;
    public override IEnumerable<string> LayerDisplaynames => _layers.Select(x => x.Displayname);

    public override IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames
      => _layers.ToDictionary(x => x.Guid, x => x.Displayname);

    public override IEnumerable<Guid> LayerGuids => _layers.Select(x => x.Guid);

    public override IEnumerable<AbstractLayerAdapter> Layers => _layers;

    public override IEnumerable<string> LayerUniqueDisplaynames => new HashSet<string>(
                                                                                       _layers
                                                                                        .Select(x => x.Displayname));

    public override bool UseCompression => false;

    public override void AddConcept(Concept concept)
    {
      throw new NotImplementedException();
    }

    public override void AddLayer(AbstractLayerAdapter layer)
    {
      throw new NotImplementedException();
    }

    public override bool ContainsDocument(Guid documentGuid)
    {
      return _documentMetadata.ContainsKey(documentGuid);
    }

    public override bool ContainsLayer(Guid layerGuid)
    {
      return _layers.Any(x => x.Guid == layerGuid);
    }

    public override bool ContainsLayer(string layerDisplayname)
    {
      return _layers.Any(x => x.Displayname == layerDisplayname);
    }

    public static CorpusAdapterWriteIndirect Create(string path)
    {
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var bs = new BufferedStream(fs))
      {
        var buffer = new byte[8];
        bs.Read(buffer, 0, buffer.Length);
        var mode = Configuration.Encoding.GetString(buffer);

        if (mode == "SEDITION")
          return CreateStrategySmart(path, bs);

        throw new NotImplementedException();
      }
    }


    public override IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example)
    {
      return from x in _documentMetadata
             where example.All(y => x.Value.ContainsKey(y.Key) && x.Value[y.Key].Equals(y.Value))
             select x.Key;
    }

    public override AbstractCorpusBuilder GetCorpusBuilder()
    {
      return new CorpusBuilderWriteDirect();
    }

    public override IEnumerable<KeyValuePair<string, object>> GetCorpusMetadata()
    {
      return _metadata;
    }

    public override long GetDocumentLengthInSentences(Guid documentGuid)
    {
      return _layers.FirstOrDefault(x => x.ContainsDocument(documentGuid))?[documentGuid]?.Length ?? 0;
    }

    public override long GetDocumentLengthInWords(Guid documentGuid)
    {
      return _layers.FirstOrDefault(x => x.ContainsDocument(documentGuid))?[documentGuid]?.SelectMany(s => s).Count()
          ?? 0;
    }

    public override Dictionary<string, object> GetDocumentMetadata(Guid documentGuid)
    {
      return _documentMetadata[documentGuid];
    }

    public override Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype()
    {
      var res = new Dictionary<string, HashSet<object>>();
      foreach (var x in _documentMetadata)
        foreach (var o in x.Value)
        {
          if (!res.ContainsKey(o.Key))
            res.Add(o.Key, new HashSet<object>());
          res[o.Key].Add(o.Value);
        }

      return res;
    }

    public override IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties()
    {
      return new HashSet<string>(from x in _documentMetadata from o in x.Value select o.Key);
    }

    public override IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
    {
      return new HashSet<object>(from x in _documentMetadata from o in x.Value where o.Key == property select o.Value);
    }

    public override AbstractLayerAdapter GetLayer(Guid layerGuid)
    {
      return (from x in _layers where x.Guid == layerGuid select x).FirstOrDefault();
    }

    public override AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname)
    {
      return (from x in _layers where x.Displayname == layerDisplayname && x.ContainsDocument(documentGuid) select x)
       .FirstOrDefault();
    }

    public override IEnumerable<AbstractLayerAdapter> GetLayers(string displayname)
    {
      return from x in _layers where x.Displayname == displayname select x;
    }

    public override IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid)
    {
      return from x in _layers where x.ContainsDocument(documentGuid) select x;
    }

    public override IEnumerable<string> GetLayerValues(string layerDisplayname)
    {
      return _layers.Where(x => x.Displayname == layerDisplayname).SelectMany(x => x.Values);
    }

    public override IEnumerable<string> GetLayerValues(Guid layerGuid)
    {
      return _layers.FirstOrDefault(x => x.Guid == layerGuid)?.Values;
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname)
    {
      return _layers.FirstOrDefault(
                                    x => x.Displayname == layerDisplayname && x.ContainsDocument(documentGuid))?
       .GetReadableDocumentByGuid(documentGuid);
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid)
    {
      return _layers.FirstOrDefault(
                                    x => x.Guid == layerGuid && x.ContainsDocument(documentGuid))?
       .GetReadableDocumentByGuid(documentGuid);
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop)
    {
      return _layers.FirstOrDefault(
                                    x => x.Displayname == layerDisplayname && x.ContainsDocument(documentGuid))?
       .GetReadableDocumentSnippetByGuid(documentGuid, start, stop);
    }

    public override Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(
      Guid documentGuid)
    {
      return _layers.Where(x => x.ContainsDocument(documentGuid))
                    .ToDictionary(
                                  x => x.Displayname,
                                  x => x.GetReadableDocumentByGuid(documentGuid));
    }

    public override void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy)
    {
      var layer = GetLayers(layerDisplaynameOriginal).FirstOrDefault()?.Copy();
      if (layer == null) return;
      layer.Displayname = layerDisplaynameCopy;
      AddLayer(layer);
    }

    public override void LayerDelete(string layerDisplayname)
    {
      var layers = (from x in _layers where x.Displayname == layerDisplayname select x).ToArray();
      foreach (var layer in layers)
        _layers.Remove(layer);
    }

    public override void LayerNew(string layerDisplayname)
    {
      LayerCopy("Wort", layerDisplayname);
    }

    public override void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      var layers = (from x in _layers where x.Displayname == layerDisplaynameOld select x).ToArray();
      foreach (var layer in layers)
        layer.Displayname = layerDisplaynameNew;
    }

    public override bool RemoveConcept(Concept concept)
    {
      throw new NotImplementedException();
    }

    public override void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata)
    {
      _documentMetadata = newMetadata;
    }

    public override void Save(string path = null, bool useCompression = true)
    {
      throw new NotImplementedException();
      /*
      path = path.ForceFileExtension("cec6");

      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
      {
        var buffer = Configuration.Encoding.GetBytes("SEDITION");
        fs.Write(buffer, 0, buffer.Length);

        // Corpus GUID
        buffer = _guid.ToByteArray();
        fs.Write(buffer, 0, buffer.Length);

        // Corpus Metadata
        MetaDictionarySerializerHelper.Serialize(fs, _metadata);

        // Document Metadata
        MetaDictionarySerializerHelper.Serialize(fs, _documentMetadata);

        // Layer
        foreach (var layer in _layers)
          layer.Save(fs);

        // Wenn man das Format erweitern wollte, dann muss man folgenden Trenner setzen:
        // buffer = Guid.Empty.ToByteArray();
        // fs.Write(buffer, 0, buffer.Length);
      }
      */
    }

    public override void SetCorpusMetadata(string key, object value)
    {
      if (_metadata.ContainsKey(key))
        _metadata[key] = value;
      else
        _metadata.Add(key, value);
    }

    public override bool SetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      return _layers.FirstOrDefault(x => x.Guid == layerGuid && x.ContainsDocument(documentGuid))?
              .SetDocumentLayerValueMaskBySwitch(documentGuid, sentenceIndex, wordIndex, layerValue) ?? false;
    }

    public override bool SetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      return _layers.FirstOrDefault(
                                    x => x.Displayname == layerDisplayname && x.ContainsDocument(documentGuid))?
              .SetDocumentLayerValueMaskBySwitch(documentGuid, sentenceIndex, wordIndex, layerValue) ?? false;
    }

    public override void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata)
    {
      if (_documentMetadata.ContainsKey(documentGuid))
        _documentMetadata[documentGuid] = metadata;
      else
        _documentMetadata.Add(documentGuid, metadata);
    }

    public override void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      foreach (var x in _documentMetadata)
        if (!x.Value.ContainsKey(metadataKey))
          x.Value.Add(metadataKey, Activator.CreateInstance(type));
    }

    private static CorpusAdapterWriteIndirect CreateStrategySmart(string path, Stream fs)
    {
      var res = new CorpusAdapterWriteIndirect
      {
        _layers = new List<LayerAdapterWriteIndirect>(),
        _displayname = Path.GetFileNameWithoutExtension(path),
        CorpusPath = path
      };

      var buffer = new byte[16];
      fs.Read(buffer, 0, buffer.Length);

      // Corpus GUID
      res._guid = new Guid(buffer);

      // Corpus Metadata.Length
      res._metadata = MetaDictionarySerializerHelper.Deserialize(fs);

      // Document Metadata.Length
      res._documentMetadata = MetaDictionarySerializerHelper.DeserializeContainer(fs);

      // Layer
      LayerAdapterWriteIndirect layer;
      do
      {
        layer = LayerAdapterWriteIndirect.Create(fs, path);
        if (layer == null)
          continue;

        layer.Displayname = Configuration.LayerDisplayNameLocalization.Translate(layer.Displayname);
        res._layers.Add(layer);
      } while (layer != null);

      // Metadata Fallback
      // ReSharper disable once InvertIf
      if (res._documentMetadata == null)
      {
        var guids = new HashSet<Guid>();
        foreach (var l in res._layers)
          foreach (var dsel in l.DocumentGuids)
            guids.Add(dsel);

        res._documentMetadata = guids.ToDictionary(x => x, x => new Dictionary<string, object>());
      }

      return res;
    }

    public override void Dispose()
    {
      foreach (var layer in _layers)
      {
        layer.Dispose();
      }
    }
  }
}