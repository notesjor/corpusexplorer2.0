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
  public class sp
  {
    private object[] itemsField;

    private string nField;

    private p[] pField;

    private string tEIformField;

    /// <remarks />
    [XmlElement("l", typeof(l))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("speaker", typeof(speaker))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string n
    {
      get => nField;
      set => nField = value;
    }

    /// <remarks />
    [XmlElement("p")]
    public p[] p
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