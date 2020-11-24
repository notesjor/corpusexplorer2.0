namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class LOCALE
  {

    private string cOUNTRY_CODEField;

    private string lANGUAGE_CODEField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string COUNTRY_CODE
    {
      get { return this.cOUNTRY_CODEField; }
      set { this.cOUNTRY_CODEField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string LANGUAGE_CODE
    {
      get { return this.lANGUAGE_CODEField; }
      set { this.lANGUAGE_CODEField = value; }
    }
  }
}