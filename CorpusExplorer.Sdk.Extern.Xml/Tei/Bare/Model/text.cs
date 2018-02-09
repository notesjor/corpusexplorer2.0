#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class text
  {
    private back backField;
    private body bodyField;
    private front frontField;

    /// <remarks />
    public back back { get { return backField; } set { backField = value; } }

    /// <remarks />
    public body body { get { return bodyField; } set { bodyField = value; } }

    /// <remarks />
    public front front { get { return frontField; } set { frontField = value; } }
  }
}