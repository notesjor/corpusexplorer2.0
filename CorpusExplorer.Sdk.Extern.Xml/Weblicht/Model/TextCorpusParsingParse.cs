using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusParsingParse
  {
    /// <remarks />
    public TextCorpusParsingParseConstituent constituent { get; set; }
  }
}