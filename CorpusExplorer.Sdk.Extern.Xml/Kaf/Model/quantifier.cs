using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Kaf.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class quantifier
  {
    private string qidField;

    private span[] spanField;

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string qid
    {
      get => qidField;
      set => qidField = value;
    }

    /// <remarks />
    [XmlElement("span")]
    public span[] span
    {
      get => spanField;
      set => spanField = value;
    }
  }
}