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
  public class refsDecl
  {
    private string doctypeField;

    private object[] itemsField;

    private string tEIformField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string doctype
    {
      get => doctypeField;
      set => doctypeField = value;
    }

    /// <remarks />
    [XmlElement("state", typeof(state))]
    [XmlElement("step", typeof(step))]
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