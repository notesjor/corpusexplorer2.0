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
  [XmlRoot("t.title", Namespace = "", IsNullable = false)]
  public class ttitle
  {
    private string assemblageField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string assemblage
    {
      get => assemblageField;
      set => assemblageField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }
  }
}