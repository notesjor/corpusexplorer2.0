namespace CorpusExplorer.Sdk.Extern.Xml.Perseus.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class div
  {

    private argument argumentField;

    private milestone milestoneField;

    private l[] lField;

    private string typeField;

    /// <remarks/>
    public argument argument
    {
      get { return this.argumentField; }
      set { this.argumentField = value; }
    }

    /// <remarks/>
    public milestone milestone
    {
      get { return this.milestoneField; }
      set { this.milestoneField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("l")]
    public l[] l
    {
      get { return this.lField; }
      set { this.lField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }
  }
}