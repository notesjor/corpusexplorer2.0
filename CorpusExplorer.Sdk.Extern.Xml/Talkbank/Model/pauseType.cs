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
  [XmlRoot("pause", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class pauseType
  {
    private decimal lengthField;
    private bool lengthFieldSpecified;
    private pauseSymbolicLengthType symboliclengthField;

    /// <remarks />
    [XmlAttribute]
    public decimal length
    {
      get => lengthField;
      set => lengthField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool lengthSpecified
    {
      get => lengthFieldSpecified;
      set => lengthFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute("symbolic-length")]
    public pauseSymbolicLengthType symboliclength
    {
      get => symboliclengthField;
      set => symboliclengthField = value;
    }
  }
}