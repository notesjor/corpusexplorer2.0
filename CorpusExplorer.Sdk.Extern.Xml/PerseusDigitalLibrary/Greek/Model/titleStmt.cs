using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class titleStmt
  {
    private object[] itemsField;

    private string tEIformField;

    private title[] titleField;

    /// <remarks />
    [XmlElement("title")]
    public title[] title
    {
      get => titleField;
      set => titleField = value;
    }

    /// <remarks />
    [XmlElement("author", typeof(author))]
    [XmlElement("editor", typeof(editor))]
    [XmlElement("funder", typeof(funder))]
    [XmlElement("principal", typeof(principal))]
    [XmlElement("respStmt", typeof(respStmt))]
    [XmlElement("sponsor", typeof(sponsor))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string TEIform
    {
      get => tEIformField;
      set => tEIformField = value;
    }
  }
}