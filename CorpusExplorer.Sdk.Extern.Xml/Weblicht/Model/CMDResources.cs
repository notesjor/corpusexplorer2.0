using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDResources
  {
    /// <remarks />
    public object JournalFileProxyList { get; set; }

    /// <remarks />
    public object ResourceProxyList { get; set; }

    /// <remarks />
    public object ResourceRelationList { get; set; }
  }
}