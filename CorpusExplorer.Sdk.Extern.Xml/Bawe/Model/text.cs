namespace CorpusExplorer.Sdk.Extern.Xml.Bawe.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class text
  {

    private front frontField;

    private body bodyField;

    private back backField;

    private string tEIformField;

    /// <remarks/>
    public front front
    {
      get { return this.frontField; }
      set { this.frontField = value; }
    }

    /// <remarks/>
    public body body
    {
      get { return this.bodyField; }
      set { this.bodyField = value; }
    }

    /// <remarks/>
    public back back
    {
      get { return this.backField; }
      set { this.backField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }
  }
}