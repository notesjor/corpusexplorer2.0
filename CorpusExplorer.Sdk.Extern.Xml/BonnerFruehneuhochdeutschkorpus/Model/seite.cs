using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.BonnerFruehneuhochdeutschkorpus.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class seite
  {
    private string colField;

    private string lageField;

    private string lf_nrField;

    private string nr_textField;

    private string nrField;

    private string positionField;

    private string teilField;

    private string typField;

    private zeile[] zeileField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string col
    {
      get => colField;
      set => colField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string lage
    {
      get => lageField;
      set => lageField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string lf_nr
    {
      get => lf_nrField;
      set => lf_nrField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string nr
    {
      get => nrField;
      set => nrField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string nr_text
    {
      get => nr_textField;
      set => nr_textField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string position
    {
      get => positionField;
      set => positionField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string teil
    {
      get => teilField;
      set => teilField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string typ
    {
      get => typField;
      set => typField = value;
    }

    /// <remarks />
    [XmlElement("zeile")]
    public zeile[] zeile
    {
      get => zeileField;
      set => zeileField = value;
    }
  }
}