using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsWebServiceToolChainToolInChain
  {
    /// <remarks />
    [XmlElement("Parameter")]
    public CMDComponentsWebServiceToolChainToolInChainParameter[] Parameter { get; set; }

    /// <remarks />
    public string PID { get; set; }
  }
}