namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("ud-meta-information", Namespace = "", IsNullable = false)]
  public partial class udmetainformation
  {

    private udinformation[] udinformationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ud-information")]
    public udinformation[] udinformation
    {
      get { return this.udinformationField; }
      set { this.udinformationField = value; }
    }
  }
}