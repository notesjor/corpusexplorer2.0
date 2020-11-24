namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class th
  {

    private object[] inlineelementeField;

    private string[] textField;

    private string abbrField;

    private string axisField;

    private string headersField;

    private Scope scopeField;

    private bool scopeFieldSpecified;

    private string rowspanField;

    private string colspanField;

    private colAlign alignField;

    private bool alignFieldSpecified;

    private string charField;

    private string charoffField;

    private colValign valignField;

    private bool valignFieldSpecified;

    private thNowrap nowrapField;

    private bool nowrapFieldSpecified;

    private string bgcolorField;

    private string widthField;

    private string heightField;

    public th()
    {
      this.rowspanField = "1";
      this.colspanField = "1";
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("inline-elemente")]
    public object[] inlineelemente
    {
      get { return this.inlineelementeField; }
      set { this.inlineelementeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string abbr
    {
      get { return this.abbrField; }
      set { this.abbrField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string axis
    {
      get { return this.axisField; }
      set { this.axisField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "IDREFS")]
    public string headers
    {
      get { return this.headersField; }
      set { this.headersField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public Scope scope
    {
      get { return this.scopeField; }
      set { this.scopeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool scopeSpecified
    {
      get { return this.scopeFieldSpecified; }
      set { this.scopeFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute("1")]
    public string rowspan
    {
      get { return this.rowspanField; }
      set { this.rowspanField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute("1")]
    public string colspan
    {
      get { return this.colspanField; }
      set { this.colspanField = value; }
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
    public thNowrap nowrap
    {
      get { return this.nowrapField; }
      set { this.nowrapField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool nowrapSpecified
    {
      get { return this.nowrapFieldSpecified; }
      set { this.nowrapFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string bgcolor
    {
      get { return this.bgcolorField; }
      set { this.bgcolorField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string width
    {
      get { return this.widthField; }
      set { this.widthField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string height
    {
      get { return this.heightField; }
      set { this.heightField = value; }
    }
  }
}