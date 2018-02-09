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
  [XmlType(AnonymousType = true)]
  [XmlRoot("start-state", Namespace = "", IsNullable = false)]
  public class startstate
  {
    private string idField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string id { get { return idField; } set { idField = value; } }
  }
}