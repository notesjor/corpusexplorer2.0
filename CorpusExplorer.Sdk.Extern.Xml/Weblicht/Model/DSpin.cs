using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data")]
  [XmlRoot("D-Spin", Namespace = "http://www.dspin.de/data", IsNullable = false)]
  public class DSpin
  {
    /// <remarks />
    [XmlElement(Namespace = "http://www.dspin.de/data/metadata")]
    public MetaData MetaData { get; set; }

    /// <remarks />
    [XmlElement(Namespace = "http://www.dspin.de/data/textcorpus")]
    public TextCorpus TextCorpus { get; set; }

    /// <remarks />
    [XmlAttribute]
    public decimal version { get; set; }
  }
}