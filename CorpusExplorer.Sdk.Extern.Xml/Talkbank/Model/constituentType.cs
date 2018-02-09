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
  [XmlRoot("ph", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class constituentType
  {
    private bool hiatusField;
    private bool hiatusFieldSpecified;
    private string idField;
    private constituentTypeType sctypeField;
    private string[] textField;

    public constituentType() { sctypeField = constituentTypeType.UK; }

    /// <remarks />
    [XmlAttribute]
    public bool hiatus { get { return hiatusField; } set { hiatusField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool hiatusSpecified { get { return hiatusFieldSpecified; } set { hiatusFieldSpecified = value; } }

    /// <remarks />
    [XmlAttribute]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlAttribute]
    [DefaultValue(constituentTypeType.UK)]
    public constituentTypeType sctype { get { return sctypeField; } set { sctypeField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}