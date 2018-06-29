using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PromXes.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.xes-standard.org/")]
  [XmlRoot(Namespace = "http://www.xes-standard.org/", IsNullable = false)]
  public class trace
  {
    private date dateField;

    private object[][] eventField;

    private @string[] stringField;

    /// <remarks />
    public date date
    {
      get => dateField;
      set => dateField = value;
    }

    /// <remarks />
    [XmlArrayItem("date", typeof(date), IsNullable = false)]
    [XmlArrayItem("string", typeof(@string), IsNullable = false)]
    public object[][] @event
    {
      get => eventField;
      set => eventField = value;
    }

    /// <remarks />
    [XmlElement("string")]
    public @string[] @string
    {
      get => stringField;
      set => stringField = value;
    }
  }
}