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
  public class date
  {
    private string keyField;

    private DateTime valueField;

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string key
    {
      get => keyField;
      set => keyField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public DateTime value
    {
      get => valueField;
      set => valueField = value;
    }
  }
}