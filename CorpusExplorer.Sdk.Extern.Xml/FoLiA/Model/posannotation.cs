namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute("pos-annotation", Namespace = "http://ilk.uvt.nl/folia",
    IsNullable = false)]
  public partial class posannotation
  {

    private annotator[] annotatorField;

    private string setField;

    private string aliasField;

    private string annotator1Field;

    private string annotatortypeField;

    private System.DateTime datetimeField;

    private bool datetimeFieldSpecified;

    private string groupannotationsField;

    private string formatField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("annotator")]
    public annotator[] annotator
    {
      get { return this.annotatorField; }
      set { this.annotatorField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string set
    {
      get { return this.setField; }
      set { this.setField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string alias
    {
      get { return this.aliasField; }
      set { this.aliasField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("annotator")]
    public string annotator1
    {
      get { return this.annotator1Field; }
      set { this.annotator1Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string annotatortype
    {
      get { return this.annotatortypeField; }
      set { this.annotatortypeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime datetime
    {
      get { return this.datetimeField; }
      set { this.datetimeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool datetimeSpecified
    {
      get { return this.datetimeFieldSpecified; }
      set { this.datetimeFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string groupannotations
    {
      get { return this.groupannotationsField; }
      set { this.groupannotationsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string format
    {
      get { return this.formatField; }
      set { this.formatField = value; }
    }
  }
}