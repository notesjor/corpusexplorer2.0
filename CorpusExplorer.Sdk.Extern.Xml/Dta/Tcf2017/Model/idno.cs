namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class idno
  {

    private idno[] idno1Field;

    private string[] textField;

    private string typeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idno")]
    public idno[] idno1
    {
      get
      {
        return this.idno1Field;
      }
      set
      {
        this.idno1Field = value;
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
    public string type
    {
      get
      {
        return this.typeField;
      }
      set
      {
        this.typeField = value;
      }
    }
  }
}