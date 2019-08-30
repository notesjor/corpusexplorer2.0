namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ilk.uvt.nl/folia", IsNullable = false)]
  public partial class annotations
  {

    private object[] itemsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("alignment-annotation", typeof(alignmentannotation))]
    [System.Xml.Serialization.XmlElementAttribute("alternative-annotation", typeof(alternativeannotation))]
    [System.Xml.Serialization.XmlElementAttribute("chunking-annotation", typeof(chunkingannotation))]
    [System.Xml.Serialization.XmlElementAttribute("comment-annotation", typeof(commentannotation))]
    [System.Xml.Serialization.XmlElementAttribute("complexalignment-annotation", typeof(complexalignmentannotation))]
    [System.Xml.Serialization.XmlElementAttribute("coreference-annotation", typeof(coreferenceannotation))]
    [System.Xml.Serialization.XmlElementAttribute("correction-annotation", typeof(correctionannotation))]
    [System.Xml.Serialization.XmlElementAttribute("definition-annotation", typeof(definitionannotation))]
    [System.Xml.Serialization.XmlElementAttribute("dependency-annotation", typeof(dependencyannotation))]
    [System.Xml.Serialization.XmlElementAttribute("description-annotation", typeof(descriptionannotation))]
    [System.Xml.Serialization.XmlElementAttribute("division-annotation", typeof(divisionannotation))]
    [System.Xml.Serialization.XmlElementAttribute("domain-annotation", typeof(domainannotation))]
    [System.Xml.Serialization.XmlElementAttribute("entity-annotation", typeof(entityannotation))]
    [System.Xml.Serialization.XmlElementAttribute("entry-annotation", typeof(entryannotation))]
    [System.Xml.Serialization.XmlElementAttribute("errordetection-annotation", typeof(errordetectionannotation))]
    [System.Xml.Serialization.XmlElementAttribute("event-annotation", typeof(eventannotation))]
    [System.Xml.Serialization.XmlElementAttribute("example-annotation", typeof(exampleannotation))]
    [System.Xml.Serialization.XmlElementAttribute("figure-annotation", typeof(figureannotation))]
    [System.Xml.Serialization.XmlElementAttribute("gap-annotation", typeof(gapannotation))]
    [System.Xml.Serialization.XmlElementAttribute("head-annotation", typeof(headannotation))]
    [System.Xml.Serialization.XmlElementAttribute("hiddentoken-annotation", typeof(hiddentokenannotation))]
    [System.Xml.Serialization.XmlElementAttribute("hyphenation-annotation", typeof(hyphenationannotation))]
    [System.Xml.Serialization.XmlElementAttribute("lang-annotation", typeof(langannotation))]
    [System.Xml.Serialization.XmlElementAttribute("lemma-annotation", typeof(lemmaannotation))]
    [System.Xml.Serialization.XmlElementAttribute("linebreak-annotation", typeof(linebreakannotation))]
    [System.Xml.Serialization.XmlElementAttribute("list-annotation", typeof(listannotation))]
    [System.Xml.Serialization.XmlElementAttribute("metric-annotation", typeof(metricannotation))]
    [System.Xml.Serialization.XmlElementAttribute("morphological-annotation", typeof(morphologicalannotation))]
    [System.Xml.Serialization.XmlElementAttribute("note-annotation", typeof(noteannotation))]
    [System.Xml.Serialization.XmlElementAttribute("observation-annotation", typeof(observationannotation))]
    [System.Xml.Serialization.XmlElementAttribute("paragraph-annotation", typeof(paragraphannotation))]
    [System.Xml.Serialization.XmlElementAttribute("part-annotation", typeof(partannotation))]
    [System.Xml.Serialization.XmlElementAttribute("phon-annotation", typeof(phonannotation))]
    [System.Xml.Serialization.XmlElementAttribute("phonological-annotation", typeof(phonologicalannotation))]
    [System.Xml.Serialization.XmlElementAttribute("pos-annotation", typeof(posannotation))]
    [System.Xml.Serialization.XmlElementAttribute("predicate-annotation", typeof(predicateannotation))]
    [System.Xml.Serialization.XmlElementAttribute("quote-annotation", typeof(quoteannotation))]
    [System.Xml.Serialization.XmlElementAttribute("rawcontent-annotation", typeof(rawcontentannotation))]
    [System.Xml.Serialization.XmlElementAttribute("reference-annotation", typeof(referenceannotation))]
    [System.Xml.Serialization.XmlElementAttribute("relation-annotation", typeof(relationannotation))]
    [System.Xml.Serialization.XmlElementAttribute("semrole-annotation", typeof(semroleannotation))]
    [System.Xml.Serialization.XmlElementAttribute("sense-annotation", typeof(senseannotation))]
    [System.Xml.Serialization.XmlElementAttribute("sentence-annotation", typeof(sentenceannotation))]
    [System.Xml.Serialization.XmlElementAttribute("sentiment-annotation", typeof(sentimentannotation))]
    [System.Xml.Serialization.XmlElementAttribute("spanrelation-annotation", typeof(spanrelationannotation))]
    [System.Xml.Serialization.XmlElementAttribute("statement-annotation", typeof(statementannotation))]
    [System.Xml.Serialization.XmlElementAttribute("string-annotation", typeof(stringannotation))]
    [System.Xml.Serialization.XmlElementAttribute("style-annotation", typeof(styleannotation))]
    [System.Xml.Serialization.XmlElementAttribute("subjectivity-annotation", typeof(subjectivityannotation))]
    [System.Xml.Serialization.XmlElementAttribute("syntax-annotation", typeof(syntaxannotation))]
    [System.Xml.Serialization.XmlElementAttribute("table-annotation", typeof(tableannotation))]
    [System.Xml.Serialization.XmlElementAttribute("term-annotation", typeof(termannotation))]
    [System.Xml.Serialization.XmlElementAttribute("text-annotation", typeof(textannotation))]
    [System.Xml.Serialization.XmlElementAttribute("timesegment-annotation", typeof(timesegmentannotation))]
    [System.Xml.Serialization.XmlElementAttribute("token-annotation", typeof(tokenannotation))]
    [System.Xml.Serialization.XmlElementAttribute("utterance-annotation", typeof(utteranceannotation))]
    [System.Xml.Serialization.XmlElementAttribute("whitespace-annotation", typeof(whitespaceannotation))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }
  }
}