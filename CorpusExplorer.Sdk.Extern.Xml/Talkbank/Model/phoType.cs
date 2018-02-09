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
  [XmlInclude(typeof(modelPhoType))]
  [XmlInclude(typeof(actualPhoType))]
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  public class phoType
  {
    private object[][] pwField;

    /// <remarks />
    [XmlArrayItem("ph", typeof(constituentType), IsNullable = false)]
    [XmlArrayItem("ss", typeof(ss), IsNullable = false)]
    [XmlArrayItem("wk", typeof(wordnetMarkerType), IsNullable = false)]
    public object[][] pw { get { return pwField; } set { pwField = value; } }
  }
}