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
  public class editorialDecl
  {
    private correction correctionField;

    private string defaultField;

    private string tEIformField;

    /// <remarks />
    public correction correction
    {
      get => correctionField;
      set => correctionField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string @default
    {
      get => defaultField;
      set => defaultField = value;
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