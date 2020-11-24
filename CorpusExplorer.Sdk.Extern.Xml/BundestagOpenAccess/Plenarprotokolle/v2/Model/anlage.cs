namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class anlage
  {

    private anlagentitel anlagentitelField;

    private anlagentext[] anlagentextField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("anlagen-titel")]
    public anlagentitel anlagentitel
    {
      get { return this.anlagentitelField; }
      set { this.anlagentitelField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("anlagen-text")]
    public anlagentext[] anlagentext
    {
      get { return this.anlagentextField; }
      set { this.anlagentextField = value; }
    }
  }
}