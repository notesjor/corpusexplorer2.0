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
  public class subst
  {
    private object[] itemsField;

    /// <remarks />
    [XmlElement("add", typeof(add))]
    [XmlElement("del", typeof(del))]
    [XmlElement("lb", typeof(lb))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }
  }
}