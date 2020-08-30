namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class rednerliste
  {

    private redner[] rednerField;

    private string sitzungdatumField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("redner")]
    public redner[] redner
    {
      get { return this.rednerField; }
      set { this.rednerField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("sitzung-datum")]
    public string sitzungdatum
    {
      get { return this.sitzungdatumField; }
      set { this.sitzungdatumField = value; }
    }
  }
}