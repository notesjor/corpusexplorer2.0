﻿namespace CorpusExplorer.Sdk.Extern.Xml.Bawe.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class teiHeader
  {

    private fileDesc fileDescField;

    private encodingDesc encodingDescField;

    private profileDesc profileDescField;

    private string tEIformField;

    private string statusField;

    private string typeField;

    /// <remarks/>
    public fileDesc fileDesc
    {
      get { return this.fileDescField; }
      set { this.fileDescField = value; }
    }

    /// <remarks/>
    public encodingDesc encodingDesc
    {
      get { return this.encodingDescField; }
      set { this.encodingDescField = value; }
    }

    /// <remarks/>
    public profileDesc profileDesc
    {
      get { return this.profileDescField; }
      set { this.profileDescField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string status
    {
      get { return this.statusField; }
      set { this.statusField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }
  }
}