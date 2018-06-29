using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class fileDesc
  {
    private extent extentField;

    private notesStmt notesStmtField;

    private publicationStmt publicationStmtField;

    private sourceDesc sourceDescField;

    private string tEIformField;

    private titleStmt titleStmtField;

    /// <remarks />
    public extent extent
    {
      get => extentField;
      set => extentField = value;
    }

    /// <remarks />
    public notesStmt notesStmt
    {
      get => notesStmtField;
      set => notesStmtField = value;
    }

    /// <remarks />
    public publicationStmt publicationStmt
    {
      get => publicationStmtField;
      set => publicationStmtField = value;
    }

    /// <remarks />
    public sourceDesc sourceDesc
    {
      get => sourceDescField;
      set => sourceDescField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string TEIform
    {
      get => tEIformField;
      set => tEIformField = value;
    }

    /// <remarks />
    public titleStmt titleStmt
    {
      get => titleStmtField;
      set => titleStmtField = value;
    }
  }
}