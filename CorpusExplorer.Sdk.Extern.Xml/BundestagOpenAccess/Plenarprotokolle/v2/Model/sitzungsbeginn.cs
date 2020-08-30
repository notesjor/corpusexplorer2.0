namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class sitzungsbeginn
  {

    private object[] itemsField;

    private string[] textField;

    private string sitzungstartuhrzeitField;

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

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("sitzung-start-uhrzeit")]
    public string sitzungstartuhrzeit
    {
      get { return this.sitzungstartuhrzeitField; }
      set { this.sitzungstartuhrzeitField = value; }
    }
  }
}