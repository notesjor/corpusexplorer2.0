namespace CorpusExplorer.Sdk.Extern.Xml.GermanParl.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class encodingDesc
  {

    private string projectDescField;

    private samplingDecl samplingDeclField;

    private editorialDecl editorialDeclField;

    /// <remarks/>
    public string projectDesc
    {
      get { return this.projectDescField; }
      set { this.projectDescField = value; }
    }

    /// <remarks/>
    public samplingDecl samplingDecl
    {
      get { return this.samplingDeclField; }
      set { this.samplingDeclField = value; }
    }

    /// <remarks/>
    public editorialDecl editorialDecl
    {
      get { return this.editorialDeclField; }
      set { this.editorialDeclField = value; }
    }
  }
}