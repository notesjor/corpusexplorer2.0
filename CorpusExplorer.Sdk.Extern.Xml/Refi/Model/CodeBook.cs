namespace CorpusExplorer.Sdk.Extern.Xml.Refi.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:QDA-XML:project:1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:QDA-XML:project:1.0", IsNullable = false)]
  public partial class CodeBook
  {

    private Code[] codesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Code", IsNullable = false)]
    public Code[] Codes
    {
      get
      {
        return this.codesField;
      }
      set
      {
        this.codesField = value;
      }
    }
  }
}