namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.dspin.de/data/textcorpus", IsNullable = false)]
  public partial class TextCorpus
  {

    private token[] tokensField;

    private sentence[] sentencesField;

    private lemma[] lemmasField;

    private POStags pOStagsField;

    private correction[] orthographyField;

    private string langField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("token", IsNullable = false)]
    public token[] tokens
    {
      get
      {
        return this.tokensField;
      }
      set
      {
        this.tokensField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("sentence", IsNullable = false)]
    public sentence[] sentences
    {
      get
      {
        return this.sentencesField;
      }
      set
      {
        this.sentencesField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("lemma", IsNullable = false)]
    public lemma[] lemmas
    {
      get
      {
        return this.lemmasField;
      }
      set
      {
        this.lemmasField = value;
      }
    }

    /// <remarks/>
    public POStags POStags
    {
      get
      {
        return this.pOStagsField;
      }
      set
      {
        this.pOStagsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("correction", IsNullable = false)]
    public correction[] orthography
    {
      get
      {
        return this.orthographyField;
      }
      set
      {
        this.orthographyField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string lang
    {
      get
      {
        return this.langField;
      }
      set
      {
        this.langField = value;
      }
    }
  }
}