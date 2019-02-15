namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class sourceDesc
  {

    private object itemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("biblStruct", typeof(biblStruct))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    public object Item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
    }
  }
}