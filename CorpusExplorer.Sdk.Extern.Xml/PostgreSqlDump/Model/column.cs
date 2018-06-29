using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class column
  {
    private string nameField;

    private string typeField;

    private string valueField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type
    {
      get => typeField;
      set => typeField = value;
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