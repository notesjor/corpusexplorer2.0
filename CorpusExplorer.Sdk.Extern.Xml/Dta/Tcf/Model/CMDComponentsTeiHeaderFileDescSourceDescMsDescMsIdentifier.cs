using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescSourceDescMsDescMsIdentifier
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescMsDescMsIdentifierIdno idno { get; set; }

    /// <remarks />
    public string repository { get; set; }
  }
}