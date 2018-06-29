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
  public class figure
  {
    private ab abField;

    private string correspField;

    private string facsField;

    private string figDescField;

    private string idField;

    private object item1Field;

    private object itemField;

    private object[] itemsField;

    private string nextField;

    private string prevField;

    private string rendField;

    private string renditionField;

    private table tableField;

    private string typeField;

    /// <remarks />
    public ab ab
    {
      get => abField;
      set => abField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string corresp
    {
      get => correspField;
      set => correspField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string facs
    {
      get => facsField;
      set => facsField = value;
    }

    /// <remarks />
    public string figDesc
    {
      get => figDescField;
      set => figDescField = value;
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
    [XmlElement("graphic", typeof(graphic))]
    [XmlElement("lg", typeof(lg))]
    public object Item
    {
      get => itemField;
      set => itemField = value;
    }

    /// <remarks />
    [XmlElement("cb", typeof(cb))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("head", typeof(head))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("list", typeof(list))]
    [XmlElement("note", typeof(note))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("signed", typeof(signed))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlElement("argument", typeof(argument))]
    [XmlElement("closer", typeof(closer))]
    [XmlElement("epigraph", typeof(epigraph))]
    public object Item1
    {
      get => item1Field;
      set => item1Field = value;
    }


    /// <remarks />
    [XmlAttribute]
    public string next
    {
      get => nextField;
      set => nextField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string prev
    {
      get => prevField;
      set => prevField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string rend
    {
      get => rendField;
      set => rendField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string rendition
    {
      get => renditionField;
      set => renditionField = value;
    }

    /// <remarks />
    public table table
    {
      get => tableField;
      set => tableField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}