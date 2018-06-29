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
  public class figure
  {
    private head headField;

    private string idField;

    private pb pbField;

    private p[] pField;

    private quote quoteField;

    /// <remarks />
    public head head
    {
      get => headField;
      set => headField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement("p")]
    public p[] p
    {
      get => pField;
      set => pField = value;
    }

    /// <remarks />
    public pb pb
    {
      get => pbField;
      set => pbField = value;
    }

    /// <remarks />
    public quote quote
    {
      get => quoteField;
      set => quoteField = value;
    }
  }
}