namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Sub
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class titleStmt
  {

    private string dokumentSigleField;

    private string dtitleField;

    /// <remarks/>
    public string dokumentSigle
    {
      get { return this.dokumentSigleField; }
      set { this.dokumentSigleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("d.title")]
    public string dtitle
    {
      get { return this.dtitleField; }
      set { this.dtitleField = value; }
    }
  }
}