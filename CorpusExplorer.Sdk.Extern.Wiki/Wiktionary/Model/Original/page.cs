namespace CorpusExplorer.Sdk.Extern.Wiki.Wiktionary.Model.Original
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
  public partial class page
  {

    private string titleField;

    private string nsField;

    private string idField;

    private redirect redirectField;

    private string restrictionsField;

    private revision revisionField;

    /// <remarks/>
    public string title
    {
      get { return this.titleField; }
      set { this.titleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string ns
    {
      get { return this.nsField; }
      set { this.nsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    public redirect redirect
    {
      get { return this.redirectField; }
      set { this.redirectField = value; }
    }

    /// <remarks/>
    public string restrictions
    {
      get { return this.restrictionsField; }
      set { this.restrictionsField = value; }
    }

    /// <remarks/>
    public revision revision
    {
      get { return this.revisionField; }
      set { this.revisionField = value; }
    }
  }
}