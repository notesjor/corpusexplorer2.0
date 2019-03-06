namespace CorpusExplorer.Sdk.Extern.Xml.Brown.Model
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

    private object[] itemsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("bibl", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }
  }
}