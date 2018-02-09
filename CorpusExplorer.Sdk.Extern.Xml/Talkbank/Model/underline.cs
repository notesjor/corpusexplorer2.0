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
  public class underline
  {
    private beginEndType typeField;
    private empty valueField;

    /// <remarks />
    [XmlAttribute]
    public beginEndType type { get { return typeField; } set { typeField = value; } }

    /// <remarks />
    [XmlText]
    public empty Value { get { return valueField; } set { valueField = value; } }
  }
}