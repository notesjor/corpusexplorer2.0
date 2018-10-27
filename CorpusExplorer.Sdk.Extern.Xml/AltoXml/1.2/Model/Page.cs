namespace CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class Page
  {

    private TopMargin topMarginField;

    private LeftMargin leftMarginField;

    private RightMargin rightMarginField;

    private BottomMargin bottomMarginField;

    private PrintSpace printSpaceField;

    private decimal aCCURACYField;

    private bool aCCURACYFieldSpecified;

    private string hEIGHTField;

    private string idField;

    private string pHYSICAL_IMG_NRField;

    private string wIDTHField;

    /// <remarks/>
    public TopMargin TopMargin
    {
      get { return this.topMarginField; }
      set { this.topMarginField = value; }
    }

    /// <remarks/>
    public LeftMargin LeftMargin
    {
      get { return this.leftMarginField; }
      set { this.leftMarginField = value; }
    }

    /// <remarks/>
    public RightMargin RightMargin
    {
      get { return this.rightMarginField; }
      set { this.rightMarginField = value; }
    }

    /// <remarks/>
    public BottomMargin BottomMargin
    {
      get { return this.bottomMarginField; }
      set { this.bottomMarginField = value; }
    }

    /// <remarks/>
    public PrintSpace PrintSpace
    {
      get { return this.printSpaceField; }
      set { this.printSpaceField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal ACCURACY
    {
      get { return this.aCCURACYField; }
      set { this.aCCURACYField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ACCURACYSpecified
    {
      get { return this.aCCURACYFieldSpecified; }
      set { this.aCCURACYFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string HEIGHT
    {
      get { return this.hEIGHTField; }
      set { this.hEIGHTField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ID
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string PHYSICAL_IMG_NR
    {
      get { return this.pHYSICAL_IMG_NRField; }
      set { this.pHYSICAL_IMG_NRField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string WIDTH
    {
      get { return this.wIDTHField; }
      set { this.wIDTHField = value; }
    }
  }
}