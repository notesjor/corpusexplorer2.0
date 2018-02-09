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
  [XmlRoot("div", Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class frontModeldivLikeDiv
  {
    private head[] headField;
    private ItemsChoiceType2[] itemsElementNameField;
    private object[] itemsField;

    /// <remarks />
    [XmlElement("div", typeof(frontModeldivLikeDiv))]
    [XmlElement("model.common", typeof(object))]
    [XmlElement("model.divLike", typeof(frontModeldivLikeDiv))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType2[] ItemsElementName
    {
      get { return itemsElementNameField; }
      set { itemsElementNameField = value; }
    }

    /// <remarks />
    [XmlElement("head")]
    public head[] head { get { return headField; } set { headField = value; } }
  }
}