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
  public class linguisticProcessors
  {
    private string layerField;

    private lp[] lpField;

    /// <remarks />
    [XmlAttribute]
    public string layer
    {
      get => layerField;
      set => layerField = value;
    }

    /// <remarks />
    [XmlElement("lp")]
    public lp[] lp
    {
      get => lpField;
      set => lpField = value;
    }
  }
}