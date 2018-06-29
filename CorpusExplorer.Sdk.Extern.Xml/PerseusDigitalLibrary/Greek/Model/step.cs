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
  public class step
  {
    private string fromField;

    private string refunitField;

    private string tEIformField;

    private string toField;

    /// <remarks />
    [XmlAttribute]
    public string from
    {
      get => fromField;
      set => fromField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string refunit
    {
      get => refunitField;
      set => refunitField = value;
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