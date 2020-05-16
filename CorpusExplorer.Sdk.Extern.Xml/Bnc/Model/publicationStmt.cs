namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class publicationStmt
  {

    private string distributorField;

    private string availabilityField;

    private idno[] idnoField;

    /// <remarks/>
    public string distributor
    {
      get { return this.distributorField; }
      set { this.distributorField = value; }
    }

    /// <remarks/>
    public string availability
    {
      get { return this.availabilityField; }
      set { this.availabilityField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idno")]
    public idno[] idno
    {
      get { return this.idnoField; }
      set { this.idnoField = value; }
    }
  }
}