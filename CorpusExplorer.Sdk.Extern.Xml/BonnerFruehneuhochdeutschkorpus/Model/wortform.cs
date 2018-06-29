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
  public class wortform
  {
    private object[] itemsField;

    private string nachträglichField;

    private string nrField;

    private string nur_leerField;

    private string[] textField;

    private string typField;

    /// <remarks />
    [XmlElement("annotation", typeof(annotation))]
    [XmlElement("morph", typeof(string))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string nachträglich
    {
      get => nachträglichField;
      set => nachträglichField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string nr
    {
      get => nrField;
      set => nrField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string nur_leer
    {
      get => nur_leerField;
      set => nur_leerField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string typ
    {
      get => typField;
      set => typField = value;
    }
  }
}