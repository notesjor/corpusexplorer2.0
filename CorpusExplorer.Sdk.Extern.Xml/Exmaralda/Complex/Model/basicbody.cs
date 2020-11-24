namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("basic-body", Namespace = "", IsNullable = false)]
  public partial class basicbody
  {

    private tli[] commontimelineField;

    private tier[] tierField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("common-timeline")]
    [System.Xml.Serialization.XmlArrayItemAttribute("tli", IsNullable = false)]
    public tli[] commontimeline
    {
      get { return this.commontimelineField; }
      set { this.commontimelineField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tier")]
    public tier[] tier
    {
      get { return this.tierField; }
      set { this.tierField = value; }
    }
  }
}