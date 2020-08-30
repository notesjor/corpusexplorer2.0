namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class veranstaltungsdaten
  {

    private object[] itemsField;

    private string[] textField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("datum", typeof(datum))]
    [System.Xml.Serialization.XmlElementAttribute("ort", typeof(string))]
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
  }
}