namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("languages-used", Namespace = "", IsNullable = false)]
  public partial class languagesused
  {

    private language[] languageField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("language")]
    public language[] language
    {
      get { return this.languageField; }
      set { this.languageField = value; }
    }
  }
}