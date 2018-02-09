using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescSourceDescMsDesc
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescMsDescMsIdentifier msIdentifier { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescMsDescPhysDesc physDesc { get; set; }
  }
}