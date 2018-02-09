using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescSourceDescBiblFullPublicationStmt
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescBiblFullPublicationStmtDate date { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescBiblFullPublicationStmtPublisher publisher { get; set; }

    /// <remarks />
    public string pubPlace { get; set; }
  }
}