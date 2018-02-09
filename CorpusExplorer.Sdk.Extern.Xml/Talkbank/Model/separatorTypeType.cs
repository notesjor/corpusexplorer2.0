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
  public enum separatorTypeType
  {
    /// <remarks />
    semicolon,

    /// <remarks />
    colon,

    /// <remarks />
    [XmlEnum("clause delimiter")]
    clausedelimiter,

    /// <remarks />
    [XmlEnum("rising to high")]
    risingtohigh,

    /// <remarks />
    [XmlEnum("rising to mid")]
    risingtomid,

    /// <remarks />
    level,

    /// <remarks />
    [XmlEnum("falling to mid")]
    fallingtomid,

    /// <remarks />
    [XmlEnum("falling to low")]
    fallingtolow,

    /// <remarks />
    [XmlEnum("unmarked ending")]
    unmarkedending,

    /// <remarks />
    uptake
  }
}