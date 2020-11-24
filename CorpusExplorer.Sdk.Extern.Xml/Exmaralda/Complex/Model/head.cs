namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class head
  {

    private metainformation metainformationField;

    private speakertable speakertableField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("meta-information")]
    public metainformation metainformation
    {
      get { return this.metainformationField; }
      set { this.metainformationField = value; }
    }

    /// <remarks/>
    public speakertable speakertable
    {
      get { return this.speakertableField; }
      set { this.speakertableField = value; }
    }
  }
}