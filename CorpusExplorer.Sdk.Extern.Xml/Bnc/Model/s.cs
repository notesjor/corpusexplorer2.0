namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class s
  {

    private object[] itemsField;

    private string nField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("align", typeof(align))]
    [System.Xml.Serialization.XmlElementAttribute("c", typeof(c))]
    [System.Xml.Serialization.XmlElementAttribute("corr", typeof(corr))]
    [System.Xml.Serialization.XmlElementAttribute("event", typeof(@event))]
    [System.Xml.Serialization.XmlElementAttribute("gap", typeof(gap))]
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    [System.Xml.Serialization.XmlElementAttribute("mw", typeof(mw))]
    [System.Xml.Serialization.XmlElementAttribute("pause", typeof(pause))]
    [System.Xml.Serialization.XmlElementAttribute("pb", typeof(pb))]
    [System.Xml.Serialization.XmlElementAttribute("shift", typeof(shift))]
    [System.Xml.Serialization.XmlElementAttribute("trunc", typeof(trunc))]
    [System.Xml.Serialization.XmlElementAttribute("unclear", typeof(unclear))]
    [System.Xml.Serialization.XmlElementAttribute("vocal", typeof(vocal))]
    [System.Xml.Serialization.XmlElementAttribute("w", typeof(w))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string n
    {
      get { return this.nField; }
      set { this.nField = value; }
    }
  }
}