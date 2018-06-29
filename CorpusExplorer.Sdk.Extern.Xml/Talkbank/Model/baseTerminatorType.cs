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
  [XmlInclude(typeof(terminatorType))]
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot("mt", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class baseTerminatorType
  {
    private baseTerminatorTypeType typeField;

    /// <remarks />
    [XmlAttribute]
    public baseTerminatorTypeType type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}