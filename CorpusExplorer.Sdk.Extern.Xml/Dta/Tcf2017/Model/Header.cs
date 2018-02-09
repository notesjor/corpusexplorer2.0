namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1", IsNullable = false)]
  public partial class Header
  {

    private string mdCreatorField;

    private string mdCreationDateField;

    private string mdSelfLinkField;

    private string mdProfileField;

    private string mdCollectionDisplayNameField;

    /// <remarks/>
    public string MdCreator
    {
      get
      {
        return this.mdCreatorField;
      }
      set
      {
        this.mdCreatorField = value;
      }
    }

    /// <remarks/>
    public string MdCreationDate
    {
      get
      {
        return this.mdCreationDateField;
      }
      set
      {
        this.mdCreationDateField = value;
      }
    }

    /// <remarks/>
    public string MdSelfLink
    {
      get
      {
        return this.mdSelfLinkField;
      }
      set
      {
        this.mdSelfLinkField = value;
      }
    }

    /// <remarks/>
    public string MdProfile
    {
      get
      {
        return this.mdProfileField;
      }
      set
      {
        this.mdProfileField = value;
      }
    }

    /// <remarks/>
    public string MdCollectionDisplayName
    {
      get
      {
        return this.mdCollectionDisplayNameField;
      }
      set
      {
        this.mdCollectionDisplayNameField = value;
      }
    }
  }
}