using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [XmlType(IncludeInSchema = false)]
  public enum ItemsChoiceType
  {
    /// <remarks />
    [XmlEnum("c.title")]
    ctitle,

    /// <remarks />
    [XmlEnum("d.title")]
    dtitle,

    /// <remarks />
    dokumentSigle,

    /// <remarks />
    korpusSigle,

    /// <remarks />
    [XmlEnum("t.title")]
    ttitle,

    /// <remarks />
    textSigle
  }
}