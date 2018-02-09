using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponents
  {
    /// <remarks />
    public CMDComponentsWebServiceToolChain WebServiceToolChain { get; set; }
  }
}