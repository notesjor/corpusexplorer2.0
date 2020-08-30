namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class anlagen
  {

    private anlagentitel anlagentitelField;

    private anlage[] anlageField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("anlagen-titel")]
    public anlagentitel anlagentitel
    {
      get { return this.anlagentitelField; }
      set { this.anlagentitelField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("anlage")]
    public anlage[] anlage
    {
      get { return this.anlageField; }
      set { this.anlageField = value; }
    }
  }
}