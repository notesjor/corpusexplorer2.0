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
  [XmlRoot("pos", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class posType
  {
    private string cField;
    private string[] sField;

    /// <remarks />
    public string c { get { return cField; } set { cField = value; } }

    /// <remarks />
    [XmlElement("s")]
    public string[] s { get { return sField; } set { sField = value; } }
  }
}