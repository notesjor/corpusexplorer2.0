#region

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [XmlType(TypeName = "ca-delimiter-type", Namespace = "http://www.talkbank.org/ns/talkbank")]
  public enum cadelimitertype
  {
    /// <remarks />
    [XmlEnum("breathy voice")]
    breathyvoice,

    /// <remarks />
    creaky,

    /// <remarks />
    faster,

    /// <remarks />
    [XmlEnum("high-pitch")]
    highpitch,

    /// <remarks />
    louder,

    /// <remarks />
    [XmlEnum("low-pitch")]
    lowpitch,

    /// <remarks />
    precise,

    /// <remarks />
    singing,

    /// <remarks />
    slower,

    /// <remarks />
    [XmlEnum("smile voice")]
    smilevoice,

    /// <remarks />
    softer,

    /// <remarks />
    unsure,

    /// <remarks />
    whisper,

    /// <remarks />
    yawn
  }
}