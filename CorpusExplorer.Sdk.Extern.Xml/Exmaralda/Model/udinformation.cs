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
  [XmlRoot("ud-information", Namespace = "", IsNullable = false)]
  public class udinformation
  {
    private string attributenameField;
    private string[] textField;
    private udattribute[] udattributeField;

    /// <remarks />
    [XmlAttribute("attribute-name")]
    public string attributename { get { return attributenameField; } set { attributenameField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlElement("ud-attribute")]
    public udattribute[] udattribute { get { return udattributeField; } set { udattributeField = value; } }
  }
}