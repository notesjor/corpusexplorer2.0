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
  public class incident
  {
    private string descField;
    private string endField;
    private string startField;
    private string typeField;

    /// <remarks />
    public string desc
    {
      get => descField;
      set => descField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string end
    {
      get => endField;
      set => endField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string start
    {
      get => startField;
      set => startField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}