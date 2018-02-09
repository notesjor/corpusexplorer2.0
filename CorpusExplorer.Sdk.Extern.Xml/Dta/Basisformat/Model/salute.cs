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
  public class salute
  {
    private string idField;

    private object[] itemsField;

    private string nextField;

    private string prevField;

    private string renditionField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("cb", typeof(cb))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("cit", typeof(cit))]
    [XmlElement("date", typeof(date))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("lg", typeof(lg))]
    [XmlElement("list", typeof(list))]
    [XmlElement("note", typeof(note))]
    [XmlElement("supplied", typeof(supplied))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string next { get { return nextField; } set { nextField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string prev { get { return prevField; } set { prevField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}