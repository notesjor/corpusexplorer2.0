using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class titleStmt
  {
    private author[] authorField;

    private editor[] editorField;

    private respStmt[] respStmtField;

    private title[] titleField;

    /// <remarks />
    [XmlElement("title")]
    public title[] title { get { return titleField; } set { titleField = value; } }

    /// <remarks />
    [XmlElement("author")]
    public author[] author { get { return authorField; } set { authorField = value; } }

    /// <remarks />
    [XmlElement("editor")]
    public editor[] editor { get { return editorField; } set { editorField = value; } }

    /// <remarks />
    [XmlElement("respStmt")]
    public respStmt[] respStmt { get { return respStmtField; } set { respStmtField = value; } }
  }
}