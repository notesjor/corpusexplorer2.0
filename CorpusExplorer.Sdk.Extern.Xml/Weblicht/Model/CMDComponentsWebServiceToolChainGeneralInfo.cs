using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsWebServiceToolChainGeneralInfo
  {
    /// <remarks />
    public CMDComponentsWebServiceToolChainGeneralInfoDescriptions Descriptions { get; set; }

    /// <remarks />
    public string ResourceClass { get; set; }

    /// <remarks />
    public string ResourceName { get; set; }
  }
}