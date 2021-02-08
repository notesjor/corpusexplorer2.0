namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class titleStmt
  {

    private object[] itemsField;

    private ItemsChoiceType[] itemsElementNameField;

    private string titleC;
    private string titleD;
    private string dokumentSigle;
    private string korpusSigle;
    private string textSigle;

    [System.Xml.Serialization.XmlElementAttribute("c.title", typeof(string))]
    public string TitleC
    {
      get { return titleC; }
      set { titleC = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("d.title", typeof(string))]
    public string TitleD
    {
      get { return titleD; }
      set { titleD = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("dokumentSigle", typeof(string))]
    public string DokumentSigle
    {
      get { return dokumentSigle; }
      set { dokumentSigle = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("korpusSigle", typeof(string))]
    public string KorpusSigle
    {
      get { return korpusSigle; }
      set { korpusSigle = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("textSigle", typeof(string))]
    public string TextSigle
    {
      get { return textSigle; }
      set { textSigle = value; }
    }

    private ttitle titleT;
    private xtitle titleX;

    [System.Xml.Serialization.XmlElementAttribute("t.title", typeof(ttitle))]
    public ttitle TitleT
    {
      get { return titleT; }
      set { titleT = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("x.title", typeof(xtitle))]
    public xtitle TitleX
    {
      get { return titleX; }
      set { titleX = value; }
    }
  }
}
