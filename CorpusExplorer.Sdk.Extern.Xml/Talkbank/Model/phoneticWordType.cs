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
  [XmlRoot("pw", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class phoneticWordType
  {
    private object[] itemsField;

    /// <remarks />
    [XmlElement("ph", typeof(constituentType))]
    [XmlElement("ss", typeof(ss))]
    [XmlElement("wk", typeof(wordnetMarkerType))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }
  }
}