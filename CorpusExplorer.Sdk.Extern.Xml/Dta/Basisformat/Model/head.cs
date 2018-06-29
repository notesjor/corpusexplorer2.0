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
  public class head
  {
    private string idField;

    private object[] itemsField;

    private string langField;

    private string nextField;

    private string prevField;

    private string renditionField;

    private string[] textField;

    private string typeField;

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("cb", typeof(cb))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("cit", typeof(cit))]
    [XmlElement("date", typeof(date))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("floatingText", typeof(floatingText))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("formula", typeof(formula))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("l", typeof(l))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("list", typeof(list))]
    [XmlElement("metamark", typeof(metamark))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("name", typeof(name))]
    [XmlElement("note", typeof(note))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("ref", typeof(@ref))]
    [XmlElement("space", typeof(space))]
    [XmlElement("subst", typeof(subst))]
    [XmlElement("supplied", typeof(supplied))]
    [XmlElement("unclear", typeof(unclear))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang
    {
      get => langField;
      set => langField = value;
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
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
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