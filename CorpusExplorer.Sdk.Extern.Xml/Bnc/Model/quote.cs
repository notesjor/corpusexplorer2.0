namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class quote
  {

    private object[] itemsField;

    private object[] items1Field;

    private string rendField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("l", typeof(l))]
    [System.Xml.Serialization.XmlElementAttribute("lg", typeof(lg))]
    [System.Xml.Serialization.XmlElementAttribute("list", typeof(list))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("bibl", typeof(bibl))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    [System.Xml.Serialization.XmlElementAttribute("sp", typeof(sp))]
    public object[] Items1
    {
      get { return this.items1Field; }
      set { this.items1Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string rend
    {
      get { return this.rendField; }
      set { this.rendField = value; }
    }
  }
}