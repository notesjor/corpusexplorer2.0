using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Gate.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class Name
  {
    private string classNameField;

    private string valueField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string className
    {
      get => classNameField;
      set => classNameField = value;
    }

    /// <remarks />
    [XmlText(DataType = "anyURI")]
    public string Value
    {
      get => valueField;
      set => valueField = value;
    }
  }
}