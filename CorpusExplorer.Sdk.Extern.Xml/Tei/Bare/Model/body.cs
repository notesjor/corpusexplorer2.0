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
  public class body
  {
    // ReSharper disable once InconsistentNaming
    private head headField;
    private ItemsChoiceType3[] itemsElementNameField;
    private object[] itemsField;

    /// <remarks />
    [XmlElement(Order = 0)]
    public head head { get { return headField; } set { headField = value; } }

    /// <remarks />
    [XmlElement("div", typeof(frontModeldivLikeDiv), Order = 2)]
    [XmlElement("model.common", typeof(object), Order = 2)]
    [XmlElement("model.divLike", typeof(frontModeldivLikeDiv), Order = 2)]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlElement("ItemsElementName", Order = 3)]
    [XmlIgnore]
    public ItemsChoiceType3[] ItemsElementName
    {
      get { return itemsElementNameField; }
      set { itemsElementNameField = value; }
    }
  }
}