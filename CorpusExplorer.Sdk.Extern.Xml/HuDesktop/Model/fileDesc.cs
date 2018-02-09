using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.HuDesktop.Model
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
    private idno[] publicationStmtField;

    private sourceDesc sourceDescField;

    private titleStmt titleStmtField;

    /// <remarks />
    [XmlArrayItem("idno", IsNullable = false)]
    public idno[] publicationStmt { get { return publicationStmtField; } set { publicationStmtField = value; } }

    /// <remarks />
    public sourceDesc sourceDesc { get { return sourceDescField; } set { sourceDescField = value; } }

    /// <remarks />
    public titleStmt titleStmt { get { return titleStmtField; } set { titleStmtField = value; } }
  }
}