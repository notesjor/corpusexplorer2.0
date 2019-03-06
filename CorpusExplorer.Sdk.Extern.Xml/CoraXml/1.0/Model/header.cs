using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._1._0.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public partial class header
  {

    private string textField;

    private string abbr_dddField;

    private string abbr_mwbField;

    private string topicField;

    private string texttypeField;

    private string genreField;

    private string referenceField;

    private string referencesecondaryField;

    private string libraryField;

    private string libraryshelfmarkField;

    private string onlineField;

    private string mediumField;

    private string extentField;

    private string extractField;

    private string languageField;

    private string languagetypeField;

    private string languageregionField;

    private string languageareaField;

    private string placeField;

    private string timeField;

    private string notesmanuscriptField;

    private string dateField;

    private string textplaceField;

    private string textauthorField;

    private string textlanguageField;

    private string textsourceField;

    private string editionField;

    private string corpusField;

    private string notestranscriptionField;

    private string notesannotationField;

    private string digitization_byField;

    private string collation_byField;

    private string pre_editing_byField;

    private string annotation_byField;

    private string proofreading_byField;

    /// <remarks/>
    public string text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }

    /// <remarks/>
    public string abbr_ddd
    {
      get { return this.abbr_dddField; }
      set { this.abbr_dddField = value; }
    }

    /// <remarks/>
    public string abbr_mwb
    {
      get { return this.abbr_mwbField; }
      set { this.abbr_mwbField = value; }
    }

    /// <remarks/>
    public string topic
    {
      get { return this.topicField; }
      set { this.topicField = value; }
    }

    /// <remarks/>
    [XmlElement("text-type")]
    public string texttype
    {
      get { return this.texttypeField; }
      set { this.texttypeField = value; }
    }

    /// <remarks/>
    public string genre
    {
      get { return this.genreField; }
      set { this.genreField = value; }
    }

    /// <remarks/>
    public string reference
    {
      get { return this.referenceField; }
      set { this.referenceField = value; }
    }

    /// <remarks/>
    [XmlElement("reference-secondary")]
    public string referencesecondary
    {
      get { return this.referencesecondaryField; }
      set { this.referencesecondaryField = value; }
    }

    /// <remarks/>
    public string library
    {
      get { return this.libraryField; }
      set { this.libraryField = value; }
    }

    /// <remarks/>
    [XmlElement("library-shelfmark")]
    public string libraryshelfmark
    {
      get { return this.libraryshelfmarkField; }
      set { this.libraryshelfmarkField = value; }
    }

    /// <remarks/>
    public string online
    {
      get { return this.onlineField; }
      set { this.onlineField = value; }
    }

    /// <remarks/>
    public string medium
    {
      get { return this.mediumField; }
      set { this.mediumField = value; }
    }

    /// <remarks/>
    public string extent
    {
      get { return this.extentField; }
      set { this.extentField = value; }
    }

    /// <remarks/>
    public string extract
    {
      get { return this.extractField; }
      set { this.extractField = value; }
    }

    /// <remarks/>
    public string language
    {
      get { return this.languageField; }
      set { this.languageField = value; }
    }

    /// <remarks/>
    [XmlElement("language-type")]
    public string languagetype
    {
      get { return this.languagetypeField; }
      set { this.languagetypeField = value; }
    }

    /// <remarks/>
    [XmlElement("language-region")]
    public string languageregion
    {
      get { return this.languageregionField; }
      set { this.languageregionField = value; }
    }

    /// <remarks/>
    [XmlElement("language-area")]
    public string languagearea
    {
      get { return this.languageareaField; }
      set { this.languageareaField = value; }
    }

    /// <remarks/>
    public string place
    {
      get { return this.placeField; }
      set { this.placeField = value; }
    }

    /// <remarks/>
    public string time
    {
      get { return this.timeField; }
      set { this.timeField = value; }
    }

    /// <remarks/>
    [XmlElement("notes-manuscript")]
    public string notesmanuscript
    {
      get { return this.notesmanuscriptField; }
      set { this.notesmanuscriptField = value; }
    }

    /// <remarks/>
    public string date
    {
      get { return this.dateField; }
      set { this.dateField = value; }
    }

    /// <remarks/>
    [XmlElement("text-place")]
    public string textplace
    {
      get { return this.textplaceField; }
      set { this.textplaceField = value; }
    }

    /// <remarks/>
    [XmlElement("text-author")]
    public string textauthor
    {
      get { return this.textauthorField; }
      set { this.textauthorField = value; }
    }

    /// <remarks/>
    [XmlElement("text-language")]
    public string textlanguage
    {
      get { return this.textlanguageField; }
      set { this.textlanguageField = value; }
    }

    /// <remarks/>
    [XmlElement("text-source")]
    public string textsource
    {
      get { return this.textsourceField; }
      set { this.textsourceField = value; }
    }

    /// <remarks/>
    public string edition
    {
      get { return this.editionField; }
      set { this.editionField = value; }
    }

    /// <remarks/>
    public string corpus
    {
      get { return this.corpusField; }
      set { this.corpusField = value; }
    }

    /// <remarks/>
    [XmlElement("notes-transcription")]
    public string notestranscription
    {
      get { return this.notestranscriptionField; }
      set { this.notestranscriptionField = value; }
    }

    /// <remarks/>
    [XmlElement("notes-annotation")]
    public string notesannotation
    {
      get { return this.notesannotationField; }
      set { this.notesannotationField = value; }
    }

    /// <remarks/>
    public string digitization_by
    {
      get { return this.digitization_byField; }
      set { this.digitization_byField = value; }
    }

    /// <remarks/>
    public string collation_by
    {
      get { return this.collation_byField; }
      set { this.collation_byField = value; }
    }

    /// <remarks/>
    public string pre_editing_by
    {
      get { return this.pre_editing_byField; }
      set { this.pre_editing_byField = value; }
    }

    /// <remarks/>
    public string annotation_by
    {
      get { return this.annotation_byField; }
      set { this.annotation_byField = value; }
    }

    /// <remarks/>
    public string proofreading_by
    {
      get { return this.proofreading_byField; }
      set { this.proofreading_byField = value; }
    }
  }
}