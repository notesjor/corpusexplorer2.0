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
  public class Ersch
  {
    private string artField;

    private string ejahrField;

    private string eortField;

    private ItemChoiceType itemElementNameField;

    private string itemField;

    private string reiheField;

    private string umfangField;

    /// <remarks />
    [XmlElement(DataType = "NCName")]
    public string Art
    {
      get => artField;
      set => artField = value;
    }

    /// <remarks />
    public string Ejahr
    {
      get => ejahrField;
      set => ejahrField = value;
    }

    /// <remarks />
    public string Eort
    {
      get => eortField;
      set => eortField = value;
    }

    /// <remarks />
    [XmlElement("Band", typeof(string), DataType = "integer")]
    [XmlElement("Druck", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public string Item
    {
      get => itemField;
      set => itemField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public ItemChoiceType ItemElementName
    {
      get => itemElementNameField;
      set => itemElementNameField = value;
    }

    /// <remarks />
    public string Reihe
    {
      get => reiheField;
      set => reiheField = value;
    }

    /// <remarks />
    public string Umfang
    {
      get => umfangField;
      set => umfangField = value;
    }
  }
}