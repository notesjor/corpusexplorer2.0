using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class text
  {
    private div[] backField;

    private body bodyField;

    private front frontField;

    /// <remarks />
    [XmlArrayItem("div", IsNullable = false)]
    public div[] back { get { return backField; } set { backField = value; } }

    /// <remarks />
    public body body { get { return bodyField; } set { bodyField = value; } }

    /// <remarks />
    public front front { get { return frontField; } set { frontField = value; } }
  }
}