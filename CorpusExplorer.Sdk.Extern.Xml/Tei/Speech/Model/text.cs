#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class text
  {
    private object[] bodyField;
    private timeline timelineField;

    /// <remarks />
    [XmlArrayItem("div", typeof(div), IsNullable = false)]
    [XmlArrayItem("incident", typeof(incident), IsNullable = false)]
    public object[] body
    {
      get => bodyField;
      set => bodyField = value;
    }

    /// <remarks />
    public timeline timeline
    {
      get => timelineField;
      set => timelineField = value;
    }
  }
}