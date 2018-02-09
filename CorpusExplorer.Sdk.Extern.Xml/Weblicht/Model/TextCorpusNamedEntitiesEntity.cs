using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusNamedEntitiesEntity
  {
    /// <remarks />
    [XmlAttribute]
    public string @class { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string tokenIDs { get; set; }
  }
}