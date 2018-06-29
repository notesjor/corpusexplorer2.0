namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
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

    private rendition[] tagsDeclField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("rendition", IsNullable = false)]
    public rendition[] tagsDecl
    {
      get { return this.tagsDeclField; }
      set { this.tagsDeclField = value; }
    }
  }
}