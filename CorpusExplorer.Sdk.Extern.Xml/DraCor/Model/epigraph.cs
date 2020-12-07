namespace CorpusExplorer.Sdk.Extern.Xml.DraCor.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class epigraph
  {

    private p pField;

    private object[] citField;

    private pb pbField;

    private l[] lField;

    private bibl biblField;

    private string langField;

    /// <remarks/>
    public p p
    {
      get { return this.pField; }
      set { this.pField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("bibl", typeof(bibl), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("quote", typeof(quote), IsNullable = false)]
    public object[] cit
    {
      get { return this.citField; }
      set { this.citField = value; }
    }

    /// <remarks/>
    public pb pb
    {
      get { return this.pbField; }
      set { this.pbField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("l")]
    public l[] l
    {
      get { return this.lField; }
      set { this.lField = value; }
    }

    /// <remarks/>
    public bibl bibl
    {
      get { return this.biblField; }
      set { this.biblField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
                                                     Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang
    {
      get { return this.langField; }
      set { this.langField = value; }
    }
  }
}