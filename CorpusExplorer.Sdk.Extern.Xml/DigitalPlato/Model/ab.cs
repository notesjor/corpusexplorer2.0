using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.DigitalPlato.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class ab
  {
    private ItemsChoiceType1[] itemsElementNameField;

    private object[] itemsField;

    private string l0Field;

    private string l1Field;

    private string l2Field;

    private string l6Field;

    private string l7Field;

    private string l8Field;

    private string l9Field;

    private string[] textField;

    /// <remarks />
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("note", typeof(note))]
    [XmlElement("speaker", typeof(string))]
    [XmlElement("title", typeof(string))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType1[] ItemsElementName
    {
      get => itemsElementNameField;
      set => itemsElementNameField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string l0
    {
      get => l0Field;
      set => l0Field = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string l1
    {
      get => l1Field;
      set => l1Field = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string l2
    {
      get => l2Field;
      set => l2Field = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string l6
    {
      get => l6Field;
      set => l6Field = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string l7
    {
      get => l7Field;
      set => l7Field = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string l8
    {
      get => l8Field;
      set => l8Field = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string l9
    {
      get => l9Field;
      set => l9Field = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }
  }
}