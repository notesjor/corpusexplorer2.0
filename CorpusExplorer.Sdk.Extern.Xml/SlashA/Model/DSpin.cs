using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.SlashA.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data")]
  [XmlRoot("D-Spin", Namespace = "http://www.dspin.de/data", IsNullable = false)]
  public class DSpin
  {
    private MetaData metaDataField;

    private TextCorpus textCorpusField;

    private decimal versionField;

    /// <remarks />
    [XmlElement(Namespace = "http://www.dspin.de/data/metadata")]
    public MetaData MetaData { get { return metaDataField; } set { metaDataField = value; } }

    /// <remarks />
    [XmlElement(Namespace = "http://www.dspin.de/data/textcorpus")]
    public TextCorpus TextCorpus { get { return textCorpusField; } set { textCorpusField = value; } }

    /// <remarks />
    [XmlAttribute]
    public decimal version { get { return versionField; } set { versionField = value; } }
  }
}