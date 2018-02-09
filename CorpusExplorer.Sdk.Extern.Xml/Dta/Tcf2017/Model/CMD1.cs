namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1")]
  [System.Xml.Serialization.XmlRootAttribute("CMD", Namespace = "http://www.clarin.eu/cmd/1", IsNullable = false)]
  public partial class CMD1
  {

    private Header headerField;

    private Resources resourcesField;

    private teiHeader componentsField;

    private string cMDVersionField;

    /// <remarks/>
    public Header Header
    {
      get
      {
        return this.headerField;
      }
      set
      {
        this.headerField = value;
      }
    }

    /// <remarks/>
    public Resources Resources
    {
      get
      {
        return this.resourcesField;
      }
      set
      {
        this.resourcesField = value;
      }
    }

    /// <remarks/>
    public teiHeader Components
    {
      get
      {
        return this.componentsField;
      }
      set
      {
        this.componentsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CMDVersion
    {
      get
      {
        return this.cMDVersionField;
      }
      set
      {
        this.cMDVersionField = value;
      }
    }
  }
}