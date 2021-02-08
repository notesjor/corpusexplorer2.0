namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.SubSub.Head
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class tagsDecl
  {

    private tagUsage[] tagUsageField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tagUsage")]
    public tagUsage[] tagUsage
    {
      get { return this.tagUsageField; }
      set { this.tagUsageField = value; }
    }
  }
}