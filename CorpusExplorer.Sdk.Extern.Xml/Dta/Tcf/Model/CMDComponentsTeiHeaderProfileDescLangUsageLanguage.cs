using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderProfileDescLangUsageLanguage
  {
    /// <remarks />
    [XmlAttribute]
    public string ident { get; set; }

    /// <remarks />
    [XmlText]
    public string Value { get; set; }
  }
}