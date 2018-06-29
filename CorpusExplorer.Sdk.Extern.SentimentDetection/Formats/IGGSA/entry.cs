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
  public class entry
  {
    private opinion[] opinionField;

    private string termField;

    /// <remarks />
    [XmlElement("opinion")]
    public opinion[] opinion
    {
      get => opinionField;
      set => opinionField = value;
    }

    /// <remarks />
    public string term
    {
      get => termField;
      set => termField = value;
    }
  }
}