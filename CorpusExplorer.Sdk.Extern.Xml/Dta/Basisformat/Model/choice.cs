using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
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
  public class choice
  {
    private string correspField;

    private string idField;

    private object[] itemsField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute]
    public string corresp
    {
      get => correspField;
      set => correspField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement("abbr", typeof(abbr))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("corr", typeof(corr))]
    [XmlElement("expan", typeof(expan))]
    [XmlElement("orig", typeof(orig))]
    [XmlElement("reg", typeof(reg))]
    [XmlElement("sic", typeof(sic))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }
  }
}