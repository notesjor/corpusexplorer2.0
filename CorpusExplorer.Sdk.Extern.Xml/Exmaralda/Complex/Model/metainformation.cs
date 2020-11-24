namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("meta-information", Namespace = "", IsNullable = false)]
  public partial class metainformation
  {

    private string projectnameField;

    private string transcriptionnameField;

    private referencedfile referencedfileField;

    private udinformation[] udmetainformationField;

    private string commentField;

    private transcriptionconvention transcriptionconventionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("project-name", DataType = "NCName")]
    public string projectname
    {
      get { return this.projectnameField; }
      set { this.projectnameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("transcription-name")]
    public string transcriptionname
    {
      get { return this.transcriptionnameField; }
      set { this.transcriptionnameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("referenced-file")]
    public referencedfile referencedfile
    {
      get { return this.referencedfileField; }
      set { this.referencedfileField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("ud-meta-information")]
    [System.Xml.Serialization.XmlArrayItemAttribute("ud-information", IsNullable = false)]
    public udinformation[] udmetainformation
    {
      get { return this.udmetainformationField; }
      set { this.udmetainformationField = value; }
    }

    /// <remarks/>
    public string comment
    {
      get { return this.commentField; }
      set { this.commentField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("transcription-convention")]
    public transcriptionconvention transcriptionconvention
    {
      get { return this.transcriptionconventionField; }
      set { this.transcriptionconventionField = value; }
    }
  }
}