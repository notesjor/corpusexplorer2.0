#region

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [XmlType(AnonymousType = true)]
  public enum phraseBoundaryintonation
  {
    /// <remarks />
    [XmlEnum("high-rise")]
    highrise,

    /// <remarks />
    rise,

    /// <remarks />
    steady,

    /// <remarks />
    fall,

    /// <remarks />
    [XmlEnum("low-fall")]
    lowfall
  }
}