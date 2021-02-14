#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Flk.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class phrase
  {
    private phraseBoundaryintonation boundaryintonationField;
    private bool boundaryintonationFieldSpecified;
    private object[] itemsField;
    private phraseType typeField;

    /// <remarks />
    [XmlAttribute("boundary-intonation")]
    public phraseBoundaryintonation boundaryintonation
    {
      get => boundaryintonationField;
      set => boundaryintonationField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool boundaryintonationSpecified
    {
      get => boundaryintonationFieldSpecified;
      set => boundaryintonationFieldSpecified = value;
    }

    /// <remarks />
    [XmlElement("breathe", typeof(breathe))]
    [XmlElement("non-phonological", typeof(nonphonological))]
    [XmlElement("pause", typeof(pause))]
    [XmlElement("time", typeof(time))]
    [XmlElement("uncertain", typeof(uncertain))]
    [XmlElement("w", typeof(w))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public phraseType type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}