namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ilk.uvt.nl/folia", IsNullable = false)]
  public partial class target
  {

    private object[] itemsField;

    private string idField;

    private string authField;

    private System.Xml.XmlAttribute[] anyAttrField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("alignment", typeof(alignment))]
    [System.Xml.Serialization.XmlElementAttribute("aref", typeof(aref))]
    [System.Xml.Serialization.XmlElementAttribute("comment", typeof(comment))]
    [System.Xml.Serialization.XmlElementAttribute("desc", typeof(desc))]
    [System.Xml.Serialization.XmlElementAttribute("domain", typeof(domain))]
    [System.Xml.Serialization.XmlElementAttribute("errordetection", typeof(errordetection))]
    [System.Xml.Serialization.XmlElementAttribute("feat", typeof(feat))]
    [System.Xml.Serialization.XmlElementAttribute("foreign-data", typeof(System.Xml.XmlNode))]
    [System.Xml.Serialization.XmlElementAttribute("lang", typeof(lang))]
    [System.Xml.Serialization.XmlElementAttribute("lemma", typeof(lemma))]
    [System.Xml.Serialization.XmlElementAttribute("metric", typeof(metric))]
    [System.Xml.Serialization.XmlElementAttribute("pos", typeof(pos))]
    [System.Xml.Serialization.XmlElementAttribute("relation", typeof(relation))]
    [System.Xml.Serialization.XmlElementAttribute("sense", typeof(sense))]
    [System.Xml.Serialization.XmlElementAttribute("subjectivity", typeof(subjectivity))]
    [System.Xml.Serialization.XmlElementAttribute("wref", typeof(wref))]
    [System.Xml.Serialization.XmlElementAttribute("xref", typeof(xref))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace", DataType = "ID")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
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