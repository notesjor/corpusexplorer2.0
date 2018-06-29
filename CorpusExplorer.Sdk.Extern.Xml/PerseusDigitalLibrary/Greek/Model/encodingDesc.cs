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
  public class encodingDesc
  {
    private editorialDecl editorialDeclField;

    private refsDecl[] refsDeclField;

    private string tEIformField;

    /// <remarks />
    public editorialDecl editorialDecl
    {
      get => editorialDeclField;
      set => editorialDeclField = value;
    }

    /// <remarks />
    [XmlElement("refsDecl")]
    public refsDecl[] refsDecl
    {
      get => refsDeclField;
      set => refsDeclField = value;
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