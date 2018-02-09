#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot("ga", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class groupAnnotationType
  {
    private string[] textField;
    private groupAnnotationTypeType typeField;
    private bool typeFieldSpecified;

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlAttribute]
    public groupAnnotationTypeType type { get { return typeField; } set { typeField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool typeSpecified { get { return typeFieldSpecified; } set { typeFieldSpecified = value; } }
  }
}