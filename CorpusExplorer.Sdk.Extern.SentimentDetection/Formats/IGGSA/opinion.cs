using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.SentimentDetection.Formats.IGGSA
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class opinion
  {
    private double polarityField;

    private string sourceField;

    /// <remarks />
    [XmlAttribute]
    public double polarity
    {
      get => polarityField;
      set => polarityField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string source
    {
      get => sourceField;
      set => sourceField = value;
    }
  }
}