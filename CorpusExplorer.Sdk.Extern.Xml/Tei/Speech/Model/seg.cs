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
  public class seg
  {
    private string functionField;
    private object[] itemsField;
    private string typeField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string function
    {
      get => functionField;
      set => functionField = value;
    }

    /// <remarks />
    [XmlElement("anchor", typeof(anchor))]
    [XmlElement("c", typeof(string))]
    [XmlElement("incident", typeof(incident))]
    [XmlElement("pause", typeof(pause))]
    [XmlElement("unclear", typeof(unclear))]
    [XmlElement("w", typeof(w))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
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