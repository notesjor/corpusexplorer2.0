using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescPublicationStmt
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescPublicationStmtAvailability availability { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescPublicationStmtDate date { get; set; }

    /// <remarks />
    [XmlArrayItem("idno", IsNullable = false)]
    public CMDComponentsTeiHeaderFileDescPublicationStmtIdno[] idno { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescPublicationStmtPublisher publisher { get; set; }

    /// <remarks />
    public string pubPlace { get; set; }
  }
}