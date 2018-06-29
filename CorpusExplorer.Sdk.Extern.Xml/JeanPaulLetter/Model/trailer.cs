namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class trailer
  {

    private object itemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("address", typeof(address))]
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    public object Item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
    }
  }
}