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
  public class link
  {
    private linkType typeField;
    private bool typeFieldSpecified;
    private string urlField;

    /// <remarks />
    [XmlAttribute]
    public linkType type { get { return typeField; } set { typeField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool typeSpecified { get { return typeFieldSpecified; } set { typeFieldSpecified = value; } }

    /// <remarks />
    [XmlAttribute]
    public string url { get { return urlField; } set { urlField = value; } }
  }
}