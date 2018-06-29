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
  public class docAuthor
  {
    private string langField;

    private note noteField;

    private persName persNameField;

    private string tEIformField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string lang
    {
      get => langField;
      set => langField = value;
    }

    /// <remarks />
    public note note
    {
      get => noteField;
      set => noteField = value;
    }

    /// <remarks />
    public persName persName
    {
      get => persNameField;
      set => persNameField = value;
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