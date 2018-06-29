namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute("body", Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class body1
  {

    private div[] divField;

    private dateline datelineField;

    private lb lbField;

    private p pField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("div")]
    public div[] div
    {
      get { return this.divField; }
      set { this.divField = value; }
    }

    /// <remarks/>
    public dateline dateline
    {
      get { return this.datelineField; }
      set { this.datelineField = value; }
    }

    /// <remarks/>
    public lb lb
    {
      get { return this.lbField; }
      set { this.lbField = value; }
    }

    /// <remarks/>
    public p p
    {
      get { return this.pField; }
      set { this.pField = value; }
    }
  }
}