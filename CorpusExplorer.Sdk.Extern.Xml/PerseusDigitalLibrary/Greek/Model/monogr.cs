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
  public class monogr
  {
    private biblScope biblScopeField;

    private imprint imprintField;

    private object itemField;

    private object[] itemsField;

    private string tEIformField;

    /// <remarks />
    public biblScope biblScope
    {
      get => biblScopeField;
      set => biblScopeField = value;
    }

    /// <remarks />
    public imprint imprint
    {
      get => imprintField;
      set => imprintField = value;
    }

    /// <remarks />
    [XmlElement("author", typeof(author))]
    [XmlElement("title", typeof(title))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlElement("editor", typeof(editor))]
    [XmlElement("respStmt", typeof(respStmt))]
    public object Item
    {
      get => itemField;
      set => itemField = value;
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