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

// 
// Dieser Quellcode wurde automatisch generiert von xsd, Version=4.8.3928.0.
// 
namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("basic-transcription", Namespace = "", IsNullable = false)]
  public partial class basictranscription
  {

    private head headField;

    private basicbody basicbodyField;

    private tierformattable tierformattableField;

    /// <remarks/>
    public head head
    {
      get { return this.headField; }
      set { this.headField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("basic-body")]
    public basicbody basicbody
    {
      get { return this.basicbodyField; }
      set { this.basicbodyField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tierformat-table")]
    public tierformattable tierformattable
    {
      get { return this.tierformattableField; }
      set { this.tierformattableField = value; }
    }
  }
}