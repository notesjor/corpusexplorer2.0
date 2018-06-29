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
  public enum markersType
  {
    /// <remarks />
    stressing,

    /// <remarks />
    [XmlEnum("contrastive stressing")] contrastivestressing,

    /// <remarks />
    [XmlEnum("best guess")] bestguess,

    /// <remarks />
    retracing,

    /// <remarks />
    [XmlEnum("retracing with correction")] retracingwithcorrection,

    /// <remarks />
    [XmlEnum("retracing reformulation")] retracingreformulation,

    /// <remarks />
    [XmlEnum("retracing unclear")] retracingunclear,

    /// <remarks />
    [XmlEnum("false start")] falsestart
  }
}