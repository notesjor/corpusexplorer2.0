using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class fileDesc
  {
    private editionStmt editionStmtField;

    private publicationStmt publicationStmtField;

    private sourceDesc sourceDescField;

    private titleStmt titleStmtField;

    /// <remarks />
    public editionStmt editionStmt { get { return editionStmtField; } set { editionStmtField = value; } }

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