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
  public class div2
  {
    private div3[] div3Field;

    private object[] items1Field;

    private object[] itemsField;

    private lg[] lgField;

    private string metField;

    private string nField;

    private string orgField;

    private string partField;

    private p[] pField;

    private string sampleField;

    private string tEIformField;

    private string typeField;

    /// <remarks />
    [XmlElement("label", typeof(label))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("sp", typeof(sp))]
    public object[] Items1
    {
      get => items1Field;
      set => items1Field = value;
    }

    /// <remarks />
    [XmlElement("p")]
    public p[] p
    {
      get => pField;
      set => pField = value;
    }

    /// <remarks />
    [XmlElement("div3")]
    public div3[] div3
    {
      get => div3Field;
      set => div3Field = value;
    }

    /// <remarks />
    [XmlElement("docAuthor", typeof(docAuthor))]
    [XmlElement("head", typeof(head))]
    [XmlElement("l", typeof(l))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlElement("lg")]
    public lg[] lg
    {
      get => lgField;
      set => lgField = value;
    }


    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string met
    {
      get => metField;
      set => metField = value;
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