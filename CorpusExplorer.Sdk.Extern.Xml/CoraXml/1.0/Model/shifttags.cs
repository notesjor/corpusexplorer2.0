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
  public partial class shifttags
  {

    private object[] itemsField;

    /// <remarks/>
    [XmlElement("paren", typeof(paren))]
    [XmlElement("quote", typeof(quote))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }
  }
}