namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class respStmt
  {

    private string respField;

    private string nameField;

    /// <remarks/>
    public string resp
    {
      get { return this.respField; }
      set { this.respField = value; }
    }

    /// <remarks/>
    public string name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }
  }
}