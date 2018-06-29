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
  public class publicationStmt
  {
    private authority authorityField;

    private publisher publisherField;

    private pubPlace pubPlaceField;

    private string tEIformField;

    /// <remarks />
    public authority authority
    {
      get => authorityField;
      set => authorityField = value;
    }

    /// <remarks />
    public publisher publisher
    {
      get => publisherField;
      set => publisherField = value;
    }

    /// <remarks />
    public pubPlace pubPlace
    {
      get => pubPlaceField;
      set => pubPlaceField = value;
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