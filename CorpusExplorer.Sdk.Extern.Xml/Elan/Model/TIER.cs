namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class TIER
  {

    private ANNOTATION[] aNNOTATIONField;

    private string dEFAULT_LOCALEField;

    private string lINGUISTIC_TYPE_REFField;

    private string pARENT_REFField;

    private string pARTICIPANTField;

    private string tIER_IDField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ANNOTATION")]
    public ANNOTATION[] ANNOTATION
    {
      get { return this.aNNOTATIONField; }
      set { this.aNNOTATIONField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string DEFAULT_LOCALE
    {
      get { return this.dEFAULT_LOCALEField; }
      set { this.dEFAULT_LOCALEField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string LINGUISTIC_TYPE_REF
    {
      get { return this.lINGUISTIC_TYPE_REFField; }
      set { this.lINGUISTIC_TYPE_REFField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string PARENT_REF
    {
      get { return this.pARENT_REFField; }
      set { this.pARENT_REFField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string PARTICIPANT
    {
      get { return this.pARTICIPANTField; }
      set { this.pARTICIPANTField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TIER_ID
    {
      get { return this.tIER_IDField; }
      set { this.tIER_IDField = value; }
    }
  }
}