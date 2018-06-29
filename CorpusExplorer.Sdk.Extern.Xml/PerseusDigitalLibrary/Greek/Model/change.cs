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
  public class change
  {
    private date dateField;

    private item itemField;

    private respStmt respStmtField;

    private string tEIformField;

    /// <remarks />
    public date date
    {
      get => dateField;
      set => dateField = value;
    }

    /// <remarks />
    public item item
    {
      get => itemField;
      set => itemField = value;
    }

    /// <remarks />
    public respStmt respStmt
    {
      get => respStmtField;
      set => respStmtField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string TEIform
    {
      get => tEIformField;
      set => tEIformField = value;
    }
  }
}