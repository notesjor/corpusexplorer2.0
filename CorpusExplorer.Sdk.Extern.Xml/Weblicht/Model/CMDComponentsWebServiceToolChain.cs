using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsWebServiceToolChain
  {
    /// <remarks />
    public CMDComponentsWebServiceToolChainGeneralInfo GeneralInfo { get; set; }

    /// <remarks />
    [XmlArrayItem("ToolInChain", IsNullable = false)]
    public CMDComponentsWebServiceToolChainToolInChain[] Toolchain { get; set; }
  }
}