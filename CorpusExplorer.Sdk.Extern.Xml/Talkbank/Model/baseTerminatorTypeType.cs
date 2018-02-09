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
  [XmlType(AnonymousType = true, Namespace = "http://www.talkbank.org/ns/talkbank")]
  public enum baseTerminatorTypeType
  {
    /// <remarks />
    p,

    /// <remarks />
    q,

    /// <remarks />
    e,

    /// <remarks />
    [XmlEnum("broken for coding")]
    brokenforcoding,

    /// <remarks />
    [XmlEnum("trail off")]
    trailoff,

    /// <remarks />
    [XmlEnum("trail off question")]
    trailoffquestion,

    /// <remarks />
    [XmlEnum("question exclamation")]
    questionexclamation,

    /// <remarks />
    interruption,

    /// <remarks />
    [XmlEnum("interruption question")]
    interruptionquestion,

    /// <remarks />
    [XmlEnum("self interruption")]
    selfinterruption,

    /// <remarks />
    [XmlEnum("self interruption question")]
    selfinterruptionquestion,

    /// <remarks />
    [XmlEnum("quotation next line")]
    quotationnextline,

    /// <remarks />
    [XmlEnum("quotation precedes")]
    quotationprecedes,

    /// <remarks />
    [XmlEnum("missing CA terminator")]
    missingCAterminator,

    /// <remarks />
    [XmlEnum("technical break TCU continuation")]
    technicalbreakTCUcontinuation,

    /// <remarks />
    [XmlEnum("no break TCU continuation")]
    nobreakTCUcontinuation
  }
}