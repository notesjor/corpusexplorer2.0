namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.dspin.de/data/textcorpus", IsNullable = false)]
  public partial class POStags
  {

    private tag[] tagField;

    private string tagsetField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tag")]
    public tag[] tag
    {
      get { return this.tagField; }
      set { this.tagField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string tagset
    {
      get { return this.tagsetField; }
      set { this.tagsetField = value; }
    }
  }
}