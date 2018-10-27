namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.dspin.de/data")]
  [System.Xml.Serialization.XmlRootAttribute("D-Spin", Namespace = "http://www.dspin.de/data", IsNullable = false)]
  public partial class DSpin
  {

    private TextCorpus textCorpusField;

    private decimal versionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.dspin.de/data/textcorpus")]
    public TextCorpus TextCorpus
    {
      get { return this.textCorpusField; }
      set { this.textCorpusField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal version
    {
      get { return this.versionField; }
      set { this.versionField = value; }
    }
  }
}