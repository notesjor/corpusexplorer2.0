using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusParsing
  {
    /// <remarks />
    [XmlElement("parse")]
    public TextCorpusParsingParse[] parse { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string tagset { get; set; }
  }
}