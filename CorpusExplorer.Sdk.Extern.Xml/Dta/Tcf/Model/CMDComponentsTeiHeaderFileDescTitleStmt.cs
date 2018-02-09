using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescTitleStmt
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescTitleStmtAuthor author { get; set; }

    /// <remarks />
    [XmlElement("title")]
    public CMDComponentsTeiHeaderFileDescTitleStmtTitle[] title { get; set; }

    /// <remarks />
    [XmlElement("editor")]
    public CMDComponentsTeiHeaderFileDescTitleStmtEditor[] editor { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescTitleStmtRespStmt respStmt { get; set; }
  }
}