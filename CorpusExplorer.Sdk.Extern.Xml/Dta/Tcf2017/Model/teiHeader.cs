﻿namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute("Components", Namespace = "http://www.clarin.eu/cmd/1", IsNullable = false)]
  public partial class teiHeader
  {

    private teiHeader1 teiHeader1Field;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("teiHeader")]
    public teiHeader1 teiHeader1
    {
      get
      {
        return this.teiHeader1Field;
      }
      set
      {
        this.teiHeader1Field = value;
      }
    }
  }
}