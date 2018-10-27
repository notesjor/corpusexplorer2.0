namespace CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class TextStyle
  {

    private string fONTFAMILYField;

    private string fONTSIZEField;

    private string fONTSTYLEField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string FONTFAMILY
    {
      get { return this.fONTFAMILYField; }
      set { this.fONTFAMILYField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string FONTSIZE
    {
      get { return this.fONTSIZEField; }
      set { this.fONTSIZEField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string FONTSTYLE
    {
      get { return this.fONTSTYLEField; }
      set { this.fONTSTYLEField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ID
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}