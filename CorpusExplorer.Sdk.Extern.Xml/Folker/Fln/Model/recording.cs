﻿namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class recording
  {

    private string dgdidField;

    private string pathField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("dgd-id", DataType = "NCName")]
    public string dgdid
    {
      get { return this.dgdidField; }
      set { this.dgdidField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string path
    {
      get { return this.pathField; }
      set { this.pathField = value; }
    }
  }
}