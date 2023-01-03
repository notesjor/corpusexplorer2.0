using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using Bcs.Security;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace CorpusExplorer.Sdk.Model.Adapter.Corpus
{
  public class CorpusAdapterWriteDirect : AbstractCorpusAdapter
  {
    private string _displayname = string.Empty;
    private Dictionary<Guid, Dictionary<string, object>> _documentMetadata;
    private Guid _guid;
    private List<LayerAdapterWriteDirect> _layers;
    private Dictionary<string, object> _metadata;

    private CorpusAdapterWriteDirect()
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
      if (layer is LayerAdapterWriteDirect l)
        _layers.Add(l);
    }

    public override bool ContainsDocument(Guid documentGuid)
      => _documentMetadata.ContainsKey(documentGuid);

    public override bool ContainsLayer(Guid layerGuid)
      => _layers.Any(x => x.Guid == layerGuid);

    public override bool ContainsLayer(string layerDisplayname)
      => _layers.Any(x => x.Displayname == layerDisplayname);

    public static CorpusAdapterWriteDirect Create(string path, string password)
    {
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var cr = new CryptoStream(fs, KeyGenerator.GenerateRijndael(password).CreateDecryptor(), CryptoStreamMode.Read))
      using (var gz = new GZipStream(cr, CompressionMode.Decompress))
      using (var bs = new BufferedStream(gz))
      {
        return Create(path, bs);
      }
    }

    public static CorpusAdapterWriteDirect Create(string path)
    {
      if (path.ToLower().EndsWith(".gz"))
        return CreateGzip(path);
      if (path.ToLower().EndsWith(".lz4"))
        return CreateLz4(path);

      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
        return Create(path, fs);
    }

    private static CorpusAdapterWriteDirect CreateLz4(string path)
    {
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var lz = K4os.Compression.LZ4.Streams.LZ4Stream.Decode(fs))
        return Create(path, lz);
    }

    private static CorpusAdapterWriteDirect CreateGzip(string path)
    {
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var gz = new GZipStream(fs, CompressionMode.Decompress))
        return Create(path, gz);
    }

    private static CorpusAdapterWriteDirect Create(string path, Stream stream)
    {
      using (var bs = new BufferedStream(stream))
      {
        var buffer = new byte[8];
        bs.Read(buffer, 0, buffer.Length);
        var mode = Configuration.Encoding.GetString(buffer);

        if (mode == "SEDITION")
          return CreateStrategySmart(path, bs);

        bs.Seek(0, SeekOrigin.Begin);
        return CreateStrategyOld(path, bs);
      }
    }

    public static CorpusAdapterWriteDirect Create(
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts) =>
      new CorpusAdapterWriteDirect
      {
        _guid = Guid.NewGuid(),
        _documentMetadata = documentMetadata ?? new Dictionary<Guid, Dictionary<string, object>>(),
        _metadata = corpusMetadata ?? new Dictionary<string, object>(),
        _layers = new List<LayerAdapterWriteDirect>()
      };

    public override IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example) =>
      from x in _documentMetadata
      where example.All(y => x.Value.ContainsKey(y.Key) && x.Value[y.Key].Equals(y.Value))
      select x.Key;

    public override AbstractCorpusBuilder GetCorpusBuilder()
      => new CorpusBuilderWriteDirect();

    public override IEnumerable<KeyValuePair<string, object>> GetCorpusMetadata()
      => _metadata;

    public Dictionary<string, Dictionary<string, int>> GetDictionaryForNormalization()
      => _layers.ToDictionary(x => x.Displayname, x => x.ReciveRawLayerDictionary());

    public override long GetDocumentLengthInSentences(Guid documentGuid)
      => _layers.FirstOrDefault(x => x.ContainsDocument(documentGuid))?[documentGuid]?.Length ?? 0;

    public override long GetDocumentLengthInWords(Guid documentGuid)
      => _layers.FirstOrDefault(x => x.ContainsDocument(documentGuid))?[documentGuid]?.Sum(s => s.Length) ?? 0;

    public override Dictionary<string, object> GetDocumentMetadata(Guid documentGuid)
      => _documentMetadata[documentGuid];

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
      => new HashSet<string>(from x in _documentMetadata from o in x.Value select o.Key);

    public override IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
      => new HashSet<object>(from x in _documentMetadata from o in x.Value where o.Key == property select o.Value);

    public override AbstractLayerAdapter GetLayer(Guid layerGuid)
      => (from x in _layers where x.Guid == layerGuid select x).FirstOrDefault();

    public override AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname) =>
      (from x in _layers
       where x.Displayname == layerDisplayname && x.ContainsDocument(documentGuid)
       select x)
     .FirstOrDefault();

    public override IEnumerable<AbstractLayerAdapter> GetLayers(string displayname)
      => from x in _layers where x.Displayname == displayname select x;

    public override IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid)
      => from x in _layers where x.ContainsDocument(documentGuid) select x;

    public override IEnumerable<string> GetLayerValues(string layerDisplayname)
      => _layers.Where(x => x.Displayname == layerDisplayname).SelectMany(x => x.Values);

    public override IEnumerable<string> GetLayerValues(Guid layerGuid)
      => _layers.FirstOrDefault(x => x.Guid == layerGuid)?.Values;

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname) =>
      _layers.FirstOrDefault(x => x.Displayname == layerDisplayname && x.ContainsDocument(documentGuid))?
       .GetReadableDocumentByGuid(documentGuid);

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid) =>
      _layers.FirstOrDefault(x => x.Guid == layerGuid && x.ContainsDocument(documentGuid))?
       .GetReadableDocumentByGuid(documentGuid);

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop) =>
      _layers.FirstOrDefault(x => x.Displayname == layerDisplayname && x.ContainsDocument(documentGuid))?
       .GetReadableDocumentSnippetByGuid(documentGuid, start, stop);

    public override Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(
      Guid documentGuid) =>
      _layers.Where(x => x.ContainsDocument(documentGuid))
             .ToDictionary(x => x.Displayname,
                           x => x.GetReadableDocumentByGuid(documentGuid));

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
      => LayerCopy("Wort", layerDisplayname);

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

    public void Save(string path, string password)
    {
      _displayname = Path.GetFileNameWithoutExtension(path);

      path = path.ForceFileExtension("cec6.drm").Replace(".cec6.cec6", ".cec6");

      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var cr = new CryptoStream(fs, KeyGenerator.GenerateRijndael(password).CreateEncryptor(), CryptoStreamMode.Write))
      using (var gz = new GZipStream(cr, CompressionLevel.Fastest))
      using (var bs = new BufferedStream(gz))
        Save(bs);
    }

    public override void Save(string path = null, bool useCompression = false)
    {
      path = path.Replace(".cec6.cec6", ".cec6");
      _displayname = Path.GetFileNameWithoutExtension(path);

      if (useCompression && path.EndsWith(".cec6"))
        path += ".lz4";

      if (path.ToLower().EndsWith(".cec6"))
        SaveUncompressed(path);
      else if (path.ToLower().EndsWith(".cec6.lz4"))
        SaveCompressedLz4(path);
      else if (path.ToLower().EndsWith(".cec6.gz"))
        SaveCompressedGzip(path);
      else // Sollte nur im Ausnahmefall gelten.
      {
        if (useCompression)
          SaveCompressedLz4(path.ForceFileExtension("cec6.lz4").Replace(".cec6.cec6", ".cec6"));
        else
          SaveUncompressed(path.ForceFileExtension("cec6").Replace(".cec6.cec6", ".cec6"));
      }
    }

    private void SaveCompressedGzip(string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var gz = new GZipStream(fs, CompressionLevel.Fastest))
      using (var bs = new BufferedStream(gz))
        Save(bs);
    }

    private void SaveCompressedLz4(string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var gz = K4os.Compression.LZ4.Streams.LZ4Stream.Encode(fs, K4os.Compression.LZ4.LZ4Level.L03_HC))
      using (var bs = new BufferedStream(gz))
        Save(bs);
    }

    private void SaveUncompressed(string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var bs = new BufferedStream(fs))
        Save(bs);
    }

    private void Save(Stream stream)
    {
      try
      {
        var buffer = Configuration.Encoding.GetBytes("SEDITION");
        stream.Write(buffer, 0, buffer.Length);

        // Corpus GUID
        buffer = _guid.ToByteArray();
        stream.Write(buffer, 0, buffer.Length);

        // Corpus Metadata
        MetaDictionarySerializerHelper.Serialize(stream, _metadata);

        // Document Metadata
        MetaDictionarySerializerHelper.Serialize(stream, _documentMetadata);

        // Layer
        foreach (var layer in _layers)
          layer.Save(stream);

        // Wenn man das Format erweitern wollte, dann muss man folgenden Trenner setzen:
        // buffer = Guid.Empty.ToByteArray();
        // fs.Write(buffer, 0, buffer.Length);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }

    public Dictionary<Guid, long> WriteFuriousIndex(string layerDisplayname, string path)
      => (from l in _layers where l.Displayname == layerDisplayname select l.WriteFuriousIndex(path)).FirstOrDefault();

    [Obsolete("Ersetzt durch WriteFuriousIndex im Zusammhang mit neuer Version von QuickIndex")]
    public Dictionary<Guid, long> GetFuriousIndex(string layerDisplayname)
    {
      long pos = 24; // 8 (SEDITION) + 16 (GUID-Korpus)
      using (var ms = new MemoryStream())
      {
        MetaDictionarySerializerHelper.Serialize(ms, _metadata);
        pos += ms.Length;
      }

      using (var ms = new MemoryStream())
      {
        MetaDictionarySerializerHelper.Serialize(ms, _documentMetadata);
        pos += ms.Length;
      }

      foreach (var l in _layers)
        if (l.Displayname == layerDisplayname)
          return l.GetFuriousIndex(pos);
        else
          using (var ms = new MemoryStream())
          {
            l.Save(ms);
            pos += ms.Length;
          }

      return null;
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
      string layerValue) =>
      _layers.FirstOrDefault(x => x.Guid == layerGuid && x.ContainsDocument(documentGuid))?
       .SetDocumentLayerValueMaskBySwitch(documentGuid, sentenceIndex, wordIndex, layerValue) ?? false;

    public override bool SetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      int sentenceIndex,
      int wordIndex,
      string layerValue) =>
      _layers.FirstOrDefault(x => x.Displayname == layerDisplayname && x.ContainsDocument(documentGuid))?
       .SetDocumentLayerValueMaskBySwitch(documentGuid, sentenceIndex, wordIndex, layerValue) ?? false;

    public override void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata)
    {
      if (_documentMetadata.ContainsKey(documentGuid))
        _documentMetadata[documentGuid] = metadata;
      else
        _documentMetadata.Add(documentGuid, metadata);
    }

    public override void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      foreach (var x in _documentMetadata.Where(x => !x.Value.ContainsKey(metadataKey)))
        x.Value.Add(metadataKey, CreateInstance(type));
    }

    private static object CreateInstance(Type type)
    {
      if (type == typeof(string))
        return "";
      if (type == typeof(int))
        return 0;
      if (type == typeof(double))
        return 0.0;
      if (type == typeof(bool))
        return false;
      if (type == typeof(DateTime))
        return DateTime.MinValue;

      return Activator.CreateInstance(type);
    }

    private static CorpusAdapterWriteDirect CreateStrategyOld(string path, Stream fs)
    {
      var res = new CorpusAdapterWriteDirect
      {
        _layers = new List<LayerAdapterWriteDirect>(),
        _displayname = Path.GetFileNameWithoutExtension(path),
        CorpusDisplayname = Path.GetFileNameWithoutExtension(path),
        CorpusPath = path
      };

      var buffer = new byte[16];
      fs.Read(buffer, 0, buffer.Length);

      // Corpus GUID
      res._guid = new Guid(buffer);

      var bf = new BinaryFormatter();

      // Corpus Metadata.Length
      buffer = new byte[sizeof(long)];
      fs.Read(buffer, 0, buffer.Length);
      var length = BitConverter.ToInt64(buffer, 0);
      // Corpus Metadata
      buffer = new byte[length];
      fs.Read(buffer, 0, buffer.Length);
      if (buffer.Length > 0)
        using (var ms = new MemoryStream(buffer))
        {
          res._metadata = (Dictionary<string, object>)bf.Deserialize(ms);
        }

      // Document Metadata.Length
      buffer = new byte[sizeof(long)];
      fs.Read(buffer, 0, buffer.Length);
      length = BitConverter.ToInt64(buffer, 0);
      // Document Metadata
      buffer = new byte[length];
      fs.Read(buffer, 0, buffer.Length);
      if (buffer.Length > 0)
        using (var ms = new MemoryStream(buffer))
        {
          res._documentMetadata = (Dictionary<Guid, Dictionary<string, object>>)bf.Deserialize(ms);
        }

      // Layer
      LayerAdapterWriteDirect layer;
      do
      {
        layer = LayerAdapterWriteDirect.Create(fs);
        if (layer != null)
          res._layers.Add(layer);
      } while (layer != null);

      return res;
    }

    private static CorpusAdapterWriteDirect CreateStrategySmart(string path, Stream fs)
    {
      var res = new CorpusAdapterWriteDirect
      {
        _layers = new List<LayerAdapterWriteDirect>(),
        _displayname = Path.GetFileNameWithoutExtension(path),
        CorpusDisplayname = Path.GetFileNameWithoutExtension(path),
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
      LayerAdapterWriteDirect layer;
      do
      {
        layer = LayerAdapterWriteDirect.Create(fs);
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
      _displayname = null;
      foreach (var meta in _documentMetadata)
        meta.Value?.Clear();
      _documentMetadata?.Clear();
      _documentMetadata = null;
      _guid = Guid.Empty;
      _metadata?.Clear();
      _metadata = null;
      foreach (var layer in _layers)
        layer?.Dispose();
      _layers?.Clear();
      _layers = null;
    }
  }
}