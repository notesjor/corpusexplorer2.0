namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class sourceDesc
  {

    private object itemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("bibl", typeof(bibl))]
    [System.Xml.Serialization.XmlElementAttribute("recordingStmt", typeof(recordingStmt))]
    public object Item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
    }
  }
}