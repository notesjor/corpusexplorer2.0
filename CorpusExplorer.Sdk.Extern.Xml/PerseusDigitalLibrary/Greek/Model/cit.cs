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
  public class cit
  {
    private bibl[] biblField;

    private quote[] quoteField;

    private string tEIformField;

    /// <remarks />
    [XmlElement("quote")]
    public quote[] quote
    {
      get => quoteField;
      set => quoteField = value;
    }

    /// <remarks />
    [XmlElement("bibl")]
    public bibl[] bibl
    {
      get => biblField;
      set => biblField = value;
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