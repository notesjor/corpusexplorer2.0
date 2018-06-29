using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Wiki.Wikipedia.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class contributor
  {
    private ItemsChoiceType[] itemsElementNameField;
    private string[] itemsField;

    /// <remarks />
    [XmlElement("id", typeof(string), DataType = "integer")]
    [XmlElement("ip", typeof(string), DataType = "NMTOKEN")]
    [XmlElement("username", typeof(string))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public string[] Items
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
  }
}