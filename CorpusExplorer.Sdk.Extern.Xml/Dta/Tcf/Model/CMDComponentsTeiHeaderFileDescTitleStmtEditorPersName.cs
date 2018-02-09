using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescTitleStmtEditorPersName
  {
    /// <remarks />
    public string forename { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescTitleStmtEditorPersNameIdno idno { get; set; }

    /// <remarks />
    public string surname { get; set; }
  }
}