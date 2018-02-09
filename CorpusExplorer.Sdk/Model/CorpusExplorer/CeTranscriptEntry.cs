#region

using System;
using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Model.CorpusExplorer
{
  /// <summary>
  ///   The ce transcript entry.
  /// </summary>
  [Serializable]
  public class CeTranscriptEntry
  {
    public CeTranscriptEntry() { Metadata = new Dictionary<string, object>(); }

    /// <summary>
    ///   Gets or sets the data.
    /// </summary>
    public string Data { get; set; }

    /// <summary>
    ///   Gets or sets the metadata.
    /// </summary>
    /// <value>The metadata.</value>
    public Dictionary<string, object> Metadata { get; set; }
  }
}