namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class timepoint
  {

    private decimal absolutetimeField;

    private string timepointidField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("absolute-time")]
    public decimal absolutetime
    {
      get { return this.absolutetimeField; }
      set { this.absolutetimeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("timepoint-id", DataType = "NCName")]
    public string timepointid
    {
      get { return this.timepointidField; }
      set { this.timepointidField = value; }
    }
  }
}