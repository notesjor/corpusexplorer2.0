using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PromXes.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.xes-standard.org/")]
  [XmlRoot(Namespace = "http://www.xes-standard.org/", IsNullable = false)]
  public class @event
  {
    private object[] itemsField;

    /// <remarks />
    [XmlElement("date", typeof(date))]
    [XmlElement("string", typeof(@string))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }
  }
}