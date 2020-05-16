namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class encodingDesc
  {

    private appInfo appInfoField;

    private taxonomy[] classDeclField;

    /// <remarks/>
    public appInfo appInfo
    {
      get { return this.appInfoField; }
      set { this.appInfoField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("taxonomy", IsNullable = false)]
    public taxonomy[] classDecl
    {
      get { return this.classDeclField; }
      set { this.classDeclField = value; }
    }
  }
}