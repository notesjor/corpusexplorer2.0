namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class ALIGNABLE_ANNOTATION : ANNOTATION_VALUE
  {

    private string aNNOTATION_IDField;

    private string tIME_SLOT_REF1Field;

    private string tIME_SLOT_REF2Field;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ANNOTATION_ID
    {
      get { return this.aNNOTATION_IDField; }
      set { this.aNNOTATION_IDField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TIME_SLOT_REF1
    {
      get { return this.tIME_SLOT_REF1Field; }
      set { this.tIME_SLOT_REF1Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TIME_SLOT_REF2
    {
      get { return this.tIME_SLOT_REF2Field; }
      set { this.tIME_SLOT_REF2Field = value; }
    }
  }
}