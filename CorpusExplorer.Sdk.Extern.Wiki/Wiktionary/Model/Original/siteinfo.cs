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
  public partial class siteinfo
  {

    private string sitenameField;

    private string dbnameField;

    private string baseField;

    private string generatorField;

    private string caseField;

    private @namespace[] namespacesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
    public string sitename
    {
      get { return this.sitenameField; }
      set { this.sitenameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
    public string dbname
    {
      get { return this.dbnameField; }
      set { this.dbnameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
    public string @base
    {
      get { return this.baseField; }
      set { this.baseField = value; }
    }

    /// <remarks/>
    public string generator
    {
      get { return this.generatorField; }
      set { this.generatorField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
    public string @case
    {
      get { return this.caseField; }
      set { this.caseField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("namespace", IsNullable = false)]
    public @namespace[] namespaces
    {
      get { return this.namespacesField; }
      set { this.namespacesField = value; }
    }
  }
}