using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusNamedEntities
  {
    /// <remarks />
    [XmlElement("entity")]
    public TextCorpusNamedEntitiesEntity[] entity { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string type { get; set; }
  }
}