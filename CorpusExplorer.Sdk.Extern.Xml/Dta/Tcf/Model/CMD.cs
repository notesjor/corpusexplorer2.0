using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  [XmlRoot(Namespace = "http://www.clarin.eu/cmd/", IsNullable = false)]
  public class CMD
  {
    /// <remarks />
    [XmlAttribute]
    public decimal CMDVersion { get; set; }

    /// <remarks />
    public CMDComponents Components { get; set; }

    /// <remarks />
    public CMDHeader Header { get; set; }

    /// <remarks />
    public CMDResources Resources { get; set; }
  }
}