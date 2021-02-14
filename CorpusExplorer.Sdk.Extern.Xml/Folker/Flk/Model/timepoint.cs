#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Flk.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class timepoint
  {
    private decimal absolutetimeField;
    private string timepointidField;

    /// <remarks />
    [XmlAttribute("absolute-time")]
    public decimal absolutetime
    {
      get => absolutetimeField;
      set => absolutetimeField = value;
    }

    /// <remarks />
    [XmlAttribute("timepoint-id", DataType = "ID")]
    public string timepointid
    {
      get => timepointidField;
      set => timepointidField = value;
    }
  }
}