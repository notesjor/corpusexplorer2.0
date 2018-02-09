namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class encodingDesc
  {

    private editorialDecl editorialDeclField;

    private refsDecl[] refsDeclField;

    private string tEIformField;

    /// <remarks/>
    public editorialDecl editorialDecl
    {
      get { return this.editorialDeclField; }
      set { this.editorialDeclField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("refsDecl")]
    public refsDecl[] refsDecl
    {
      get { return this.refsDeclField; }
      set { this.refsDeclField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }
  }
}