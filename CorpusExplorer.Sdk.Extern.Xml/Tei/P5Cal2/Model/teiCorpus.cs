

using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model
{

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class teiCorpus
  {

    private teiHeader teiHeaderField;

    private TEI[] tEIField;

    /// <remarks/>
    public teiHeader teiHeader
    {
      get { return this.teiHeaderField; }
      set { this.teiHeaderField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TEI")]
    public TEI[] TEI
    {
      get { return this.tEIField; }
      set { this.tEIField = value; }
    }
  }
}