namespace CorpusExplorer.Sdk.Extern.Xml.GermanParl.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class sourceDesc
  {

    private string filetypeField;

    private string urlField;

    private date dateField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
    public string filetype
    {
      get { return this.filetypeField; }
      set { this.filetypeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
    public string url
    {
      get { return this.urlField; }
      set { this.urlField = value; }
    }

    /// <remarks/>
    public date date
    {
      get { return this.dateField; }
      set { this.dateField = value; }
    }
  }
}