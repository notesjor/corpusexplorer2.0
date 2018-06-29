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
  public class zeile
  {
    private object[] itemsField;

    private string lf_nrField;

    private string lf_seiteField;

    private string nrField;

    private string[] textField;

    /// <remarks />
    [XmlElement("eingriff", typeof(eingriff))]
    [XmlElement("emph", typeof(emph))]
    [XmlElement("name", typeof(name))]
    [XmlElement("ueberschrift", typeof(ueberschrift))]
    [XmlElement("wortform", typeof(wortform))]
    [XmlElement("zitat", typeof(zitat))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
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
    public string lf_seite
    {
      get => lf_seiteField;
      set => lf_seiteField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string nr
    {
      get => nrField;
      set => nrField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }
  }
}