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
  public class state
  {
    private string delimField;

    private string nField;

    private string tEIformField;

    private string unitField;

    /// <remarks />
    [XmlAttribute]
    public string delim
    {
      get => delimField;
      set => delimField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
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

    /// <remarks />
    [XmlAttribute]
    public string unit
    {
      get => unitField;
      set => unitField = value;
    }
  }
}