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
  public enum linkerTypeType
  {
    /// <remarks />
    [XmlEnum("quoted utterance next")]
    quotedutterancenext,

    /// <remarks />
    [XmlEnum("quick uptake")]
    quickuptake,

    /// <remarks />
    [XmlEnum("lazy overlap mark")]
    lazyoverlapmark,

    /// <remarks />
    [XmlEnum("self completion")]
    selfcompletion,

    /// <remarks />
    [XmlEnum("other completion")]
    othercompletion,

    /// <remarks />
    [XmlEnum("technical break TCU completion")]
    technicalbreakTCUcompletion,

    /// <remarks />
    [XmlEnum("no break TCU completion")]
    nobreakTCUcompletion
  }
}