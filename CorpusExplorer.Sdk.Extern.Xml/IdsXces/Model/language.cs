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
  public class language
  {
    private string idField;

    private string usageField;

    private string valueField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string usage
    {
      get => usageField;
      set => usageField = value;
    }

    /// <remarks />
    [XmlText(DataType = "NCName")]
    public string Value
    {
      get => valueField;
      set => valueField = value;
    }
  }
}