namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class tr
  {

    private object[] itemsField;

    private colAlign alignField;

    private bool alignFieldSpecified;

    private string charField;

    private string charoffField;

    private colValign valignField;

    private bool valignFieldSpecified;

    private string bgcolorField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("td", typeof(td))]
    [System.Xml.Serialization.XmlElementAttribute("th", typeof(th))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
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

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string bgcolor
    {
      get { return this.bgcolorField; }
      set { this.bgcolorField = value; }
    }
  }
}