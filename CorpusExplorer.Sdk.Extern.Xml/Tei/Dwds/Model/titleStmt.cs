using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds.Model
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
    private editor editorField;

    private respStmt respStmtField;

    private title titleField;

    /// <remarks />
    public editor editor
    {
      get => editorField;
      set => editorField = value;
    }

    /// <remarks />
    public respStmt respStmt
    {
      get => respStmtField;
      set => respStmtField = value;
    }

    /// <remarks />
    public title title
    {
      get => titleField;
      set => titleField = value;
    }
  }
}