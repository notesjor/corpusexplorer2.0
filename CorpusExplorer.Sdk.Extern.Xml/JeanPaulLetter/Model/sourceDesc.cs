namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class sourceDesc
  {

    private bibl biblField;

    private msDesc msDescField;

    private listPerson listPersonField;

    private listPlace listPlaceField;

    private listBibl[] listBiblField;

    private bool defaultField;

    private bool defaultFieldSpecified;

    /// <remarks/>
    public bibl bibl
    {
      get { return this.biblField; }
      set { this.biblField = value; }
    }

    /// <remarks/>
    public msDesc msDesc
    {
      get { return this.msDescField; }
      set { this.msDescField = value; }
    }

    /// <remarks/>
    public listPerson listPerson
    {
      get { return this.listPersonField; }
      set { this.listPersonField = value; }
    }

    /// <remarks/>
    public listPlace listPlace
    {
      get { return this.listPlaceField; }
      set { this.listPlaceField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("listBibl")]
    public listBibl[] listBibl
    {
      get { return this.listBiblField; }
      set { this.listBiblField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool @default
    {
      get { return this.defaultField; }
      set { this.defaultField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool defaultSpecified
    {
      get { return this.defaultFieldSpecified; }
      set { this.defaultFieldSpecified = value; }
    }
  }
}