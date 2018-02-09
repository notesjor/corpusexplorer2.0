using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusParsingParseConstituentConstituent
  {
    /// <remarks />
    [XmlAttribute]
    public string cat { get; set; }

    /// <remarks />
    [XmlElement("constituent")]
    public TextCorpusParsingParseConstituentConstituent[] constituent { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string tokenIDs { get; set; }
  }
}