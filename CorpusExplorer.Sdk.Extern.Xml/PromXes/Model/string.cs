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
  public class @string
  {
    private object[] itemsField;

    private string keyField;

    private string valueField;

    /// <remarks />
    [XmlElement("float", typeof(@float))]
    [XmlElement("int", typeof(@int))]
    [XmlElement("string", typeof(@string))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
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
    public string value
    {
      get => valueField;
      set => valueField = value;
    }
  }
}