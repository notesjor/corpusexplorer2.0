using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/metadata")]
  [XmlRoot(Namespace = "http://www.dspin.de/data/metadata", IsNullable = false)]
  public class MetaData
  {
    /// <remarks />
    public MetaDataServices Services { get; set; }

    /// <remarks />
    public string source { get; set; }
  }
}