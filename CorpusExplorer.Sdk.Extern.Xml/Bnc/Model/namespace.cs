namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class @namespace
  {

    private tagUsage[] tagUsageField;

    private string nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tagUsage")]
    public tagUsage[] tagUsage
    {
      get { return this.tagUsageField; }
      set { this.tagUsageField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }
  }
}