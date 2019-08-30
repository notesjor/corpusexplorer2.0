namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ilk.uvt.nl/folia", IsNullable = false)]
  public partial class original
  {

    private object[] itemsField;

    private string authField;

    private System.Xml.XmlAttribute[] anyAttrField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("br", typeof(br))]
    [System.Xml.Serialization.XmlElementAttribute("caption", typeof(caption))]
    [System.Xml.Serialization.XmlElementAttribute("cell", typeof(cell))]
    [System.Xml.Serialization.XmlElementAttribute("chunk", typeof(chunk))]
    [System.Xml.Serialization.XmlElementAttribute("comment", typeof(comment))]
    [System.Xml.Serialization.XmlElementAttribute("coreferencechain", typeof(coreferencechain))]
    [System.Xml.Serialization.XmlElementAttribute("coreferencelink", typeof(coreferencelink))]
    [System.Xml.Serialization.XmlElementAttribute("correction", typeof(correction))]
    [System.Xml.Serialization.XmlElementAttribute("def", typeof(def))]
    [System.Xml.Serialization.XmlElementAttribute("dep", typeof(dep))]
    [System.Xml.Serialization.XmlElementAttribute("dependency", typeof(dependency))]
    [System.Xml.Serialization.XmlElementAttribute("desc", typeof(desc))]
    [System.Xml.Serialization.XmlElementAttribute("div", typeof(div))]
    [System.Xml.Serialization.XmlElementAttribute("domain", typeof(domain))]
    [System.Xml.Serialization.XmlElementAttribute("entity", typeof(entity))]
    [System.Xml.Serialization.XmlElementAttribute("entry", typeof(entry))]
    [System.Xml.Serialization.XmlElementAttribute("errordetection", typeof(errordetection))]
    [System.Xml.Serialization.XmlElementAttribute("event", typeof(@event))]
    [System.Xml.Serialization.XmlElementAttribute("ex", typeof(ex))]
    [System.Xml.Serialization.XmlElementAttribute("figure", typeof(figure))]
    [System.Xml.Serialization.XmlElementAttribute("foreign-data", typeof(System.Xml.XmlNode))]
    [System.Xml.Serialization.XmlElementAttribute("hd", typeof(hd))]
    [System.Xml.Serialization.XmlElementAttribute("head", typeof(head))]
    [System.Xml.Serialization.XmlElementAttribute("hiddenw", typeof(hiddenw))]
    [System.Xml.Serialization.XmlElementAttribute("item", typeof(item))]
    [System.Xml.Serialization.XmlElementAttribute("label", typeof(label))]
    [System.Xml.Serialization.XmlElementAttribute("lang", typeof(lang))]
    [System.Xml.Serialization.XmlElementAttribute("lemma", typeof(lemma))]
    [System.Xml.Serialization.XmlElementAttribute("list", typeof(list))]
    [System.Xml.Serialization.XmlElementAttribute("listitem", typeof(listitem))]
    [System.Xml.Serialization.XmlElementAttribute("metric", typeof(metric))]
    [System.Xml.Serialization.XmlElementAttribute("morpheme", typeof(morpheme))]
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
    [System.Xml.Serialization.XmlElementAttribute("observation", typeof(observation))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    [System.Xml.Serialization.XmlElementAttribute("part", typeof(part))]
    [System.Xml.Serialization.XmlElementAttribute("ph", typeof(ph))]
    [System.Xml.Serialization.XmlElementAttribute("phoneme", typeof(phoneme))]
    [System.Xml.Serialization.XmlElementAttribute("pos", typeof(pos))]
    [System.Xml.Serialization.XmlElementAttribute("predicate", typeof(predicate))]
    [System.Xml.Serialization.XmlElementAttribute("quote", typeof(quote))]
    [System.Xml.Serialization.XmlElementAttribute("ref", typeof(@ref))]
    [System.Xml.Serialization.XmlElementAttribute("rel", typeof(rel))]
    [System.Xml.Serialization.XmlElementAttribute("row", typeof(row))]
    [System.Xml.Serialization.XmlElementAttribute("s", typeof(s))]
    [System.Xml.Serialization.XmlElementAttribute("semrole", typeof(semrole))]
    [System.Xml.Serialization.XmlElementAttribute("sense", typeof(sense))]
    [System.Xml.Serialization.XmlElementAttribute("sentiment", typeof(sentiment))]
    [System.Xml.Serialization.XmlElementAttribute("source", typeof(source))]
    [System.Xml.Serialization.XmlElementAttribute("speech", typeof(speech))]
    [System.Xml.Serialization.XmlElementAttribute("statement", typeof(statement))]
    [System.Xml.Serialization.XmlElementAttribute("str", typeof(str))]
    [System.Xml.Serialization.XmlElementAttribute("su", typeof(su))]
    [System.Xml.Serialization.XmlElementAttribute("subjectivity", typeof(subjectivity))]
    [System.Xml.Serialization.XmlElementAttribute("t", typeof(t))]
    [System.Xml.Serialization.XmlElementAttribute("table", typeof(table))]
    [System.Xml.Serialization.XmlElementAttribute("tablehead", typeof(tablehead))]
    [System.Xml.Serialization.XmlElementAttribute("target", typeof(target))]
    [System.Xml.Serialization.XmlElementAttribute("term", typeof(term))]
    [System.Xml.Serialization.XmlElementAttribute("text", typeof(text))]
    [System.Xml.Serialization.XmlElementAttribute("timesegment", typeof(timesegment))]
    [System.Xml.Serialization.XmlElementAttribute("utt", typeof(utt))]
    [System.Xml.Serialization.XmlElementAttribute("w", typeof(w))]
    [System.Xml.Serialization.XmlElementAttribute("whitespace", typeof(whitespace))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string auth
    {
      get { return this.authField; }
      set { this.authField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyAttributeAttribute()]
    public System.Xml.XmlAttribute[] AnyAttr
    {
      get { return this.anyAttrField; }
      set { this.anyAttrField = value; }
    }
  }
}