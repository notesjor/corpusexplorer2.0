namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class publisher
  {

    private object[] itemsField;

    private ItemsChoiceType[] itemsElementNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("address", typeof(address))]
    [System.Xml.Serialization.XmlElementAttribute("email", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("name", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("orgName", typeof(orgName))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
      get
      {
        return this.itemsField;
      }
      set
      {
        this.itemsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType[] ItemsElementName
    {
      get
      {
        return this.itemsElementNameField;
      }
      set
      {
        this.itemsElementNameField = value;
      }
    }
  }
}