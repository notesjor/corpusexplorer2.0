namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class TIME_ORDER
  {

    private TIME_SLOT[] tIME_SLOTField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TIME_SLOT")]
    public TIME_SLOT[] TIME_SLOT
    {
      get { return this.tIME_SLOTField; }
      set { this.tIME_SLOTField = value; }
    }
  }
}