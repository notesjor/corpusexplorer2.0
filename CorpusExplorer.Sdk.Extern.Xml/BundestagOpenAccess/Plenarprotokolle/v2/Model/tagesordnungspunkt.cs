namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class tagesordnungspunkt
  {

    private object[] itemsField;

    private string topidField;
    private toptitel toptitel;
    private rede[] reden;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("a", typeof(a))]
    [System.Xml.Serialization.XmlElementAttribute("kommentar", typeof(kommentar))]
    [System.Xml.Serialization.XmlElementAttribute("name", typeof(name))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    [System.Xml.Serialization.XmlElementAttribute("zitat", typeof(zitat))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("top-titel", typeof(toptitel))]
    public toptitel TopTitel
    {
      get { return this.toptitel; }
      set { this.toptitel = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("rede", typeof(rede))]
    public rede[] Reden
    {
      get { return this.reden; }
      set { this.reden = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("top-id")]
    public string topid
    {
      get { return this.topidField; }
      set { this.topidField = value; }
    }
  }
}