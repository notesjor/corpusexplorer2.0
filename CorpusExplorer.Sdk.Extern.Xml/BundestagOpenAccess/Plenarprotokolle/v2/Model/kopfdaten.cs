namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class kopfdaten
  {

    private plenarprotokollnummer plenarprotokollnummerField;

    private string herausgeberField;

    private string berichtartField;

    private sitzungstitel sitzungstitelField;

    private veranstaltungsdaten veranstaltungsdatenField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("plenarprotokoll-nummer")]
    public plenarprotokollnummer plenarprotokollnummer
    {
      get { return this.plenarprotokollnummerField; }
      set { this.plenarprotokollnummerField = value; }
    }

    /// <remarks/>
    public string herausgeber
    {
      get { return this.herausgeberField; }
      set { this.herausgeberField = value; }
    }

    /// <remarks/>
    public string berichtart
    {
      get { return this.berichtartField; }
      set { this.berichtartField = value; }
    }

    /// <remarks/>
    public sitzungstitel sitzungstitel
    {
      get { return this.sitzungstitelField; }
      set { this.sitzungstitelField = value; }
    }

    /// <remarks/>
    public veranstaltungsdaten veranstaltungsdaten
    {
      get { return this.veranstaltungsdatenField; }
      set { this.veranstaltungsdatenField = value; }
    }
  }
}