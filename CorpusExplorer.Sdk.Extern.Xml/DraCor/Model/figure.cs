namespace CorpusExplorer.Sdk.Extern.Xml.DraCor.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class figure
  {

    private graphic graphicField;

    private string abField;

    /// <remarks/>
    public graphic graphic
    {
      get { return this.graphicField; }
      set { this.graphicField = value; }
    }

    /// <remarks/>
    public string ab
    {
      get { return this.abField; }
      set { this.abField = value; }
    }
  }
}