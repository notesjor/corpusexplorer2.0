using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
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
  public class foreign
  {
    private bool is_a_numberField;

    private bool is_a_numberFieldSpecified;

    private ItemsChoiceType[] itemsElementNameField;

    private object[] itemsField;

    private string langField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute]
    public bool is_a_number
    {
      get => is_a_numberField;
      set => is_a_numberField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool is_a_numberSpecified
    {
      get => is_a_numberFieldSpecified;
      set => is_a_numberFieldSpecified = value;
    }

    /// <remarks />
    [XmlElement("hi", typeof(hi))]
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
    public ItemsChoiceType[] ItemsElementName
    {
      get => itemsElementNameField;
      set => itemsElementNameField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang
    {
      get => langField;
      set => langField = value;
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