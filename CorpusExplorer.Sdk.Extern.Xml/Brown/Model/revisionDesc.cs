namespace CorpusExplorer.Sdk.Extern.Xml.Brown.Model
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

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("change")]
    public change[] change
    {
      get { return this.changeField; }
      set { this.changeField = value; }
    }
  }
}