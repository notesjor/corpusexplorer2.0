namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class CONSTRAINT
  {

    private string dESCRIPTIONField;

    private string sTEREOTYPEField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string DESCRIPTION
    {
      get { return this.dESCRIPTIONField; }
      set { this.dESCRIPTIONField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string STEREOTYPE
    {
      get { return this.sTEREOTYPEField; }
      set { this.sTEREOTYPEField = value; }
    }
  }
}