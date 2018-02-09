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
  [XmlRoot("align", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class alignmentType
  {
    private alignmentColumn[] colField;

    /// <remarks />
    [XmlElement("col")]
    public alignmentColumn[] col { get { return colField; } set { colField = value; } }
  }
}