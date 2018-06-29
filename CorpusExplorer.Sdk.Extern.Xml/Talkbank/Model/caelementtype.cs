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
  [XmlType(TypeName = "ca-element-type", Namespace = "http://www.talkbank.org/ns/talkbank")]
  public enum caelementtype
  {
    /// <remarks />
    constriction,

    /// <remarks />
    inhalation,

    /// <remarks />
    [XmlEnum("laugh in word")] laughinword,

    /// <remarks />
    [XmlEnum("pitch down")] pitchdown,

    /// <remarks />
    [XmlEnum("pitch reset")] pitchreset,

    /// <remarks />
    [XmlEnum("pitch up")] pitchup,

    /// <remarks />
    [XmlEnum("primary stress")] primarystress,

    /// <remarks />
    [XmlEnum("secondary stress")] secondarystress
  }
}