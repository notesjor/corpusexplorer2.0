namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.SubSub.Head
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

    private samplingDecl samplingDeclField;

    private editorialDecl editorialDeclField;

    private tagUsage[] tagsDeclField;

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

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("tagUsage", IsNullable = false)]
    public tagUsage[] tagsDecl
    {
      get { return this.tagsDeclField; }
      set { this.tagsDeclField = value; }
    }
  }
}