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
  public partial class namespaces
  {

    private @namespace[] namespaceField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("namespace")]
    public @namespace[] @namespace
    {
      get { return this.namespaceField; }
      set { this.namespaceField = value; }
    }
  }
}