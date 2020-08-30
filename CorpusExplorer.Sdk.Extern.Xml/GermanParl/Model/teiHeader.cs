namespace CorpusExplorer.Sdk.Extern.Xml.GermanParl.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class teiHeader
  {

    private fileDesc fileDescField;

    private encodingDesc encodingDescField;

    private profileDesc profileDescField;

    private revisionDesc revisionDescField;

    /// <remarks/>
    public fileDesc fileDesc
    {
      get { return this.fileDescField; }
      set { this.fileDescField = value; }
    }

    /// <remarks/>
    public encodingDesc encodingDesc
    {
      get { return this.encodingDescField; }
      set { this.encodingDescField = value; }
    }

    /// <remarks/>
    public profileDesc profileDesc
    {
      get { return this.profileDescField; }
      set { this.profileDescField = value; }
    }

    /// <remarks/>
    public revisionDesc revisionDesc
    {
      get { return this.revisionDescField; }
      set { this.revisionDescField = value; }
    }
  }
}