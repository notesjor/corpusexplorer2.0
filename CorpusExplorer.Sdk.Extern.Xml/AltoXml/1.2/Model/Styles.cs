namespace CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class Styles
  {

    private TextStyle[] textStyleField;

    private ParagraphStyle[] paragraphStyleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TextStyle")]
    public TextStyle[] TextStyle
    {
      get { return this.textStyleField; }
      set { this.textStyleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ParagraphStyle")]
    public ParagraphStyle[] ParagraphStyle
    {
      get { return this.paragraphStyleField; }
      set { this.paragraphStyleField = value; }
    }
  }
}