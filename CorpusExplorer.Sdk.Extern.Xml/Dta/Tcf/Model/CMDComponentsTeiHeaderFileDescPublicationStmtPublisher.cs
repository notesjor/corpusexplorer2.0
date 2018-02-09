using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescPublicationStmtPublisher
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescPublicationStmtPublisherAddress address { get; set; }

    /// <remarks />
    public string email { get; set; }

    /// <remarks />
    [XmlArrayItem("orgName", IsNullable = false)]
    public CMDComponentsTeiHeaderFileDescPublicationStmtPublisherOrgName[] orgName { get; set; }
  }
}