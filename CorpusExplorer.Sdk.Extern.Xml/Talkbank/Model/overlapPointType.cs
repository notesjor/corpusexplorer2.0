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
  [XmlRoot("overlap-point", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class overlapPointType
  {
    private string indexField;
    private overlapPointTypeStartend startendField;
    private overlapPointTypeTopbottom topbottomField;

    /// <remarks />
    [XmlAttribute(DataType = "positiveInteger")]
    public string index
    {
      get => indexField;
      set => indexField = value;
    }

    /// <remarks />
    [XmlAttribute("start-end")]
    public overlapPointTypeStartend startend
    {
      get => startendField;
      set => startendField = value;
    }

    /// <remarks />
    [XmlAttribute("top-bottom")]
    public overlapPointTypeTopbottom topbottom
    {
      get => topbottomField;
      set => topbottomField = value;
    }
  }
}