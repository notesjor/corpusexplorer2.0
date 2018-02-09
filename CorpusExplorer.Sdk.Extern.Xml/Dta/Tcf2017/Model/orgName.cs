namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class orgName
  {

    private object[] itemsField;

    private string[] textField;

    private string roleField;

    private string langField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idno", typeof(idno))]
    [System.Xml.Serialization.XmlElementAttribute("orgName", typeof(orgName))]
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
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get
      {
        return this.textField;
      }
      set
      {
        this.textField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string role
    {
      get
      {
        return this.roleField;
      }
      set
      {
        this.roleField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang
    {
      get
      {
        return this.langField;
      }
      set
      {
        this.langField = value;
      }
    }
  }
}