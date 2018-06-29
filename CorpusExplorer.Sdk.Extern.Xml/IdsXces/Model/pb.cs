using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class pb
  {
    private string idField;

    private string nField;

    private string tEIformField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string n
    {
      get => nField;
      set => nField = value;
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