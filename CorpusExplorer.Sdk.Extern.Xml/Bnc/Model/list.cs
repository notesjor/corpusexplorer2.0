﻿namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class list
  {

    private object[] itemsField;

    private string rendField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("gap", typeof(gap))]
    [System.Xml.Serialization.XmlElementAttribute("head", typeof(head))]
    [System.Xml.Serialization.XmlElementAttribute("item", typeof(item))]
    [System.Xml.Serialization.XmlElementAttribute("label", typeof(label))]
    [System.Xml.Serialization.XmlElementAttribute("pb", typeof(pb))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string rend
    {
      get { return this.rendField; }
      set { this.rendField = value; }
    }
  }
}