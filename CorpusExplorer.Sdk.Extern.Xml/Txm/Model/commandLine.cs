namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://textometrie.org/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://textometrie.org/1.0", IsNullable = false)]
  public partial class commandLine
  {

    private os osField;

    private osSeparator osSeparatorField;

    private program programField;

    private arg[] argsField;

    /// <remarks/>
    public os os
    {
      get { return this.osField; }
      set { this.osField = value; }
    }

    /// <remarks/>
    public osSeparator osSeparator
    {
      get { return this.osSeparatorField; }
      set { this.osSeparatorField = value; }
    }

    /// <remarks/>
    public program program
    {
      get { return this.programField; }
      set { this.programField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("arg", IsNullable = false)]
    public arg[] args
    {
      get { return this.argsField; }
      set { this.argsField = value; }
    }
  }
}