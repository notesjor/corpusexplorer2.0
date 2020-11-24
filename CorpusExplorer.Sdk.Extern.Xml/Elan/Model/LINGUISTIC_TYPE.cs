namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class LINGUISTIC_TYPE
  {

    private string cONSTRAINTSField;

    private bool gRAPHIC_REFERENCESField;

    private string lINGUISTIC_TYPE_IDField;

    private bool tIME_ALIGNABLEField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string CONSTRAINTS
    {
      get { return this.cONSTRAINTSField; }
      set { this.cONSTRAINTSField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool GRAPHIC_REFERENCES
    {
      get { return this.gRAPHIC_REFERENCESField; }
      set { this.gRAPHIC_REFERENCESField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string LINGUISTIC_TYPE_ID
    {
      get { return this.lINGUISTIC_TYPE_IDField; }
      set { this.lINGUISTIC_TYPE_IDField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool TIME_ALIGNABLE
    {
      get { return this.tIME_ALIGNABLEField; }
      set { this.tIME_ALIGNABLEField = value; }
    }
  }
}