namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class table
  {

    private caption captionField;

    private object[] itemsField;

    private thead theadField;

    private tfoot tfootField;

    private object[] items1Field;

    private string summaryField;

    private string widthField;

    private string borderField;

    private TFrame frameField;

    private bool frameFieldSpecified;

    private TRules rulesField;

    private bool rulesFieldSpecified;

    private string cellspacingField;

    private string cellpaddingField;

    private TAlign alignField;

    private bool alignFieldSpecified;

    private string bgcolorField;

    /// <remarks/>
    public caption caption
    {
      get { return this.captionField; }
      set { this.captionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("col", typeof(col))]
    [System.Xml.Serialization.XmlElementAttribute("colgroup", typeof(colgroup))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    public thead thead
    {
      get { return this.theadField; }
      set { this.theadField = value; }
    }

    /// <remarks/>
    public tfoot tfoot
    {
      get { return this.tfootField; }
      set { this.tfootField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tbody", typeof(tbody))]
    [System.Xml.Serialization.XmlElementAttribute("tr", typeof(tr))]
    public object[] Items1
    {
      get { return this.items1Field; }
      set { this.items1Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string summary
    {
      get { return this.summaryField; }
      set { this.summaryField = value; }
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
    public string border
    {
      get { return this.borderField; }
      set { this.borderField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public TFrame frame
    {
      get { return this.frameField; }
      set { this.frameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool frameSpecified
    {
      get { return this.frameFieldSpecified; }
      set { this.frameFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public TRules rules
    {
      get { return this.rulesField; }
      set { this.rulesField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool rulesSpecified
    {
      get { return this.rulesFieldSpecified; }
      set { this.rulesFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string cellspacing
    {
      get { return this.cellspacingField; }
      set { this.cellspacingField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string cellpadding
    {
      get { return this.cellpaddingField; }
      set { this.cellpaddingField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public TAlign align
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
    public string bgcolor
    {
      get { return this.bgcolorField; }
      set { this.bgcolorField = value; }
    }
  }
}