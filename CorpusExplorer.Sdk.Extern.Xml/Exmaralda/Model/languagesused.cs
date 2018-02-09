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
  [XmlRoot("languages-used", Namespace = "", IsNullable = false)]
  public class languagesused
  {
    private language[] languageField;

    /// <remarks />
    [XmlElement("language")]
    public language[] language { get { return languageField; } set { languageField = value; } }
  }
}