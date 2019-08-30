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
  public partial class @namespace
  {

    private string caseField;

    private string keyField;

    private string[] textField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string @case
    {
      get { return this.caseField; }
      set { this.caseField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string key
    {
      get { return this.keyField; }
      set { this.keyField = value; }
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