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
  public class @float
  {
    private @float float1Field;

    private string keyField;

    private double valueField;

    /// <remarks />
    [XmlElement("float")]
    public @float float1
    {
      get => float1Field;
      set => float1Field = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string key
    {
      get => keyField;
      set => keyField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public double value
    {
      get => valueField;
      set => valueField = value;
    }
  }
}