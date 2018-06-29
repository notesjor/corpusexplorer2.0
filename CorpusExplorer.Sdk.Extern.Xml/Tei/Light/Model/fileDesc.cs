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
  public class fileDesc
  {
    private editionStmt editionStmtField;

    private p[] publicationStmtField;

    private bibl[] sourceDescField;

    private titleStmt titleStmtField;

    /// <remarks />
    public editionStmt editionStmt
    {
      get => editionStmtField;
      set => editionStmtField = value;
    }

    /// <remarks />
    [XmlArrayItem("p", IsNullable = false)]
    public p[] publicationStmt
    {
      get => publicationStmtField;
      set => publicationStmtField = value;
    }

    /// <remarks />
    [XmlArrayItem("bibl", IsNullable = false)]
    public bibl[] sourceDesc
    {
      get => sourceDescField;
      set => sourceDescField = value;
    }

    /// <remarks />
    public titleStmt titleStmt
    {
      get => titleStmtField;
      set => titleStmtField = value;
    }
  }
}