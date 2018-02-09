using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescTitleStmtRespStmt
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescTitleStmtRespStmtOrgName orgName { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescTitleStmtRespStmtResp resp { get; set; }
  }
}