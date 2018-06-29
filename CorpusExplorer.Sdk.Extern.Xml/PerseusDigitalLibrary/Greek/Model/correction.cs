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
  public class correction
  {
    private string defaultField;

    private string methodField;

    private p pField;

    private string statusField;

    private string tEIformField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string @default
    {
      get => defaultField;
      set => defaultField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string method
    {
      get => methodField;
      set => methodField = value;
    }

    /// <remarks />
    public p p
    {
      get => pField;
      set => pField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string status
    {
      get => statusField;
      set => statusField = value;
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