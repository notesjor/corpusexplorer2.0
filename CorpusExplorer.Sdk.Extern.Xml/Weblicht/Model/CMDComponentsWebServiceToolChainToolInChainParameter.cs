using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsWebServiceToolChainToolInChainParameter
  {
    /// <remarks />
    [XmlAttribute]
    public string name { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string value { get; set; }
  }
}