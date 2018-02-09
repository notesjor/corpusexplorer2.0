using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/metadata")]
  public class MetaDataSource
  {
    /// <remarks />
    [XmlElement(Namespace = "http://www.clarin.eu/cmd/")]
    public CMD CMD { get; set; }
  }
}