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
  public class cell
  {
    private string colsField;

    private string correspField;

    private string idField;

    private object[] itemsField;

    private string nextField;

    private string prevField;

    private string renditionField;

    private string roleField;

    private string rowsField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string cols
    {
      get => colsField;
      set => colsField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
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
    [XmlElement("add", typeof(add))]
    [XmlElement("cb", typeof(cb))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("cit", typeof(cit))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("formula", typeof(formula))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("g", typeof(g))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("list", typeof(list))]
    [XmlElement("metamark", typeof(metamark))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("note", typeof(note))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("ref", typeof(@ref))]
    [XmlElement("space", typeof(space))]
    [XmlElement("subst", typeof(subst))]
    [XmlElement("supplied", typeof(supplied))]
    [XmlElement("table", typeof(table))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
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
    [XmlAttribute]
    public string rendition
    {
      get => renditionField;
      set => renditionField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string role
    {
      get => roleField;
      set => roleField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string rows
    {
      get => rowsField;
      set => rowsField = value;
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