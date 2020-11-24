namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("anlagen-text", Namespace = "", IsNullable = false)]
  public partial class anlagentext
  {

    private object[] itemsField;

    private string[] textField;

    private string anlagentypField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("inline-elemente", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("kommentar", typeof(kommentar))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    [System.Xml.Serialization.XmlElementAttribute("rede", typeof(rede))]
    [System.Xml.Serialization.XmlElementAttribute("table", typeof(table))]
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
    [System.Xml.Serialization.XmlAttributeAttribute("anlagen-typ")]
    public string anlagentyp
    {
      get { return this.anlagentypField; }
      set { this.anlagentypField = value; }
    }
  }
}