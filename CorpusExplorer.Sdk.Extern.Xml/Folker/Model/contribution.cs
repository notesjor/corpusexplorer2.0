#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class contribution
  {
    private string endreferenceField;
    private object[] itemsField;
    private int parselevelField;
    private bool parselevelFieldSpecified;
    private string speakerreferenceField;
    private string startreferenceField;

    /// <remarks />
    [XmlAttribute("end-reference", DataType = "IDREF")]
    public string endreference
    {
      get => endreferenceField;
      set => endreferenceField = value;
    }

    /// <remarks />
    [XmlElement("breathe", typeof(breathe))]
    [XmlElement("non-phonological", typeof(nonphonological))]
    [XmlElement("pause", typeof(pause))]
    [XmlElement("phrase", typeof(phrase))]
    [XmlElement("segment", typeof(segment))]
    [XmlElement("time", typeof(time))]
    [XmlElement("uncertain", typeof(uncertain))]
    [XmlElement("unparsed", typeof(contributionUnparsed), Form = XmlSchemaForm.Unqualified)]
    [XmlElement("w", typeof(w))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute("parse-level")]
    public int parselevel
    {
      get => parselevelField;
      set => parselevelField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool parselevelSpecified
    {
      get => parselevelFieldSpecified;
      set => parselevelFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute("speaker-reference", DataType = "IDREF")]
    public string speakerreference
    {
      get => speakerreferenceField;
      set => speakerreferenceField = value;
    }

    /// <remarks />
    [XmlAttribute("start-reference", DataType = "IDREF")]
    public string startreference
    {
      get => startreferenceField;
      set => startreferenceField = value;
    }
  }
}