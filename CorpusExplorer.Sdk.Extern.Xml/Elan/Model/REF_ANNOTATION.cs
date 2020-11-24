namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class REF_ANNOTATION : ANNOTATION_VALUE
  {

    private string aNNOTATION_IDField;

    private string aNNOTATION_REFField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ANNOTATION_ID
    {
      get { return this.aNNOTATION_IDField; }
      set { this.aNNOTATION_IDField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ANNOTATION_REF
    {
      get { return this.aNNOTATION_REFField; }
      set { this.aNNOTATION_REFField = value; }
    }
  }
}