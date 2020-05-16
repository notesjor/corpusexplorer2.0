namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class p
  {

    private object[] itemsField;

    private string rendField;

    private string typeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("bibl", typeof(bibl))]
    [System.Xml.Serialization.XmlElementAttribute("gap", typeof(gap))]
    [System.Xml.Serialization.XmlElementAttribute("lg", typeof(lg))]
    [System.Xml.Serialization.XmlElementAttribute("list", typeof(list))]
    [System.Xml.Serialization.XmlElementAttribute("pb", typeof(pb))]
    [System.Xml.Serialization.XmlElementAttribute("quote", typeof(quote))]
    [System.Xml.Serialization.XmlElementAttribute("s", typeof(s))]
    [System.Xml.Serialization.XmlElementAttribute("stage", typeof(stage))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string rend
    {
      get { return this.rendField; }
      set { this.rendField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }
  }
}