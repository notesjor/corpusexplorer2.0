namespace CorpusExplorer.Sdk.Extern.Xml.Catma._6._0.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class seg
  {

    private ptr ptrField;

    private string anaField;

    /// <remarks/>
    public ptr ptr
    {
      get { return this.ptrField; }
      set { this.ptrField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ana
    {
      get { return this.anaField; }
      set { this.anaField = value; }
    }
  }
}