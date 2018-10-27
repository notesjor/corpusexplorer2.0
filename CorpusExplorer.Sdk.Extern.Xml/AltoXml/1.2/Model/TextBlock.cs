namespace CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class TextBlock
  {

    private Shape shapeField;

    private TextLine[] textLineField;

    private string hEIGHTField;

    private string hPOSField;

    private string idField;

    private decimal rOTATIONField;

    private bool rOTATIONFieldSpecified;

    private string sTYLEREFSField;

    private string vPOSField;

    private string wIDTHField;

    /// <remarks/>
    public Shape Shape
    {
      get { return this.shapeField; }
      set { this.shapeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TextLine")]
    public TextLine[] TextLine
    {
      get { return this.textLineField; }
      set { this.textLineField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string HEIGHT
    {
      get { return this.hEIGHTField; }
      set { this.hEIGHTField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string HPOS
    {
      get { return this.hPOSField; }
      set { this.hPOSField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ID
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal ROTATION
    {
      get { return this.rOTATIONField; }
      set { this.rOTATIONField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ROTATIONSpecified
    {
      get { return this.rOTATIONFieldSpecified; }
      set { this.rOTATIONFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string STYLEREFS
    {
      get { return this.sTYLEREFSField; }
      set { this.sTYLEREFSField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string VPOS
    {
      get { return this.vPOSField; }
      set { this.vPOSField = value; }
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