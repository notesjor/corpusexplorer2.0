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
namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Drucksachen.Model
{

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class DOKUMENT
  {

    private string wAHLPERIODEField;

    private string dOKUMENTARTField;

    private string dRS_TYPField;

    private string nrField;

    private string dATUMField;

    private string tITELField;

    private string[] k_URHEBERField;

    private string[] p_URHEBERField;

    private string tEXTField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string WAHLPERIODE
    {
      get { return this.wAHLPERIODEField; }
      set { this.wAHLPERIODEField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
    public string DOKUMENTART
    {
      get { return this.dOKUMENTARTField; }
      set { this.dOKUMENTARTField = value; }
    }

    /// <remarks/>
    public string DRS_TYP
    {
      get { return this.dRS_TYPField; }
      set { this.dRS_TYPField = value; }
    }

    /// <remarks/>
    public string NR
    {
      get { return this.nrField; }
      set { this.nrField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NMTOKEN")]
    public string DATUM
    {
      get { return this.dATUMField; }
      set { this.dATUMField = value; }
    }

    /// <remarks/>
    public string TITEL
    {
      get { return this.tITELField; }
      set { this.tITELField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("K_URHEBER")]
    public string[] K_URHEBER
    {
      get { return this.k_URHEBERField; }
      set { this.k_URHEBERField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("P_URHEBER")]
    public string[] P_URHEBER
    {
      get { return this.p_URHEBERField; }
      set { this.p_URHEBERField = value; }
    }

    /// <remarks/>
    public string TEXT
    {
      get { return this.tEXTField; }
      set { this.tEXTField = value; }
    }
  }
}