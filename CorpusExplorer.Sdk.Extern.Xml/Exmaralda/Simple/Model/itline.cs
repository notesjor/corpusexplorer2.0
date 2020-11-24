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
  [XmlRoot("it-line", Namespace = "http://tempuri.org/interlinear-text", IsNullable = false)]
  public class itline
  {
    private itlineBreaktype breaktypeField;
    private string formatrefField;
    private itchunk[] itchunkField;
    private itlabel itlabelField;
    private udattribute[] udinformationField;

    /// <remarks />
    [XmlAttribute]
    public itlineBreaktype breaktype
    {
      get => breaktypeField;
      set => breaktypeField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string formatref
    {
      get => formatrefField;
      set => formatrefField = value;
    }

    /// <remarks />
    [XmlElement("it-chunk")]
    public itchunk[] itchunk
    {
      get => itchunkField;
      set => itchunkField = value;
    }

    /// <remarks />
    [XmlElement("it-label")]
    public itlabel itlabel
    {
      get => itlabelField;
      set => itlabelField = value;
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