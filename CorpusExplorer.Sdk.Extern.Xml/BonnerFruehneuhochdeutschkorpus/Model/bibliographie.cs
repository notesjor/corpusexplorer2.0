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
  public class bibliographie
  {
    private string angabe_nrField;

    private Basis basisField;

    private string dateiField;

    private a[] linksField;

    private string textnrField;

    private Zusatz zusatzField;

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string Angabe_nr
    {
      get => angabe_nrField;
      set => angabe_nrField = value;
    }

    /// <remarks />
    public Basis Basis
    {
      get => basisField;
      set => basisField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "NMTOKEN")]
    public string datei
    {
      get => dateiField;
      set => dateiField = value;
    }

    /// <remarks />
    [XmlArrayItem("a", IsNullable = false)]
    public a[] Links
    {
      get => linksField;
      set => linksField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string textnr
    {
      get => textnrField;
      set => textnrField = value;
    }

    /// <remarks />
    public Zusatz Zusatz
    {
      get => zusatzField;
      set => zusatzField = value;
    }
  }
}