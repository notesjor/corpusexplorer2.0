using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [XmlType(IncludeInSchema = false)]
  public enum ItemsChoiceType
  {
    /// <remarks />
    abbildung,

    /// <remarks />
    absatz,

    /// <remarks />
    kasten,

    /// <remarks />
    table,

    /// <remarks />
    [XmlEnum("table-fix")]
    tablefix
  }
}