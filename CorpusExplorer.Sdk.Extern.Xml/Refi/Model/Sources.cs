﻿namespace CorpusExplorer.Sdk.Extern.Xml.Refi.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:QDA-XML:project:1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:QDA-XML:project:1.0", IsNullable = false)]
  public partial class Sources
  {

    private TextSource[] textSourceField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TextSource")]
    public TextSource[] TextSource
    {
      get
      {
        return this.textSourceField;
      }
      set
      {
        this.textSourceField = value;
      }
    }
  }
}