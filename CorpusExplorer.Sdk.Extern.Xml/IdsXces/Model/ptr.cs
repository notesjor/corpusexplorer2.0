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
  public class ptr
  {
    private string rendField;

    private string targetField;

    private string targOrderField;

    private string targTypeField;

    private string typeField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string rend
    {
      get => rendField;
      set => rendField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string target
    {
      get => targetField;
      set => targetField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string targOrder
    {
      get => targOrderField;
      set => targOrderField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string targType
    {
      get => targTypeField;
      set => targTypeField = value;
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