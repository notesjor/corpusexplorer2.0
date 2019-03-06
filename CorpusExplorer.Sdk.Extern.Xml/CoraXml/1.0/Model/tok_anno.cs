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
  public partial class tok_anno
  {

    private norm normField;

    private token_type token_typeField;

    private lemma lemmaField;

    private lemma_gen lemma_genField;

    private lemma_idmwb lemma_idmwbField;

    private pos posField;

    private pos_gen pos_genField;

    private infl inflField;

    private inflClass inflClassField;

    private inflClass_gen inflClass_genField;

    private punc puncField;

    private link linkField;

    private string asciiField;

    private string idField;

    private string transField;

    private string utfField;

    /// <remarks/>
    public norm norm
    {
      get { return this.normField; }
      set { this.normField = value; }
    }

    /// <remarks/>
    public token_type token_type
    {
      get { return this.token_typeField; }
      set { this.token_typeField = value; }
    }

    /// <remarks/>
    public lemma lemma
    {
      get { return this.lemmaField; }
      set { this.lemmaField = value; }
    }

    /// <remarks/>
    public lemma_gen lemma_gen
    {
      get { return this.lemma_genField; }
      set { this.lemma_genField = value; }
    }

    /// <remarks/>
    public lemma_idmwb lemma_idmwb
    {
      get { return this.lemma_idmwbField; }
      set { this.lemma_idmwbField = value; }
    }

    /// <remarks/>
    public pos pos
    {
      get { return this.posField; }
      set { this.posField = value; }
    }

    /// <remarks/>
    public pos_gen pos_gen
    {
      get { return this.pos_genField; }
      set { this.pos_genField = value; }
    }

    /// <remarks/>
    public infl infl
    {
      get { return this.inflField; }
      set { this.inflField = value; }
    }

    /// <remarks/>
    public inflClass inflClass
    {
      get { return this.inflClassField; }
      set { this.inflClassField = value; }
    }

    /// <remarks/>
    public inflClass_gen inflClass_gen
    {
      get { return this.inflClass_genField; }
      set { this.inflClass_genField = value; }
    }

    /// <remarks/>
    public punc punc
    {
      get { return this.puncField; }
      set { this.puncField = value; }
    }

    /// <remarks/>
    public link link
    {
      get { return this.linkField; }
      set { this.linkField = value; }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string ascii
    {
      get { return this.asciiField; }
      set { this.asciiField = value; }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string trans
    {
      get { return this.transField; }
      set { this.transField = value; }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string utf
    {
      get { return this.utfField; }
      set { this.utfField = value; }
    }
  }
}