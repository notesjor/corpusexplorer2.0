using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeader
  {
    /// <remarks />
    public CMDComponentsTeiHeaderEncodingDesc encodingDesc { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDesc fileDesc { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderProfileDesc profileDesc { get; set; }
  }
}