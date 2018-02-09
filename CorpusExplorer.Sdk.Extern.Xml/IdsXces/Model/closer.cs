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
  public class closer
  {
    private object[] itemsField;

    /// <remarks />
    [XmlElement("dateline", typeof(dateline))]
    [XmlElement("salute", typeof(salute))]
    [XmlElement("signed", typeof(signed))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }
  }
}