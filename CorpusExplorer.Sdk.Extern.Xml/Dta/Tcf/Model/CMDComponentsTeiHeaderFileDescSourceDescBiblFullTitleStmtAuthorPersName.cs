using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescSourceDescBiblFullTitleStmtAuthorPersName
  {
    /// <remarks />
    public string forename { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescBiblFullTitleStmtAuthorPersNameIdno idno { get; set; }

    /// <remarks />
    public string surname { get; set; }
  }
}