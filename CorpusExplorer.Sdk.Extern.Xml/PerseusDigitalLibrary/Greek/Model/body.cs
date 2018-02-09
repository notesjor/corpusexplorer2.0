namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class body
  {

    private object[] itemsField;

    private sp[] spField;

    private string tEIformField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("castList", typeof(castList))]
    [System.Xml.Serialization.XmlElementAttribute("div1", typeof(div1))]
    [System.Xml.Serialization.XmlElementAttribute("head", typeof(head))]
    [System.Xml.Serialization.XmlElementAttribute("lb", typeof(lb))]
    [System.Xml.Serialization.XmlElementAttribute("milestone", typeof(milestone))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    [System.Xml.Serialization.XmlElementAttribute("pb", typeof(pb))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("sp")]
    public sp[] sp
    {
      get { return this.spField; }
      set { this.spField = value; }
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