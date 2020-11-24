#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://tempuri.org/interlinear-text")]
  [XmlRoot("it-bundle", Namespace = "http://tempuri.org/interlinear-text", IsNullable = false)]
  public class itbundle
  {
    private string[] anchorField;
    private string formatrefField;
    private frameend frameendField;
    private itline[] itlineField;
    private syncpoints syncpointsField;
    private udattribute[] udinformationField;

    /// <remarks />
    [XmlElement("anchor")]
    public string[] anchor
    {
      get => anchorField;
      set => anchorField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string formatref
    {
      get => formatrefField;
      set => formatrefField = value;
    }

    /// <remarks />
    [XmlElement("frame-end")]
    public frameend frameend
    {
      get => frameendField;
      set => frameendField = value;
    }

    /// <remarks />
    [XmlElement("it-line")]
    public itline[] itline
    {
      get => itlineField;
      set => itlineField = value;
    }

    /// <remarks />
    [XmlElement("sync-points")]
    public syncpoints syncpoints
    {
      get => syncpointsField;
      set => syncpointsField = value;
    }

    /// <remarks />
    [XmlArray("ud-information")]
    [XmlArrayItem("ud-attribute", IsNullable = false)]
    public udattribute[] udinformation
    {
      get => udinformationField;
      set => udinformationField = value;
    }
  }
}