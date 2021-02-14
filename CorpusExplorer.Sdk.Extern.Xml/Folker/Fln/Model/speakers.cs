namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class speakers
  {

    private speaker[] speakerField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("speaker")]
    public speaker[] speaker
    {
      get { return this.speakerField; }
      set { this.speakerField = value; }
    }
  }
}