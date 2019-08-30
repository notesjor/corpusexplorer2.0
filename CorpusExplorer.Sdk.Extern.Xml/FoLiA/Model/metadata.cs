namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ilk.uvt.nl/folia", IsNullable = false)]
  public partial class metadata
  {

    private object[] annotationsField;

    private processor[] provenanceField;

    private meta[] metaField;

    private System.Xml.XmlNode[] foreigndataField;

    private submetadata[] submetadataField;

    private string typeField;

    private string srcField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("alignment-annotation", typeof(alignmentannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("alternative-annotation", typeof(alternativeannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("chunking-annotation", typeof(chunkingannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("comment-annotation", typeof(commentannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("complexalignment-annotation", typeof(complexalignmentannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("coreference-annotation", typeof(coreferenceannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("correction-annotation", typeof(correctionannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("definition-annotation", typeof(definitionannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("dependency-annotation", typeof(dependencyannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("description-annotation", typeof(descriptionannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("division-annotation", typeof(divisionannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("domain-annotation", typeof(domainannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("entity-annotation", typeof(entityannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("entry-annotation", typeof(entryannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("errordetection-annotation", typeof(errordetectionannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("event-annotation", typeof(eventannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("example-annotation", typeof(exampleannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("figure-annotation", typeof(figureannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("gap-annotation", typeof(gapannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("head-annotation", typeof(headannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("hiddentoken-annotation", typeof(hiddentokenannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("hyphenation-annotation", typeof(hyphenationannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("lang-annotation", typeof(langannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("lemma-annotation", typeof(lemmaannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("linebreak-annotation", typeof(linebreakannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("list-annotation", typeof(listannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("metric-annotation", typeof(metricannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("morphological-annotation", typeof(morphologicalannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("note-annotation", typeof(noteannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("observation-annotation", typeof(observationannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("paragraph-annotation", typeof(paragraphannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("part-annotation", typeof(partannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("phon-annotation", typeof(phonannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("phonological-annotation", typeof(phonologicalannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("pos-annotation", typeof(posannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("predicate-annotation", typeof(predicateannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("quote-annotation", typeof(quoteannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("rawcontent-annotation", typeof(rawcontentannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("reference-annotation", typeof(referenceannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("relation-annotation", typeof(relationannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("semrole-annotation", typeof(semroleannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("sense-annotation", typeof(senseannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("sentence-annotation", typeof(sentenceannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("sentiment-annotation", typeof(sentimentannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("spanrelation-annotation", typeof(spanrelationannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("statement-annotation", typeof(statementannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("string-annotation", typeof(stringannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("style-annotation", typeof(styleannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("subjectivity-annotation", typeof(subjectivityannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("syntax-annotation", typeof(syntaxannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("table-annotation", typeof(tableannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("term-annotation", typeof(termannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("text-annotation", typeof(textannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("timesegment-annotation", typeof(timesegmentannotation),
      IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("token-annotation", typeof(tokenannotation), IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("utterance-annotation", typeof(utteranceannotation), IsNullable =
      false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("whitespace-annotation", typeof(whitespaceannotation), IsNullable =
      false)]
    public object[] annotations
    {
      get { return this.annotationsField; }
      set { this.annotationsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("processor", IsNullable = false)]
    public processor[] provenance
    {
      get { return this.provenanceField; }
      set { this.provenanceField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("meta")]
    public meta[] meta
    {
      get { return this.metaField; }
      set { this.metaField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("foreign-data")]
    public System.Xml.XmlNode[] foreigndata
    {
      get { return this.foreigndataField; }
      set { this.foreigndataField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("submetadata")]
    public submetadata[] submetadata
    {
      get { return this.submetadataField; }
      set { this.submetadataField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string src
    {
      get { return this.srcField; }
      set { this.srcField = value; }
    }
  }
}