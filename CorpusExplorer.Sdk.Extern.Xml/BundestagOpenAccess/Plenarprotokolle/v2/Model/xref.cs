namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class xref
  {

    private a[] aField;

    private string[] textField;

    private xrefReftype reftypeField;

    private string ridField;

    private string pnrField;

    private string divField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("a")]
    public a[] a
    {
      get { return this.aField; }
      set { this.aField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("ref-type")]
    public xrefReftype reftype
    {
      get { return this.reftypeField; }
      set { this.reftypeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string rid
    {
      get { return this.ridField; }
      set { this.ridField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string pnr
    {
      get { return this.pnrField; }
      set { this.pnrField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string div
    {
      get { return this.divField; }
      set { this.divField = value; }
    }
  }
}