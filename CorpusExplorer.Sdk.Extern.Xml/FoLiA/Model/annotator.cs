namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ilk.uvt.nl/folia", IsNullable = false)]
  public partial class annotator
  {

    private string processorField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "IDREF")]
    public string processor
    {
      get { return this.processorField; }
      set { this.processorField = value; }
    }
  }
}