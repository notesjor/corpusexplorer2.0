﻿namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class classDecl
  {

    private taxonomy[] taxonomyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("taxonomy")]
    public taxonomy[] taxonomy
    {
      get { return this.taxonomyField; }
      set { this.taxonomyField = value; }
    }
  }
}