namespace CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class String
  {

    private string ccField;

    private string cONTENTField;

    private string hEIGHTField;

    private string hPOSField;

    private string idField;

    private string sTYLEField;

    private string sTYLEREFSField;

    private string sUBS_CONTENTField;

    private string sUBS_TYPEField;

    private string vPOSField;

    private decimal wcField;

    private string wIDTHField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string CC
    {
      get { return this.ccField; }
      set { this.ccField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CONTENT
    {
      get { return this.cONTENTField; }
      set { this.cONTENTField = value; }
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
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string STYLE
    {
      get { return this.sTYLEField; }
      set { this.sTYLEField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string STYLEREFS
    {
      get { return this.sTYLEREFSField; }
      set { this.sTYLEREFSField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SUBS_CONTENT
    {
      get { return this.sUBS_CONTENTField; }
      set { this.sUBS_CONTENTField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string SUBS_TYPE
    {
      get { return this.sUBS_TYPEField; }
      set { this.sUBS_TYPEField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string VPOS
    {
      get { return this.vPOSField; }
      set { this.vPOSField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal WC
    {
      get { return this.wcField; }
      set { this.wcField = value; }
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