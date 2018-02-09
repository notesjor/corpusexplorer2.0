using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusCorrection
  {
    /// <remarks />
    [XmlAttribute]
    public string operation { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string tokenIDs { get; set; }

    /// <remarks />
    [XmlText]
    public string Value { get; set; }
  }
}