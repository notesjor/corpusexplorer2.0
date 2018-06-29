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
  public enum groupAnnotationTypeType
  {
    /// <remarks />
    actions,

    /// <remarks />
    alternative,

    /// <remarks />
    comments,

    /// <remarks />
    explanation,

    /// <remarks />
    paralinguistics,

    /// <remarks />
    [XmlEnum("standard for dialect")] standardfordialect,

    /// <remarks />
    [XmlEnum("standard for child")] standardforchild,

    /// <remarks />
    [XmlEnum("standard for unclear source")]
    standardforunclearsource
  }
}