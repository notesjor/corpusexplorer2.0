namespace CorpusExplorer.Sdk.Extern.Xml.DraCor.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class front
  {

    private string docAuthorField;

    private object[] itemsField;

    private object[] items1Field;

    private dateline datelineField;

    /// <remarks/>
    public string docAuthor
    {
      get { return this.docAuthorField; }
      set { this.docAuthorField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("head", typeof(head))]
    [System.Xml.Serialization.XmlElementAttribute("titlePart", typeof(titlePart))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("castList", typeof(castList))]
    [System.Xml.Serialization.XmlElementAttribute("div", typeof(div))]
    [System.Xml.Serialization.XmlElementAttribute("docImprint", typeof(docImprint))]
    [System.Xml.Serialization.XmlElementAttribute("docTitle", typeof(docTitle))]
    [System.Xml.Serialization.XmlElementAttribute("epigraph", typeof(epigraph))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    [System.Xml.Serialization.XmlElementAttribute("pb", typeof(pb))]
    [System.Xml.Serialization.XmlElementAttribute("set", typeof(set))]
    [System.Xml.Serialization.XmlElementAttribute("titlePage", typeof(titlePage))]
    public object[] Items1
    {
      get { return this.items1Field; }
      set { this.items1Field = value; }
    }

    /// <remarks/>
    public dateline dateline
    {
      get { return this.datelineField; }
      set { this.datelineField = value; }
    }
  }
}