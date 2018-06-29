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
  public class ResourceProxy
  {
    private string idField;

    private string resourceRefField;

    private ResourceType resourceTypeField;

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    public string ResourceRef
    {
      get => resourceRefField;
      set => resourceRefField = value;
    }

    /// <remarks />
    public ResourceType ResourceType
    {
      get => resourceTypeField;
      set => resourceTypeField = value;
    }
  }
}