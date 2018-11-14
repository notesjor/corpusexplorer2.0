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
  public partial class redirect
  {

    private string titleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string title
    {
      get { return this.titleField; }
      set { this.titleField = value; }
    }
  }
}