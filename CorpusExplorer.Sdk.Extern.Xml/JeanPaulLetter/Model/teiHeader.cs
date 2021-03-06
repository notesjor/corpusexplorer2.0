﻿namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class teiHeader
  {

    private fileDesc fileDescField;

    private encodingDesc encodingDescField;

    private profileDesc profileDescField;

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
  }
}