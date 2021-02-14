namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class w
  {

    private time[] timeField;

    private string[] textField;

    private string idField;

    private string lemmaField;

    private string nField;

    private string olField;

    private string posField;

    private string transitionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("time")]
    public time[] time
    {
      get { return this.timeField; }
      set { this.timeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lemma
    {
      get { return this.lemmaField; }
      set { this.lemmaField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string n
    {
      get { return this.nField; }
      set { this.nField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ol
    {
      get { return this.olField; }
      set { this.olField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string pos
    {
      get { return this.posField; }
      set { this.posField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string transition
    {
      get { return this.transitionField; }
      set { this.transitionField = value; }
    }
  }
}