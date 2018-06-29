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
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  public enum commentTypeType
  {
    /// <remarks />
    Activities,

    /// <remarks />
    Bck,

    /// <remarks />
    Date,

    /// <remarks />
    Exceptions,

    /// <remarks />
    [XmlEnum("Interaction Type")] InteractionType,

    /// <remarks />
    Number,

    /// <remarks />
    [XmlEnum("Recording Quality")] RecordingQuality,

    /// <remarks />
    Transcription,

    /// <remarks />
    Blank,

    /// <remarks />
    T,

    /// <remarks />
    Generic,

    /// <remarks />
    [XmlEnum("New Language")] NewLanguage,

    /// <remarks />
    Location,

    /// <remarks />
    [XmlEnum("New Episode")] NewEpisode,

    /// <remarks />
    [XmlEnum("Room Layout")] RoomLayout,

    /// <remarks />
    Situation,

    /// <remarks />
    [XmlEnum("Tape Location")] TapeLocation,

    /// <remarks />
    [XmlEnum("Time Duration")] TimeDuration,

    /// <remarks />
    [XmlEnum("Time Start")] TimeStart,

    /// <remarks />
    Transcriber,

    /// <remarks />
    Warning,

    /// <remarks />
    Page
  }
}