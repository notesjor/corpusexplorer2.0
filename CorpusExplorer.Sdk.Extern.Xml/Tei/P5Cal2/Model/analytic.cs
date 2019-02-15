namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class analytic
  {

    private title[] titleField;

    private object[] itemsField;

    private idno[] idnoField;

    private string dateField;

    private @ref refField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("title")]
    public title[] title
    {
      get { return this.titleField; }
      set { this.titleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("author", typeof(author))]
    [System.Xml.Serialization.XmlElementAttribute("respStmt", typeof(respStmt))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idno")]
    public idno[] idno
    {
      get { return this.idnoField; }
      set { this.idnoField = value; }
    }

    /// <remarks/>
    public string date
    {
      get { return this.dateField; }
      set { this.dateField = value; }
    }

    /// <remarks/>
    public @ref @ref
    {
      get { return this.refField; }
      set { this.refField = value; }
    }
  }
}