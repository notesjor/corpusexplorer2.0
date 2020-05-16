namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class lg
  {

    private head[] headField;

    private gap gapField;

    private object[] itemsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("head")]
    public head[] head
    {
      get { return this.headField; }
      set { this.headField = value; }
    }

    /// <remarks/>
    public gap gap
    {
      get { return this.gapField; }
      set { this.gapField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("l", typeof(l))]
    [System.Xml.Serialization.XmlElementAttribute("pb", typeof(pb))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }
  }
}