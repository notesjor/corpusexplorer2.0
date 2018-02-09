using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusGeo
  {
    /// <remarks />
    [XmlAttribute]
    public string capitalFormat { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string continentFormat { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string coordFormat { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string countryFormat { get; set; }

    /// <remarks />
    [XmlElement("gpoint")]
    public TextCorpusGeoGpoint[] gpoint { get; set; }

    /// <remarks />
    public string src { get; set; }
  }
}