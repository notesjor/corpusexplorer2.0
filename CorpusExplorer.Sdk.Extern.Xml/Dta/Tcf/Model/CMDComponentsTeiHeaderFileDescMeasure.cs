using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescMeasure
  {
    /// <remarks />
    [XmlAttribute]
    public string type { get; set; }

    /// <remarks />
    [XmlText]
    public uint Value { get; set; }
  }
}