using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderProfileDesc
  {
    /// <remarks />
    public CMDComponentsTeiHeaderProfileDescLangUsage langUsage { get; set; }

    /// <remarks />
    [XmlArrayItem("classCode", IsNullable = false)]
    public CMDComponentsTeiHeaderProfileDescClassCode[] textClass { get; set; }
  }
}