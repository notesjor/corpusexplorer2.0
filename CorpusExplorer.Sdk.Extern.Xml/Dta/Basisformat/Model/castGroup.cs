using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class castGroup
  {
    private head headField;

    private object[] itemsField;

    private string renditionField;

    /// <remarks />
    public head head { get { return headField; } set { headField = value; } }

    /// <remarks />
    [XmlElement("castGroup", typeof(castGroup))]
    [XmlElement("castItem", typeof(castItem))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("roleDesc", typeof(roleDesc))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }
  }
}