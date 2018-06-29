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
  public class div3
  {
    private div4[] div4Field;

    private object itemField;

    private string nField;

    private string orgField;

    private string partField;

    private p[] pField;

    private string sampleField;

    private string tEIformField;

    private string typeField;

    /// <remarks />
    [XmlElement("head", typeof(head))]
    [XmlElement("label", typeof(label))]
    public object Item
    {
      get => itemField;
      set => itemField = value;
    }

    /// <remarks />
    [XmlElement("p")]
    public p[] p
    {
      get => pField;
      set => pField = value;
    }

    /// <remarks />
    [XmlElement("div4")]
    public div4[] div4
    {
      get => div4Field;
      set => div4Field = value;
    }


    /// <remarks />
    [XmlAttribute]
    public string n
    {
      get => nField;
      set => nField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string org
    {
      get => orgField;
      set => orgField = value;
    }


    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string part
    {
      get => partField;
      set => partField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string sample
    {
      get => sampleField;
      set => sampleField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string TEIform
    {
      get => tEIformField;
      set => tEIformField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}