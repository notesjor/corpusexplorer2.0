namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class HEADER
  {

    private PROPERTY[] pROPERTYField;

    private string mEDIA_FILEField;

    private string tIME_UNITSField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PROPERTY")]
    public PROPERTY[] PROPERTY
    {
      get { return this.pROPERTYField; }
      set { this.pROPERTYField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MEDIA_FILE
    {
      get { return this.mEDIA_FILEField; }
      set { this.mEDIA_FILEField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TIME_UNITS
    {
      get { return this.tIME_UNITSField; }
      set { this.tIME_UNITSField = value; }
    }
  }
}