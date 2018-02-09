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
  public class formats
  {
    private format[] formatField;

    /// <remarks />
    [XmlElement("format")]
    public format[] format { get { return formatField; } set { formatField = value; } }
  }
}