using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDResourcesResourceProxyResourceType
  {
    /// <remarks />
    [XmlAttribute]
    public string mimetype { get; set; }

    /// <remarks />
    [XmlText]
    public string Value { get; set; }
  }
}