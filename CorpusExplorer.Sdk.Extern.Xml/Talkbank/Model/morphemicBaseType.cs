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
  [XmlInclude(typeof(morType))]
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot("mor-pre", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class morphemicBaseType
  {
    private graType[] graField;
    private object itemField;
    private morphemicTranslationType[] menxField;

    /// <remarks />
    [XmlElement("mt", typeof(baseTerminatorType))]
    [XmlElement("mw", typeof(morphemicWordType))]
    [XmlElement("mwc", typeof(morphemicCompoundWordType))]
    public object Item { get { return itemField; } set { itemField = value; } }

    /// <remarks />
    [XmlElement("menx")]
    public morphemicTranslationType[] menx { get { return menxField; } set { menxField = value; } }

    /// <remarks />
    [XmlElement("gra")]
    public graType[] gra { get { return graField; } set { graField = value; } }
  }
}