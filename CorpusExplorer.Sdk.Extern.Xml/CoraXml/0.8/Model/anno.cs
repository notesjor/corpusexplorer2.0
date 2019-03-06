namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class anno
  {

    private object[] itemsField;

    private object[] items1Field;

    private posMWU posMWUField;

    private object[] items2Field;

    private string asciiField;

    private string checkedField;

    private string idField;

    private string transField;

    private string utfField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("comment", typeof(comment))]
    [System.Xml.Serialization.XmlElementAttribute("lemma", typeof(lemma))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("lemma_simple", typeof(lemma_simple))]
    [System.Xml.Serialization.XmlElementAttribute("lemma_var", typeof(lemma_var))]
    [System.Xml.Serialization.XmlElementAttribute("lemma_wsd", typeof(lemma_wsd))]
    [System.Xml.Serialization.XmlElementAttribute("morph", typeof(morph))]
    [System.Xml.Serialization.XmlElementAttribute("pos", typeof(pos))]
    [System.Xml.Serialization.XmlElementAttribute("pos_gen", typeof(pos_gen))]
    public object[] Items1
    {
      get { return this.items1Field; }
      set { this.items1Field = value; }
    }

    /// <remarks/>
    public posMWU posMWU
    {
      get { return this.posMWUField; }
      set { this.posMWUField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("bound_head", typeof(bound_head))]
    [System.Xml.Serialization.XmlElementAttribute("bound_sent", typeof(bound_sent))]
    public object[] Items2
    {
      get { return this.items2Field; }
      set { this.items2Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ascii
    {
      get { return this.asciiField; }
      set { this.asciiField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string @checked
    {
      get { return this.checkedField; }
      set { this.checkedField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string trans
    {
      get { return this.transField; }
      set { this.transField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string utf
    {
      get { return this.utfField; }
      set { this.utfField = value; }
    }
  }
}