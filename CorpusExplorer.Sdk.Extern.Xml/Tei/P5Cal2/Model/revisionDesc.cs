namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class revisionDesc
  {

    private change[] changeField;

    private decimal nField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("change")]
    public change[] change
    {
      get { return this.changeField; }
      set { this.changeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal n
    {
      get { return this.nField; }
      set { this.nField = value; }
    }
  }
}