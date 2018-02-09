using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class titleStmt
  {
    private ItemsChoiceType[] itemsElementNameField;

    private object[] itemsField;

    /// <remarks />
    [XmlElement("c.title", typeof(string))]
    [XmlElement("d.title", typeof(string))]
    [XmlElement("dokumentSigle", typeof(string))]
    [XmlElement("korpusSigle", typeof(string), DataType = "NCName")]
    [XmlElement("t.title", typeof(ttitle))]
    [XmlElement("textSigle", typeof(string))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType[] ItemsElementName
    {
      get { return itemsElementNameField; }
      set { itemsElementNameField = value; }
    }
  }
}