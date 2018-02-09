using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescSourceDescBiblFull
  {
    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescBiblFullEditionStmt editionStmt { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescBiblFullExtent extent { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescBiblFullPublicationStmt publicationStmt { get; set; }

    /// <remarks />
    public CMDComponentsTeiHeaderFileDescSourceDescBiblFullTitleStmt titleStmt { get; set; }
  }
}