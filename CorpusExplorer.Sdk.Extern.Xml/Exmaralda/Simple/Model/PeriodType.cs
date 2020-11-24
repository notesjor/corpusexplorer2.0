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
  public class PeriodType
  {
    private long periodDurationField;
    private bool periodDurationFieldSpecified;
    private bool periodExactField;
    private bool periodExactFieldSpecified;
    private DateTime periodStartField;
    private bool periodStartFieldSpecified;

    /// <remarks />
    public long PeriodDuration
    {
      get => periodDurationField;
      set => periodDurationField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool PeriodDurationSpecified
    {
      get => periodDurationFieldSpecified;
      set => periodDurationFieldSpecified = value;
    }

    /// <remarks />
    public bool PeriodExact
    {
      get => periodExactField;
      set => periodExactField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool PeriodExactSpecified
    {
      get => periodExactFieldSpecified;
      set => periodExactFieldSpecified = value;
    }

    /// <remarks />
    public DateTime PeriodStart
    {
      get => periodStartField;
      set => periodStartField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool PeriodStartSpecified
    {
      get => periodStartFieldSpecified;
      set => periodStartFieldSpecified = value;
    }
  }
}