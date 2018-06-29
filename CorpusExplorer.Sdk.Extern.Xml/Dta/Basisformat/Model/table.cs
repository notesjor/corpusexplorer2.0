using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class table
  {
    private string colsField;

    private head headField;

    private object[] itemsField;

    private string renditionField;

    private string rowsField;

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string cols
    {
      get => colsField;
      set => colsField = value;
    }

    /// <remarks />
    public head head
    {
      get => headField;
      set => headField = value;
    }

    /// <remarks />
    [XmlElement("cb", typeof(cb))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("note", typeof(note))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("row", typeof(row))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string rendition
    {
      get => renditionField;
      set => renditionField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string rows
    {
      get => rowsField;
      set => rowsField = value;
    }
  }
}