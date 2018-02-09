#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class back
  {
    private ItemsChoiceType4[] itemsElementNameField;
    private object[] itemsField;

    /// <remarks />
    [XmlElement("head", typeof(head))]
    [XmlElement("list", typeof(sourceDescList))]
    [XmlElement("model.listLike", typeof(sourceDescList))]
    [XmlElement("model.pLike", typeof(modeldivPart))]
    [XmlElement("p", typeof(modeldivPart))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType4[] ItemsElementName
    {
      get { return itemsElementNameField; }
      set { itemsElementNameField = value; }
    }
  }
}