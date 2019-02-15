#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Model.CorpusExplorer
{
  /// <summary>
  ///   The ce object.
  /// </summary>
  [Serializable]
  public abstract class CeObject
  {
    /// <summary>
    ///   The _transcript.
    /// </summary>
    private readonly List<CeTranscriptEntry> _transcript;

    /// <summary>
    ///   The _guid.
    /// </summary>
    protected Guid _guid;

    /// <summary>
    ///   The _metadata.
    /// </summary>
    [NonSerialized] private Dictionary<string, object> _metadata;

    private KeyValuePair<string, object>[] _metadataSerialized;

    /// <summary>
    ///   Initializes a new instance of the <see cref="CeObject" /> class.
    /// </summary>
    // ReSharper disable once PublicConstructorInAbstractClass
    public CeObject()
    {
      _guid = Guid.NewGuid();
      _transcript = new List<CeTranscriptEntry>();
      _metadata = new Dictionary<string, object>();
      SyncTimestamp = DateTime.MinValue;
    }

    /// <summary>
    ///   Gets or sets the displayname.
    /// </summary>
    public string Displayname { get; set; }

    /// <summary>
    ///   Gets the guid.
    /// </summary>
    public Guid Guid => _guid;

    /// <summary>
    ///   Gets or sets the metadata.
    /// </summary>
    public Dictionary<string, object> Metadata
    {
      get => _metadata;
      set => _metadata = value;
    }

    /// <summary>
    ///   Gets or sets the sync timestamp.
    /// </summary>
    public DateTime SyncTimestamp { get; set; }

    /// <summary>
    ///   Gets the transcript.
    /// </summary>
    // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
    public List<CeTranscriptEntry> Transcript => _transcript;

    /// <summary>
    ///   The equals.
    /// </summary>
    /// <param name="obj">
    ///   The obj.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    public override bool Equals(object obj)
    {
      if (obj       == null ||
          GetType() != obj.GetType())
        return false;

      return ToString().Equals(((CeObject) obj).ToString());
    }

    /// <summary>
    ///   The get hash code.
    /// </summary>
    /// <returns>
    ///   The <see cref="int" />.
    /// </returns>
    public override int GetHashCode()
    {
      return _guid.GetHashCode();
    }

    /// <summary>
    ///   Gibt eine Zeichenfolge zurück, die das aktuelle Objekt darstellt.
    /// </summary>
    /// <returns>
    ///   Eine Zeichenfolge, die das aktuelle Objekt darstellt.
    /// </returns>
    public override string ToString()
    {
      return $"CEOID:{GetType().FullName}:{Guid.ToString("N")}:{Displayname}";
    }

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
    private void OnSerialized(StreamingContext context)
    {
      _metadataSerialized = null;
    }

    [OnSerializing]
    private void OnSerializing(StreamingContext context)
    {
      _metadataSerialized = _metadata?.ToArray();
    }
  }
}