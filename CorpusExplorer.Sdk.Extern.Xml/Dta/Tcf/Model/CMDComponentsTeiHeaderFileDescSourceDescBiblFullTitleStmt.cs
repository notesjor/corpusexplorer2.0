using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescSourceDescBiblFullTitleStmt
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescBiblFullTitleStmtAuthor author { get; set; }

    /// <remarks />
    [XmlElement("title")]
    public CMDComponentsTeiHeaderFileDescSourceDescBiblFullTitleStmtTitle[] title { get; set; }
  }
}