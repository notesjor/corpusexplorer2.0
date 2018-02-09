using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class quelle
  {
    private string datumField;

    private string freigabedatumField;

    private string freigabeuhrzeitField;

    private string jahrgangField;

    private string lieferantidField;

    private string nameField;

    private string nummerField;

    private string quelleidField;

    private string seiteendeField;

    private string seitestartField;

    /// <remarks />
    public string datum { get { return datumField; } set { datumField = value; } }

    /// <remarks />
    [XmlElement("quelle-id")]
    public string quelleid { get { return quelleidField; } set { quelleidField = value; } }

    /// <remarks />
    [XmlElement("seite-start")]
    public string seitestart { get { return seitestartField; } set { seitestartField = value; } }

    /// <remarks />
    [XmlElement("seite-ende")]
    public string seiteende { get { return seiteendeField; } set { seiteendeField = value; } }

    /// <remarks />
    [XmlElement("freigabe-datum")]
    public string freigabedatum { get { return freigabedatumField; } set { freigabedatumField = value; } }

    /// <remarks />
    [XmlElement("freigabe-uhrzeit")]
    public string freigabeuhrzeit { get { return freigabeuhrzeitField; } set { freigabeuhrzeitField = value; } }

    /// <remarks />
    public string jahrgang { get { return jahrgangField; } set { jahrgangField = value; } }

    /// <remarks />
    [XmlElement("lieferant-id")]
    public string lieferantid { get { return lieferantidField; } set { lieferantidField = value; } }

    /// <remarks />
    public string name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    public string nummer { get { return nummerField; } set { nummerField = value; } }
  }
}