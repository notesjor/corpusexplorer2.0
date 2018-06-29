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
  public class chunk
  {
    private string caseField;

    private string cidField;

    private string headField;

    private string phraseField;

    private span[] spanField;

    /// <remarks />
    [XmlAttribute]
    public string @case
    {
      get => caseField;
      set => caseField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string cid
    {
      get => cidField;
      set => cidField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string head
    {
      get => headField;
      set => headField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string phrase
    {
      get => phraseField;
      set => phraseField = value;
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