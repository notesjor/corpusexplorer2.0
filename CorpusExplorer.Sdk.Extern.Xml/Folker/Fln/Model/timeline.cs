namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class timeline
  {

    private timepoint[] timepointField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("timepoint")]
    public timepoint[] timepoint
    {
      get { return this.timepointField; }
      set { this.timepointField = value; }
    }
  }
}