#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Scraper.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer.Model
{
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class corpus
  {

    private s[] bodyField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("s", IsNullable = false)]
    public s[] body
    {
      get
      {
        return this.bodyField;
      }
      set
      {
        this.bodyField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get
      {
        return this.idField;
      }
      set
      {
        this.idField = value;
      }
    }
  }
}