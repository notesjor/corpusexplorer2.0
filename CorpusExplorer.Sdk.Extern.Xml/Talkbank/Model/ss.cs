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
  [XmlType(AnonymousType = true, Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot(Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class ss
  {
    private int typeField;

    /// <remarks />
    [XmlAttribute]
    public int type { get { return typeField; } set { typeField = value; } }
  }
}