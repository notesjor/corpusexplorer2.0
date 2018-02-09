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
  [XmlRoot("overlap", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class overlapType
  {
    private string indexField;
    private overlapTypeType typeField;

    /// <remarks />
    [XmlAttribute(DataType = "positiveInteger")]
    public string index { get { return indexField; } set { indexField = value; } }

    /// <remarks />
    [XmlAttribute]
    public overlapTypeType type { get { return typeField; } set { typeField = value; } }
  }
}