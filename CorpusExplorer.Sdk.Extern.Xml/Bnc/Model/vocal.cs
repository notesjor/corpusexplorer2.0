﻿namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class vocal
  {

    private string descField;

    private string durField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string desc
    {
      get { return this.descField; }
      set { this.descField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string dur
    {
      get { return this.durField; }
      set { this.durField = value; }
    }
  }
}