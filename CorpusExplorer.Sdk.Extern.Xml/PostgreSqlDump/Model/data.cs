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
// Dieser Quellcode wurde automatisch generiert von xsd, Version=4.6.1055.0.
// 
namespace CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump.Model
{

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class data
  {

    private column[] headerField;

    private column[][] recordsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("column", IsNullable = false)]
    public column[] header
    {
      get { return this.headerField; }
      set { this.headerField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("row", IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("column", IsNullable = false, NestingLevel = 1)]
    public column[][] records
    {
      get { return this.recordsField; }
      set { this.recordsField = value; }
    }
  }
}