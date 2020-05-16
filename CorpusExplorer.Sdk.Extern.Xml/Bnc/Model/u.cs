namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class u
  {

    private object[] itemsField;

    private string whoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("align", typeof(align))]
    [System.Xml.Serialization.XmlElementAttribute("event", typeof(@event))]
    [System.Xml.Serialization.XmlElementAttribute("gap", typeof(gap))]
    [System.Xml.Serialization.XmlElementAttribute("pause", typeof(pause))]
    [System.Xml.Serialization.XmlElementAttribute("s", typeof(s))]
    [System.Xml.Serialization.XmlElementAttribute("shift", typeof(shift))]
    [System.Xml.Serialization.XmlElementAttribute("unclear", typeof(unclear))]
    [System.Xml.Serialization.XmlElementAttribute("vocal", typeof(vocal))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string who
    {
      get { return this.whoField; }
      set { this.whoField = value; }
    }
  }
}