namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class editorialDecl
  {

    private correction correctionField;

    private string tEIformField;

    private string defaultField;

    /// <remarks/>
    public correction correction
    {
      get { return this.correctionField; }
      set { this.correctionField = value; }
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