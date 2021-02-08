namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class imprint
  {

    private string publisherField;

    private pubDate[] pubDateField;

    private pubPlace pubPlaceField;

    /// <remarks/>
    public string publisher
    {
      get { return this.publisherField; }
      set { this.publisherField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("pubDate")]
    public pubDate[] pubDate
    {
      get { return this.pubDateField; }
      set { this.pubDateField = value; }
    }

    /// <remarks/>
    public pubPlace pubPlace
    {
      get { return this.pubPlaceField; }
      set { this.pubPlaceField = value; }
    }
  }
}