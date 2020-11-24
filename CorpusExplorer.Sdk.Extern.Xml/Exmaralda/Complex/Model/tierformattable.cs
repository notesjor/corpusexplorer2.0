namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("tierformat-table", Namespace = "", IsNullable = false)]
  public partial class tierformattable
  {

    private timelineitemformat timelineitemformatField;

    private tierformat[] tierformatField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("timeline-item-format")]
    public timelineitemformat timelineitemformat
    {
      get { return this.timelineitemformatField; }
      set { this.timelineitemformatField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tier-format")]
    public tierformat[] tierformat
    {
      get { return this.tierformatField; }
      set { this.tierformatField = value; }
    }
  }
}