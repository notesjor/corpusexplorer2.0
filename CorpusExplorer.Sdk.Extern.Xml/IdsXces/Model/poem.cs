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
  public class poem
  {
    private head headField;

    private lg[] lgField;

    /// <remarks />
    public head head
    {
      get => headField;
      set => headField = value;
    }

    /// <remarks />
    [XmlElement("lg")]
    public lg[] lg
    {
      get => lgField;
      set => lgField = value;
    }
  }
}