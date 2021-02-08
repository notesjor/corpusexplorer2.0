namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class @ref
  {

    private s[] sField;

    private string[] textField;

    private string rendField;

    private string targOrderField;

    private string targTypeField;

    private string targetField;

    private string langField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("s")]
    public s[] s
    {
      get { return this.sField; }
      set { this.sField = value; }
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
    public string rend
    {
      get { return this.rendField; }
      set { this.rendField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string targOrder
    {
      get { return this.targOrderField; }
      set { this.targOrderField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string targType
    {
      get { return this.targTypeField; }
      set { this.targTypeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string target
    {
      get { return this.targetField; }
      set { this.targetField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
                                                     Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang
    {
      get { return this.langField; }
      set { this.langField = value; }
    }
  }
}