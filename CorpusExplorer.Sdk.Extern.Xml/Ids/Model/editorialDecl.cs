namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class editorialDecl
  {

    private transduction[] transductionField;

    private pagination paginationField;

    private string defaultField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("transduction")]
    public transduction[] transduction
    {
      get { return this.transductionField; }
      set { this.transductionField = value; }
    }

    /// <remarks/>
    public pagination pagination
    {
      get { return this.paginationField; }
      set { this.paginationField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string Default
    {
      get { return this.defaultField; }
      set { this.defaultField = value; }
    }
  }
}