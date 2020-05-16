namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class idsText
  {

    private idsHeader idsHeaderField;

    private text textField;

    private decimal versionField;

    /// <remarks/>
    public idsHeader idsHeader
    {
      get { return this.idsHeaderField; }
      set { this.idsHeaderField = value; }
    }

    /// <remarks/>
    public text text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal version
    {
      get { return this.versionField; }
      set { this.versionField = value; }
    }
  }
}