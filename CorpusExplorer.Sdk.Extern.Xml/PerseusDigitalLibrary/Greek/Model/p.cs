namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class p
  {

    private object[] itemsField;

    private string[] textField;

    private string tEIformField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("add", typeof(add))]
    [System.Xml.Serialization.XmlElementAttribute("bibl", typeof(bibl))]
    [System.Xml.Serialization.XmlElementAttribute("cit", typeof(cit))]
    [System.Xml.Serialization.XmlElementAttribute("del", typeof(del))]
    [System.Xml.Serialization.XmlElementAttribute("emph", typeof(emph))]
    [System.Xml.Serialization.XmlElementAttribute("figure", typeof(figure))]
    [System.Xml.Serialization.XmlElementAttribute("foreign", typeof(foreign))]
    [System.Xml.Serialization.XmlElementAttribute("gap", typeof(gap))]
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    [System.Xml.Serialization.XmlElementAttribute("lb", typeof(lb))]
    [System.Xml.Serialization.XmlElementAttribute("milestone", typeof(milestone))]
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
    [System.Xml.Serialization.XmlElementAttribute("num", typeof(num))]
    [System.Xml.Serialization.XmlElementAttribute("pb", typeof(pb))]
    [System.Xml.Serialization.XmlElementAttribute("q", typeof(q))]
    [System.Xml.Serialization.XmlElementAttribute("quote", typeof(quote))]
    [System.Xml.Serialization.XmlElementAttribute("table", typeof(table))]
    [System.Xml.Serialization.XmlElementAttribute("term", typeof(term))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }
  }
}