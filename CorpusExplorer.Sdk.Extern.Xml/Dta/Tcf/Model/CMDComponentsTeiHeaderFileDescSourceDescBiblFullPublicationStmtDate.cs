using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescSourceDescBiblFullPublicationStmtDate
  {
    /// <remarks />
    [XmlAttribute]
    public string type { get; set; }

    /// <remarks />
    [XmlText]
    public ushort Value { get; set; }
  }
}