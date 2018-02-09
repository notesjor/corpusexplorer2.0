using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescTitleStmtRespStmtRespRef
  {
    /// <remarks />
    [XmlAttribute]
    public string target { get; set; }
  }
}