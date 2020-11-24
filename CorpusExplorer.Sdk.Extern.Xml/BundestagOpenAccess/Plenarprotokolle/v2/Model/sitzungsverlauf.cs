namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class sitzungsverlauf
  {

    private sitzungsbeginn sitzungsbeginnField;

    private rede[] redeField;

    private tagesordnungspunkt[] tagesordnungspunktField;

    private sitzungsende sitzungsendeField;

    /// <remarks/>
    public sitzungsbeginn sitzungsbeginn
    {
      get { return this.sitzungsbeginnField; }
      set { this.sitzungsbeginnField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("rede")]
    public rede[] rede
    {
      get { return this.redeField; }
      set { this.redeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tagesordnungspunkt")]
    public tagesordnungspunkt[] tagesordnungspunkt
    {
      get { return this.tagesordnungspunktField; }
      set { this.tagesordnungspunktField = value; }
    }

    /// <remarks/>
    public sitzungsende sitzungsende
    {
      get { return this.sitzungsendeField; }
      set { this.sitzungsendeField = value; }
    }
  }
}