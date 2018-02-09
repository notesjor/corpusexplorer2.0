#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
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
  [XmlRoot("non-phonological", Namespace = "", IsNullable = false)]
  public class nonphonological
  {
    private string descriptionField;

    /// <remarks />
    [XmlAttribute]
    public string description { get { return descriptionField; } set { descriptionField = value; } }
  }
}