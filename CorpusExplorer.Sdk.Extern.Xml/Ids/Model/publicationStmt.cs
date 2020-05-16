namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
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

    private string pubAddressField;

    private string telephoneField;

    private availability availabilityField;

    private pubDate pubDateField;

    /// <remarks/>
    public string distributor
    {
      get { return this.distributorField; }
      set { this.distributorField = value; }
    }

    /// <remarks/>
    public string pubAddress
    {
      get { return this.pubAddressField; }
      set { this.pubAddressField = value; }
    }

    /// <remarks/>
    public string telephone
    {
      get { return this.telephoneField; }
      set { this.telephoneField = value; }
    }

    /// <remarks/>
    public availability availability
    {
      get { return this.availabilityField; }
      set { this.availabilityField = value; }
    }

    /// <remarks/>
    public pubDate pubDate
    {
      get { return this.pubDateField; }
      set { this.pubDateField = value; }
    }
  }
}