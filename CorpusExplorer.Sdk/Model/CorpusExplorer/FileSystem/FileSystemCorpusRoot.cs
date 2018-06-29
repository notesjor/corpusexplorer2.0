using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CorpusExplorer.Sdk.Model.CorpusExplorer.FileSystem
{
  [Serializable]
  public class FileSystemCorpusRoot
  {
    [NonSerialized] private Dictionary<string, object> _corpusMetadata = new Dictionary<string, object>();

    private KeyValuePair<string, object>[] _corpusMetadataSerialized;

    [NonSerialized] private Dictionary<Guid, Tuple<int, int, Dictionary<string, object>>> _documentMetadata =
      new Dictionary<Guid, Tuple<int, int, Dictionary<string, object>>>();

    private KeyValuePair<Guid, Tuple<int, int, KeyValuePair<string, object>[]>>[] _documentMetadataSerialized;

    public FileSystemCorpusRoot(
      Dictionary<string, object> corpusMetadata,
      Dictionary<Guid, Tuple<int, int, Dictionary<string, object>>> documentMetadata,
      Guid? corpusGuid = null)
    {
      Guid = corpusGuid ?? Guid.NewGuid();
      _corpusMetadata = corpusMetadata ?? new Dictionary<string, object>();
      _documentMetadata = documentMetadata ?? new Dictionary<Guid, Tuple<int, int, Dictionary<string, object>>>();
    }

    private FileSystemCorpusRoot()
    {
    }

    public Dictionary<string, object> CorpusMetadata
    {
      get => _corpusMetadata;
      set => _corpusMetadata = value;
    }

    public Dictionary<Guid, Tuple<int, int, Dictionary<string, object>>> DocumentMetadata
    {
      get => _documentMetadata;
      set => _documentMetadata = value;
    }

    public Guid Guid { get; set; }

    private void DeserializeCorpusMetadata()
    {
      try
      {
        _corpusMetadata = _corpusMetadataSerialized?.ToDictionary(x => x.Key, x => x.Value) ??
                          new Dictionary<string, object>();
      }
      catch
      {
        _corpusMetadata = new Dictionary<string, object>();

        if (_corpusMetadataSerialized != null)
          foreach (var x in _corpusMetadataSerialized.Where(x => !_corpusMetadata.ContainsKey(x.Key)))
            _corpusMetadata.Add(x.Key, x.Value);

        _corpusMetadataSerialized = null;
      }
    }

    private void DeserializeDocumentMetadata()
    {
      try
      {
        _documentMetadata = _documentMetadataSerialized.ToDictionary(
          x => x.Key,
          x => new Tuple<int, int, Dictionary<string, object>>(
            x.Value.Item1,
            x.Value.Item1,
            x.Value.Item3.ToDictionary(y => y.Key, y => y.Value)));
      }
      catch
      {
        _documentMetadata = new Dictionary<Guid, Tuple<int, int, Dictionary<string, object>>>();

        if (_documentMetadataSerialized != null)
          foreach (var pair in _documentMetadataSerialized)
            _documentMetadata.Add(
              pair.Key,
              new Tuple<int, int, Dictionary<string, object>>(
                pair.Value.Item1,
                pair.Value.Item2,
                pair.Value.Item3.ToDictionary(x => x.Key, x => x.Value)));

        _documentMetadataSerialized = null;
      }
    }


    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      DeserializeCorpusMetadata();
      DeserializeDocumentMetadata();

      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    [OnSerialized]
    private void OnSerialized(StreamingContext context)
    {
      _corpusMetadataSerialized = null;
      _documentMetadataSerialized = null;

      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    [OnSerializing]
    private void OnSerializing(StreamingContext context)
    {
      _corpusMetadataSerialized = _corpusMetadata.ToArray();
      _documentMetadataSerialized =
        _documentMetadata.Select(
          tuple =>
            new KeyValuePair<Guid, Tuple<int, int, KeyValuePair<string, object>[]>>(
              tuple.Key,
              new Tuple<int, int, KeyValuePair<string, object>[]>(
                tuple.Value.Item1,
                tuple.Value.Item2,
                tuple.Value.Item3.ToArray()))).ToArray();
    }
  }
}