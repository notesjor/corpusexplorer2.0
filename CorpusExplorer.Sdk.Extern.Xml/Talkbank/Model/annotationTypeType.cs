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
  public enum annotationTypeType
  {
    /// <remarks />
    addressee,

    /// <remarks />
    actions,

    /// <remarks />
    alternative,

    /// <remarks />
    coding,

    /// <remarks />
    cohesion,

    /// <remarks />
    comments,

    /// <remarks />
    [XmlEnum("english translation")] englishtranslation,

    /// <remarks />
    errcoding,

    /// <remarks />
    explanation,

    /// <remarks />
    flow,

    /// <remarks />
    facial,

    /// <remarks />
    [XmlEnum("target gloss")] targetgloss,

    /// <remarks />
    gesture,

    /// <remarks />
    intonation,

    /// <remarks />
    language,

    /// <remarks />
    orthography,

    /// <remarks />
    paralinguistics,

    /// <remarks />
    SALT,

    /// <remarks />
    situation,

    /// <remarks />
    [XmlEnum("speech act")] speechact,

    /// <remarks />
    [XmlEnum("time stamp")] timestamp,

    /// <remarks />
    extension
  }
}