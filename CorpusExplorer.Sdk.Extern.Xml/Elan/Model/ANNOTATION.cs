namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class ANNOTATION
  {

    private ANNOTATION_VALUE itemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ALIGNABLE_ANNOTATION", typeof(ALIGNABLE_ANNOTATION))]
    [System.Xml.Serialization.XmlElementAttribute("REF_ANNOTATION", typeof(REF_ANNOTATION))]
    public ANNOTATION_VALUE Item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
    }
  }
}