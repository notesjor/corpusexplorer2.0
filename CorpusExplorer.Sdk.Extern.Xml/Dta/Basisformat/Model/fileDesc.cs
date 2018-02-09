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
  public class fileDesc
  {
    private editionStmt editionStmtField;

    private measure[] extentField;

    private publicationStmt publicationStmtField;

    private sourceDesc sourceDescField;

    private titleStmt titleStmtField;

    /// <remarks />
    public editionStmt editionStmt { get { return editionStmtField; } set { editionStmtField = value; } }

    /// <remarks />
    [XmlArrayItem("measure", IsNullable = false)]
    public measure[] extent { get { return extentField; } set { extentField = value; } }

    /// <remarks />
    public publicationStmt publicationStmt
    {
      get { return publicationStmtField; }
      set { publicationStmtField = value; }
    }

    /// <remarks />
    public sourceDesc sourceDesc { get { return sourceDescField; } set { sourceDescField = value; } }

    /// <remarks />
    public titleStmt titleStmt { get { return titleStmtField; } set { titleStmtField = value; } }
  }
}