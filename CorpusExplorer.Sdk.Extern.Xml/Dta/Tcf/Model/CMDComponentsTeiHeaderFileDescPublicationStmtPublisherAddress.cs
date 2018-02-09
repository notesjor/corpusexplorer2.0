using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescPublicationStmtPublisherAddress
  {
    /// <remarks />
    public string addrLine { get; set; }

    /// <remarks />
    public string country { get; set; }
  }
}