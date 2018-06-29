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
  public class xptr
  {
    private string docField;

    private string fromField;

    private string targOrderField;

    private string targTypeField;

    private string tEIformField;

    private string toField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string doc
    {
      get => docField;
      set => docField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string from
    {
      get => fromField;
      set => fromField = value;
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
    public string TEIform
    {
      get => tEIformField;
      set => tEIformField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string to
    {
      get => toField;
      set => toField = value;
    }
  }
}