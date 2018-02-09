namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1", IsNullable = false)]
  public partial class ResourceProxy
  {

    private ResourceType resourceTypeField;

    private string resourceRefField;

    private string idField;

    /// <remarks/>
    public ResourceType ResourceType
    {
      get
      {
        return this.resourceTypeField;
      }
      set
      {
        this.resourceTypeField = value;
      }
    }

    /// <remarks/>
    public string ResourceRef
    {
      get
      {
        return this.resourceRefField;
      }
      set
      {
        this.resourceRefField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string id
    {
      get
      {
        return this.idField;
      }
      set
      {
        this.idField = value;
      }
    }
  }
}