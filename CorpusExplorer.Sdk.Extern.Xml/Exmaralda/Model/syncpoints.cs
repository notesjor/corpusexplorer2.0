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
  [XmlRoot("sync-points", Namespace = "http://tempuri.org/interlinear-text", IsNullable = false)]
  public class syncpoints
  {
    private string formatrefField;
    private syncpoint[] syncpointField;
    private udattribute[] udinformationField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string formatref { get { return formatrefField; } set { formatrefField = value; } }

    /// <remarks />
    [XmlElement("sync-point")]
    public syncpoint[] syncpoint { get { return syncpointField; } set { syncpointField = value; } }

    /// <remarks />
    [XmlArray("ud-information")]
    [XmlArrayItem("ud-attribute", IsNullable = false)]
    public udattribute[] udinformation { get { return udinformationField; } set { udinformationField = value; } }
  }
}