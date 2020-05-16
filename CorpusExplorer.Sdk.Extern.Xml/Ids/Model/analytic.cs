namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class analytic
  {

    private htitle htitleField;

    private string hauthorField;

    private imprint imprintField;

    private biblScope[] biblScopeField;

    private biblNote biblNoteField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("h.title")]
    public htitle htitle
    {
      get { return this.htitleField; }
      set { this.htitleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("h.author")]
    public string hauthor
    {
      get { return this.hauthorField; }
      set { this.hauthorField = value; }
    }

    /// <remarks/>
    public imprint imprint
    {
      get { return this.imprintField; }
      set { this.imprintField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("biblScope")]
    public biblScope[] biblScope
    {
      get { return this.biblScopeField; }
      set { this.biblScopeField = value; }
    }

    /// <remarks/>
    public biblNote biblNote
    {
      get { return this.biblNoteField; }
      set { this.biblNoteField = value; }
    }
  }
}