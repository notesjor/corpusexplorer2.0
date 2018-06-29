using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Light.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class editionStmt
  {
    private string editionField;

    private respStmt[] respStmtField;

    /// <remarks />
    public string edition
    {
      get => editionField;
      set => editionField = value;
    }

    /// <remarks />
    [XmlElement("respStmt")]
    public respStmt[] respStmt
    {
      get => respStmtField;
      set => respStmtField = value;
    }
  }
}