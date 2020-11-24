namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class TIME_SLOT
  {

    private string tIME_SLOT_IDField;

    private string tIME_VALUEField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TIME_SLOT_ID
    {
      get { return this.tIME_SLOT_IDField; }
      set { this.tIME_SLOT_IDField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string TIME_VALUE
    {
      get { return this.tIME_VALUEField; }
      set { this.tIME_VALUEField = value; }
    }
  }
}