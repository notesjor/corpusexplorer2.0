using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Layer.Model;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Corpus.Model
{
  [Serializable]
  public class EchtzeitCorpus
  {
    [NonSerialized]
    private Dictionary<string, object> _metadata;

    private KeyValuePair<string, object>[] _metadataSerialized;

    public string Displayname { get; set; }
    public Guid Guid { get; set; }
    public List<EchtzeitLayer> Layers { get; set; }
    public Dictionary<string, object> Metadata { get { return _metadata; } set { _metadata = value; } }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      try
      {
        _metadata = _metadataSerialized?.ToDictionary(x => x.Key, x => x.Value) ?? new Dictionary<string, object>();
      }
      catch // Fallback
      {
        _metadata = new Dictionary<string, object>();
        if (_metadataSerialized != null)
          foreach (var entry in _metadataSerialized.Where(entry => !_metadata.ContainsKey(entry.Key)))
            _metadata.Add(entry.Key, entry.Value);
      }
      _metadataSerialized = null;
    }

    [OnSerialized]
    private void OnSerialized(StreamingContext context) { _metadataSerialized = null; }

    [OnSerializing]
    private void OnSerializing(StreamingContext context) { _metadataSerialized = _metadata?.ToArray(); }
  }
}