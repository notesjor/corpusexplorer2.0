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
  [XmlRoot("CMD", Namespace = "http://www.clarin.eu/cmd/1", IsNullable = false)]
  public class CMD1
  {
    private string cMDVersionField;

    private teiHeader componentsField;

    private Header headerField;

    private Resources resourcesField;

    /// <remarks />
    [XmlAttribute]
    public string CMDVersion
    {
      get => cMDVersionField;
      set => cMDVersionField = value;
    }

    /// <remarks />
    public teiHeader Components
    {
      get => componentsField;
      set => componentsField = value;
    }

    /// <remarks />
    public Header Header
    {
      get => headerField;
      set => headerField = value;
    }

    /// <remarks />
    public Resources Resources
    {
      get => resourcesField;
      set => resourcesField = value;
    }
  }
}