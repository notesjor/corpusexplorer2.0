﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Brown.Model
{


  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class teiCorpus
  {

    private teiHeader teiHeaderField;

    private TEI[] tEIField;

    /// <remarks/>
    public teiHeader teiHeader
    {
      get { return this.teiHeaderField; }
      set { this.teiHeaderField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TEI")]
    public TEI[] TEI
    {
      get { return this.tEIField; }
      set { this.tEIField = value; }
    }
  }
}