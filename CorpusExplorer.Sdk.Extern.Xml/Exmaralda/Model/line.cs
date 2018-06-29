#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://tempuri.org/interlinear-text")]
  [XmlRoot(Namespace = "http://tempuri.org/interlinear-text", IsNullable = false)]
  public class line
  {
    private string[] anchorField;
    private string formatrefField;
    private run[] runField;
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
    [XmlElement("run")]
    public run[] run
    {
      get => runField;
      set => runField = value;
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