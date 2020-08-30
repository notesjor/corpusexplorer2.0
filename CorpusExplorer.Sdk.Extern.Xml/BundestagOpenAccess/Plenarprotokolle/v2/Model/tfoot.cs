namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class tfoot
  {

    private tr[] trField;

    private colAlign alignField;

    private bool alignFieldSpecified;

    private string charField;

    private string charoffField;

    private colValign valignField;

    private bool valignFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tr")]
    public tr[] tr
    {
      get { return this.trField; }
      set { this.trField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public colAlign align
    {
      get { return this.alignField; }
      set { this.alignField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool alignSpecified
    {
      get { return this.alignFieldSpecified; }
      set { this.alignFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string @char
    {
      get { return this.charField; }
      set { this.charField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string charoff
    {
      get { return this.charoffField; }
      set { this.charoffField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public colValign valign
    {
      get { return this.valignField; }
      set { this.valignField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool valignSpecified
    {
      get { return this.valignFieldSpecified; }
      set { this.valignFieldSpecified = value; }
    }
  }
}