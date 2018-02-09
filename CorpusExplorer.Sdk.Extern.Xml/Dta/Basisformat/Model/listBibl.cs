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
  public class listBibl
  {
    private object[] itemsField;

    /// <remarks />
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("pb", typeof(pb))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }
  }
}