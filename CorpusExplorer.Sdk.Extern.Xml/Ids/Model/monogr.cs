﻿namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class monogr
  {

    private htitle[] htitleField;

    private editor editorField;

    private imprint imprintField;

    private biblScope[] biblScopeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("h.title")]
    public htitle[] htitle
    {
      get { return this.htitleField; }
      set { this.htitleField = value; }
    }

    /// <remarks/>
    public editor editor
    {
      get { return this.editorField; }
      set { this.editorField = value; }
    }

    /// <remarks/>
    public imprint imprint
    {
      get { return this.imprintField; }
      set { this.imprintField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("biblScope")]
    public biblScope[] biblScope
    {
      get { return this.biblScopeField; }
      set { this.biblScopeField = value; }
    }
  }
}