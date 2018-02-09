#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
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
    public long PeriodDuration { get { return periodDurationField; } set { periodDurationField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool PeriodDurationSpecified
    {
      get { return periodDurationFieldSpecified; }
      set { periodDurationFieldSpecified = value; }
    }

    /// <remarks />
    public bool PeriodExact { get { return periodExactField; } set { periodExactField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool PeriodExactSpecified
    {
      get { return periodExactFieldSpecified; }
      set { periodExactFieldSpecified = value; }
    }

    /// <remarks />
    public DateTime PeriodStart { get { return periodStartField; } set { periodStartField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool PeriodStartSpecified
    {
      get { return periodStartFieldSpecified; }
      set { periodStartFieldSpecified = value; }
    }
  }
}