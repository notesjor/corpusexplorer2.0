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
  public class sourceDesc
  {
    private biblStruct biblStructField;

    private string defaultField;

    private object itemField;

    private p pField;

    private string tEIformField;

    /// <remarks />
    public biblStruct biblStruct
    {
      get => biblStructField;
      set => biblStructField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string @default
    {
      get => defaultField;
      set => defaultField = value;
    }

    /// <remarks />
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("listBibl", typeof(listBibl))]
    public object Item
    {
      get => itemField;
      set => itemField = value;
    }

    /// <remarks />
    public p p
    {
      get => pField;
      set => pField = value;
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