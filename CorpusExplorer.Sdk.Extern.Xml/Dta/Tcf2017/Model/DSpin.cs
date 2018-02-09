using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{

  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.dspin.de/data")]
  [System.Xml.Serialization.XmlRootAttribute("D-Spin", Namespace = "http://www.dspin.de/data", IsNullable = false)]
  public partial class DSpin
  {

    private source metaDataField;

    private TextCorpus textCorpusField;

    private string versionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.dspin.de/data/metadata")]
    public source MetaData
    {
      get
      {
        return this.metaDataField;
      }
      set
      {
        this.metaDataField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.dspin.de/data/textcorpus")]
    public TextCorpus TextCorpus
    {
      get
      {
        return this.textCorpusField;
      }
      set
      {
        this.textCorpusField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string version
    {
      get
      {
        return this.versionField;
      }
      set
      {
        this.versionField = value;
      }
    }
  }
}
