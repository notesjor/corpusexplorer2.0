namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class recordingStmt
  {

    private recording[] recordingField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("recording")]
    public recording[] recording
    {
      get { return this.recordingField; }
      set { this.recordingField = value; }
    }
  }
}