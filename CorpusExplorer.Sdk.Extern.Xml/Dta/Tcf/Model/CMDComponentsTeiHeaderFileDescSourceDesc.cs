using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescSourceDesc
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescBibl bibl { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescBiblFull biblFull { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescMsDesc msDesc { get; set; }
  }
}