namespace CorpusExplorer.Sdk.Extern.Wiki.WikipediaMetaTalk
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
    Namespace = "http://www.mediawiki.org/xml/export-0.10/")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.mediawiki.org/xml/export-0.10/",
    IsNullable = false)]
  public partial class revision
  {

    private string idField;

    private string parentidField;

    private System.DateTime timestampField;

    private contributor contributorField;

    private minor minorField;

    private comment commentField;

    private string modelField;

    private string formatField;

    private text textField;

    private string sha1Field;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string parentid
    {
      get { return this.parentidField; }
      set { this.parentidField = value; }
    }

    /// <remarks/>
    public System.DateTime timestamp
    {
      get { return this.timestampField; }
      set { this.timestampField = value; }
    }

    /// <remarks/>
    public contributor contributor
    {
      get { return this.contributorField; }
      set { this.contributorField = value; }
    }

    /// <remarks/>
    public minor minor
    {
      get { return this.minorField; }
      set { this.minorField = value; }
    }

    /// <remarks/>
    public comment comment
    {
      get { return this.commentField; }
      set { this.commentField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
    public string model
    {
      get { return this.modelField; }
      set { this.modelField = value; }
    }

    /// <remarks/>
    public string format
    {
      get { return this.formatField; }
      set { this.formatField = value; }
    }

    /// <remarks/>
    public text text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NMTOKEN")]
    public string sha1
    {
      get { return this.sha1Field; }
      set { this.sha1Field = value; }
    }
  }
}