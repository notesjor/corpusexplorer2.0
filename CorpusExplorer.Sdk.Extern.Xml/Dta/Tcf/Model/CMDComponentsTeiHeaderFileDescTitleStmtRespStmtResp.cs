using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescTitleStmtRespStmtResp
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescTitleStmtRespStmtRespNote note { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescTitleStmtRespStmtRespRef @ref { get; set; }
  }
}