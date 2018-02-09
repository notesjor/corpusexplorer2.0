using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDResourcesResourceProxy
  {
    /// <remarks />
    [XmlAttribute]
    public string id { get; set; }

    /// <remarks />
    public string ResourceRef { get; set; }

    /// <remarks />
    public CMDResourcesResourceProxyResourceType ResourceType { get; set; }
  }
}