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
  [XmlRoot("mor", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class morType : morphemicBaseType
  {
    private morphemicBaseType[] morpostField;
    private morphemicBaseType[] morpreField;
    private bool omittedField;
    private bool omittedFieldSpecified;
    private string typeField;

    /// <remarks />
    [XmlElement("mor-pre")]
    public morphemicBaseType[] morpre { get { return morpreField; } set { morpreField = value; } }

    /// <remarks />
    [XmlElement("mor-post")]
    public morphemicBaseType[] morpost { get { return morpostField; } set { morpostField = value; } }


    /// <remarks />
    [XmlAttribute]
    public bool omitted { get { return omittedField; } set { omittedField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool omittedSpecified { get { return omittedFieldSpecified; } set { omittedFieldSpecified = value; } }

    /// <remarks />
    [XmlAttribute]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}