namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class name
  {

    // private object[] itemsField;

    private ItemsChoiceType2[] itemsElementNameField;

    private string[] textField;
    private string bdland;
    private string fraktion;
    private string nachname;
    private string namenszusatz;
    private string ortszusatz;
    private rolle rolle;
    private string titel;
    private string vorname;

    /*
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("bdland", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("fraktion", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("nachname", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("namenszusatz", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("ortszusatz", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("rolle", typeof(rolle))]
    [System.Xml.Serialization.XmlElementAttribute("titel", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("vorname", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }
    */

    [System.Xml.Serialization.XmlElementAttribute("bdland")]
    public string Bdland
    {
      get { return this.bdland; }
      set { this.bdland = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("fraktion")]
    public string Fraktion
    {
      get { return this.fraktion; }
      set { this.fraktion = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("nachname")]
    public string Nachname
    {
      get { return this.nachname; }
      set { this.nachname = value; }
    }
    [System.Xml.Serialization.XmlElementAttribute("namenszusatz")]
    public string Namenszusatz
    {
      get { return this.namenszusatz; }
      set { this.namenszusatz = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("ortszusatz")]
    public string Ortszusatz
    {
      get { return this.ortszusatz; }
      set { this.ortszusatz = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("rolle")]
    public rolle Rolle
    {
      get { return this.rolle; }
      set { this.rolle = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("titel")]
    public string Titel
    {
      get { return this.titel; }
      set { this.titel = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("vorname")]
    public string Vorname
    {
      get { return this.vorname; }
      set { this.vorname = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType2[] ItemsElementName
    {
      get { return this.itemsElementNameField; }
      set { this.itemsElementNameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }
  }
}