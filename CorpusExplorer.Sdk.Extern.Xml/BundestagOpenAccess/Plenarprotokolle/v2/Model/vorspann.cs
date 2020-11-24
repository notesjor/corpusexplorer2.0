namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class vorspann
  {

    private kopfdaten kopfdatenField;

    private inhaltsverzeichnis inhaltsverzeichnisField;

    /// <remarks/>
    public kopfdaten kopfdaten
    {
      get { return this.kopfdatenField; }
      set { this.kopfdatenField = value; }
    }

    /// <remarks/>
    public inhaltsverzeichnis inhaltsverzeichnis
    {
      get { return this.inhaltsverzeichnisField; }
      set { this.inhaltsverzeichnisField = value; }
    }
  }
}