using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDesc
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescEditionStmt editionStmt { get; set; }

    /// <remarks />
    [XmlArrayItem("measure", IsNullable = false)]
    public CMDComponentsTeiHeaderFileDescMeasure[] extent { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescPublicationStmt publicationStmt { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDesc sourceDesc { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescTitleStmt titleStmt { get; set; }
  }
}