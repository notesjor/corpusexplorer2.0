namespace CorpusExplorer.Sdk.Extern.Xml.Brown.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class encodingDesc
  {

    private projectDesc projectDescField;

    private classDecl classDeclField;

    private p[] pField;

    /// <remarks/>
    public projectDesc projectDesc
    {
      get { return this.projectDescField; }
      set { this.projectDescField = value; }
    }

    /// <remarks/>
    public classDecl classDecl
    {
      get { return this.classDeclField; }
      set { this.classDeclField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("p")]
    public p[] p
    {
      get { return this.pField; }
      set { this.pField = value; }
    }
  }
}