using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusGeoGpoint
  {
    /// <remarks />
    [XmlAttribute]
    public decimal alt { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string capital { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string continent { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string country { get; set; }

    /// <remarks />
    [XmlAttribute]
    public decimal lat { get; set; }

    /// <remarks />
    [XmlAttribute]
    public decimal lon { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string tokenIDs { get; set; }
  }
}