namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.SubSub.Head
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

    private string textSigleField;

    private ttitle ttitleField;

    /// <remarks/>
    public string textSigle
    {
      get { return this.textSigleField; }
      set { this.textSigleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("t.title")]
    public ttitle ttitle
    {
      get { return this.ttitleField; }
      set { this.ttitleField = value; }
    }
  }
}