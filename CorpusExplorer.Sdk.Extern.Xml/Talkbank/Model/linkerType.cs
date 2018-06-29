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
  public class linkerType
  {
    private linkerTypeType typeField;
    private bool typeFieldSpecified;

    /// <remarks />
    [XmlAttribute]
    public linkerTypeType type
    {
      get => typeField;
      set => typeField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool typeSpecified
    {
      get => typeFieldSpecified;
      set => typeFieldSpecified = value;
    }
  }
}