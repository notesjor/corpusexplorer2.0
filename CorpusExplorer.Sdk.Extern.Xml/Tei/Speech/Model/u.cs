#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class u
  {
    private object[] itemsField;
    private string whoField;

    /// <remarks />
    [XmlElement("anchor", typeof(anchor))]
    [XmlElement("seg", typeof(seg))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string who { get { return whoField; } set { whoField = value; } }
  }
}