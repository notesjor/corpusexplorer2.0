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
// Dieser Quellcode wurde automatisch generiert von xsd, Version=4.6.81.0.
// 


namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [XmlType(AnonymousType=true)]
  [XmlRoot(Namespace="", IsNullable=false)]
  public partial class idsCorpus {
    
    private idsHeader idsHeaderField;
    
    private idsDoc[] idsDocField;
    
    private string tEIformField;
    
    private decimal versionField;
    
    /// <remarks/>
    public idsHeader idsHeader {
      get {
        return this.idsHeaderField;
      }
      set {
        this.idsHeaderField = value;
      }
    }
    
    /// <remarks/>
    [XmlElement("idsDoc")]
    public idsDoc[] idsDoc {
      get {
        return this.idsDocField;
      }
      set {
        this.idsDocField = value;
      }
    }
    
    /// <remarks/>
    [XmlAttribute(DataType="NCName")]
    public string TEIform {
      get {
        return this.tEIformField;
      }
      set {
        this.tEIformField = value;
      }
    }
    
    /// <remarks/>
    [XmlAttribute()]
    public decimal version {
      get {
        return this.versionField;
      }
      set {
        this.versionField = value;
      }
    }
  }
}