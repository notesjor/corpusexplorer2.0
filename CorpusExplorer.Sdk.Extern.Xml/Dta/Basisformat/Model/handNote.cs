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
  public class handNote
  {
    private string idField;

    private string mediumField;

    private persName[] persNameField;

    private string scopeField;

    private string scribeField;

    private string scribeRefField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string medium
    {
      get => mediumField;
      set => mediumField = value;
    }

    /// <remarks />
    [XmlElement("persName")]
    public persName[] persName
    {
      get => persNameField;
      set => persNameField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string scope
    {
      get => scopeField;
      set => scopeField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string scribe
    {
      get => scribeField;
      set => scribeField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string scribeRef
    {
      get => scribeRefField;
      set => scribeRefField = value;
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