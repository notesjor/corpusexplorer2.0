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
  public class persName
  {
    private foreign foreignField;

    private string keyField;

    private string langField;

    private string tEIformField;

    /// <remarks />
    public foreign foreign
    {
      get => foreignField;
      set => foreignField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string key
    {
      get => keyField;
      set => keyField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string lang
    {
      get => langField;
      set => langField = value;
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