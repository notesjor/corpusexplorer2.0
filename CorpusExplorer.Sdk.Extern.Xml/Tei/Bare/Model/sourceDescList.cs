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
  [XmlRoot("list", Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class sourceDescList
  {
    private head[] headField;
    private object[] itemsField;
    private string typeField;

    public sourceDescList() { typeField = "simple"; }

    /// <remarks />
    [XmlElement("item", typeof(item))]
    [XmlElement("label", typeof(label))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlElement("head")]
    public head[] head { get { return headField; } set { headField = value; } }


    /// <remarks />
    [XmlAttribute]
    [DefaultValue("simple")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}