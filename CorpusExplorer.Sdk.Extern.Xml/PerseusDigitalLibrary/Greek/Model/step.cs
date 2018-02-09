namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class step
  {

    private string tEIformField;

    private string fromField;

    private string refunitField;

    private string toField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string from
    {
      get { return this.fromField; }
      set { this.fromField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string refunit
    {
      get { return this.refunitField; }
      set { this.refunitField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string to
    {
      get { return this.toField; }
      set { this.toField = value; }
    }
  }
}