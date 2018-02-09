using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescPublicationStmtAvailabilityLicence
  {
    /// <remarks />
    public string p { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string target { get; set; }
  }
}