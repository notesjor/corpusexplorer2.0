using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDResources
  {
    /// <remarks />
    public object IsPartOfList { get; set; }

    /// <remarks />
    public object JournalFileProxyList { get; set; }

    /// <remarks />
    [XmlArrayItem("ResourceProxy", IsNullable = false)]
    public CMDResourcesResourceProxy[] ResourceProxyList { get; set; }

    /// <remarks />
    public object ResourceRelationList { get; set; }
  }
}