﻿namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.SubSub.Head
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class gap
  {

    private bool instantField;

    private string reasonField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool instant
    {
      get { return this.instantField; }
      set { this.instantField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string reason
    {
      get { return this.reasonField; }
      set { this.reasonField = value; }
    }
  }
}