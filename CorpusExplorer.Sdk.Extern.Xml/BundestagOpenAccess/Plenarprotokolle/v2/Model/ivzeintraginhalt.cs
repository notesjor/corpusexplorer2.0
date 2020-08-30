namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("ivz-eintrag-inhalt", Namespace = "", IsNullable = false)]
  public partial class ivzeintraginhalt
  {

    private redner[] rednerField;

    private string[] textField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("redner")]
    public redner[] redner
    {
      get { return this.rednerField; }
      set { this.rednerField = value; }
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