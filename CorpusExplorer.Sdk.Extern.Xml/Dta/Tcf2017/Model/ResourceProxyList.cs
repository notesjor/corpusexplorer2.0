using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1")]
  [XmlRoot(Namespace = "http://www.clarin.eu/cmd/1", IsNullable = false)]
  public class ResourceProxyList
  {
    private ResourceProxy[] resourceProxyField;

    /// <remarks />
    [XmlElement("ResourceProxy")]
    public ResourceProxy[] ResourceProxy
    {
      get => resourceProxyField;
      set => resourceProxyField = value;
    }
  }
}