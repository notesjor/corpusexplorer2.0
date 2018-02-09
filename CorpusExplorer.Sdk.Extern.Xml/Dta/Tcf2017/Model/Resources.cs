namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1", IsNullable = false)]
  public partial class Resources
  {

    private ResourceProxy[] resourceProxyListField;

    private JournalFileProxyList journalFileProxyListField;

    private ResourceRelationList resourceRelationListField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ResourceProxy", IsNullable = false)]
    public ResourceProxy[] ResourceProxyList
    {
      get
      {
        return this.resourceProxyListField;
      }
      set
      {
        this.resourceProxyListField = value;
      }
    }

    /// <remarks/>
    public JournalFileProxyList JournalFileProxyList
    {
      get
      {
        return this.journalFileProxyListField;
      }
      set
      {
        this.journalFileProxyListField = value;
      }
    }

    /// <remarks/>
    public ResourceRelationList ResourceRelationList
    {
      get
      {
        return this.resourceRelationListField;
      }
      set
      {
        this.resourceRelationListField = value;
      }
    }
  }
}