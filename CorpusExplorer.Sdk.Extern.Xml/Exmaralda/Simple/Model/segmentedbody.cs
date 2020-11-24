#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot("segmented-body", Namespace = "", IsNullable = false)]
  public class segmentedbody
  {
    private tli[] commontimelineField;
    private segmentedtier[] segmentedtierField;

    /// <remarks />
    [XmlArray("common-timeline")]
    [XmlArrayItem("tli", IsNullable = false)]
    public tli[] commontimeline
    {
      get => commontimelineField;
      set => commontimelineField = value;
    }

    /// <remarks />
    [XmlElement("segmented-tier")]
    public segmentedtier[] segmentedtier
    {
      get => segmentedtierField;
      set => segmentedtierField = value;
    }
  }
}