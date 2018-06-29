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
  public class tagUsage
  {
    private string giField;

    private string occursField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string gi
    {
      get => giField;
      set => giField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string occurs
    {
      get => occursField;
      set => occursField = value;
    }
  }
}