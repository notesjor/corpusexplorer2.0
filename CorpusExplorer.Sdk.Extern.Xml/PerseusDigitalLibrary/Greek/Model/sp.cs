namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class sp
  {

    private object[] itemsField;

    private p[] pField;

    private string tEIformField;

    private string nField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("l", typeof(l))]
    [System.Xml.Serialization.XmlElementAttribute("milestone", typeof(milestone))]
    [System.Xml.Serialization.XmlElementAttribute("speaker", typeof(speaker))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("p")]
    public p[] p
    {
      get { return this.pField; }
      set { this.pField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
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