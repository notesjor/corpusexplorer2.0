#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class segment
  {
    private string endreferenceField;
    private string startreferenceField;
    private string valueField;

    /// <remarks />
    [XmlAttribute("end-reference", DataType = "IDREF")]
    public string endreference { get { return endreferenceField; } set { endreferenceField = value; } }

    /// <remarks />
    [XmlAttribute("start-reference", DataType = "IDREF")]
    public string startreference { get { return startreferenceField; } set { startreferenceField = value; } }

    /// <remarks />
    [XmlText]
    public string Value { get { return valueField; } set { valueField = value; } }
  }
}