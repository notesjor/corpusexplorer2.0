namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class titlePage
  {

    private titlePart[] docTitleField;

    private byline bylineField;

    private string[] docImprintField;

    private object itemField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("titlePart", IsNullable = false)]
    public titlePart[] docTitle
    {
      get { return this.docTitleField; }
      set { this.docTitleField = value; }
    }

    /// <remarks/>
    public byline byline
    {
      get { return this.bylineField; }
      set { this.bylineField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("docImprint")]
    public string[] docImprint
    {
      get { return this.docImprintField; }
      set { this.docImprintField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("docEdition", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("epigraph", typeof(epigraph))]
    public object Item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}