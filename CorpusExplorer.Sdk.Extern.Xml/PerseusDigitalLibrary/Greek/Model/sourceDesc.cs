namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class sourceDesc
  {

    private object itemField;

    private biblStruct biblStructField;

    private p pField;

    private string tEIformField;

    private string defaultField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("bibl", typeof(bibl))]
    [System.Xml.Serialization.XmlElementAttribute("listBibl", typeof(listBibl))]
    public object Item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
    }

    /// <remarks/>
    public biblStruct biblStruct
    {
      get { return this.biblStructField; }
      set { this.biblStructField = value; }
    }

    /// <remarks/>
    public p p
    {
      get { return this.pField; }
      set { this.pField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string @default
    {
      get { return this.defaultField; }
      set { this.defaultField = value; }
    }
  }
}