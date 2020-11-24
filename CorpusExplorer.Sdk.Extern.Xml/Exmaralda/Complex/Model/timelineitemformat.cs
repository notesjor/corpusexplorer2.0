namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("timeline-item-format", Namespace = "", IsNullable = false)]
  public partial class timelineitemformat
  {

    private string absolutetimeformatField;

    private string milisecondsdigitsField;

    private string showeverynthabsoluteField;

    private string showeverynthnumberingField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("absolute-time-format", DataType = "NCName")]
    public string absolutetimeformat
    {
      get { return this.absolutetimeformatField; }
      set { this.absolutetimeformatField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("miliseconds-digits", DataType = "integer")]
    public string milisecondsdigits
    {
      get { return this.milisecondsdigitsField; }
      set { this.milisecondsdigitsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("show-every-nth-absolute", DataType = "integer")]
    public string showeverynthabsolute
    {
      get { return this.showeverynthabsoluteField; }
      set { this.showeverynthabsoluteField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("show-every-nth-numbering", DataType = "integer")]
    public string showeverynthnumbering
    {
      get { return this.showeverynthnumberingField; }
      set { this.showeverynthnumberingField = value; }
    }
  }
}