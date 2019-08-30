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
  public partial class comment
  {

    private string deletedField;

    private string[] textField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string deleted
    {
      get { return this.deletedField; }
      set { this.deletedField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }
  }
}