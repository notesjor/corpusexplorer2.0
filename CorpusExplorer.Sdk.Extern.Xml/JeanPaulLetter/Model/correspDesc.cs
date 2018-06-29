namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class correspDesc
  {

    private correspAction[] correspActionField;

    private @ref[] correspContextField;

    private bool defaultField;

    private bool defaultFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("correspAction")]
    public correspAction[] correspAction
    {
      get { return this.correspActionField; }
      set { this.correspActionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ref", IsNullable = false)]
    public @ref[] correspContext
    {
      get { return this.correspContextField; }
      set { this.correspContextField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool @default
    {
      get { return this.defaultField; }
      set { this.defaultField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool defaultSpecified
    {
      get { return this.defaultFieldSpecified; }
      set { this.defaultFieldSpecified = value; }
    }
  }
}